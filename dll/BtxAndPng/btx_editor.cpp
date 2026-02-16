#define PVRTEXLIB_IMPORT
#pragma comment(lib, "PVRTexLib.lib")
#define PVRTEXLIB_IMPORT
#include "btx_editor.h"
#include <iostream>
#include <fstream>
#include <string>
#include <ctime>
#include <filesystem>
#include <memory>
#include <algorithm>
#include "include/PVRTexLib.hpp"
#define STB_IMAGE_IMPLEMENTATION
#include "include/stb_image.h"
#define STB_IMAGE_WRITE_IMPLEMENTATION
#include "include/stb_image_write.h"

namespace fs = std::filesystem;

Logger::Logger(const std::string& filename) {
    log_file.open(filename, std::ios::app);
}

Logger::~Logger() {
    if (log_file.is_open()) log_file.close();
}

std::string Logger::get_current_time() {
    std::time_t now = std::time(nullptr);
    char buffer[100];
    std::strftime(buffer, sizeof(buffer), "%Y-%m-%d %H:%M:%S", std::localtime(&now));
    return buffer;
}

void Logger::info(const std::string& message) {
    if (log_file.is_open()) {
        log_file << get_current_time() << " - INFO - " << message << std::endl;
    }
}

void Logger::error(const std::string& message) {
    if (log_file.is_open()) {
        log_file << get_current_time() << " - ERROR - " << message << std::endl;
    }
    std::cerr << "Error: " << message << std::endl;
}

void Logger::warning(const std::string& message) {
    if (log_file.is_open()) {
        log_file << get_current_time() << " - WARNING - " << message << std::endl;
    }
}

// качество
PVRTexLibCompressorQuality parse_quality(const std::string mode) {
    if (mode == "fast") return PVRTLCQ_ASTCFast;
    if (mode == "medium") return PVRTLCQ_ASTCMedium;
    if (mode == "thorough") return PVRTLCQ_ASTCThorough;
    if (mode == "exhaustive") return PVRTLCQ_ASTCExhaustive;
}

// кол-во блоков
PVRTexLibPixelFormat parse_compress(const std::string mode) {
    if (mode == "4x4") return PVRTLPF_ASTC_4x4;
    if (mode == "6x6") return PVRTLPF_ASTC_6x6;
    if (mode == "8x8") return PVRTLPF_ASTC_8x8;
}

struct TempFileDeleter {
    std::string path;
    Logger& logger;
    TempFileDeleter(const std::string& p, Logger& l) : path(p), logger(l) {}
    ~TempFileDeleter() {
        if (!path.empty() && fs::exists(path)) {
            try {
                fs::remove(path);
                logger.info("Removed temporary file: " + path);
            }
            catch (const std::exception& e) {
                logger.error("Failed to remove temporary file " + path + ": " + std::string(e.what()));
            }
        }
    }
};

// convert_btxtopng
std::string convert_btxtopng(const std::string& btx_path, const std::string& output_png_path, Logger& logger) {
    std::string ktx_path;
    try {
        std::string normalized_btx_path = btx_path;
        std::string normalized_output_path = output_png_path;
        std::replace(normalized_btx_path.begin(), normalized_btx_path.end(), '\\', '/');
        std::replace(normalized_output_path.begin(), normalized_output_path.end(), '\\', '/');

        logger.info("Starting BTX to PNG conversion for " + normalized_btx_path + " -> " + normalized_output_path);

        if (!fs::exists(normalized_btx_path)) {
            logger.error("BTX file not found: " + normalized_btx_path);
            return "";
        }

        fs::path output_dir = fs::path(normalized_output_path).parent_path();
        if (!output_dir.empty() && !fs::exists(output_dir)) {
            fs::create_directories(output_dir);
            logger.info("Created output directory: " + output_dir.string());
        }

        if (fs::exists(normalized_output_path)) {
            int width, height, channels;
            unsigned char* img = stbi_load(normalized_output_path.c_str(), &width, &height, &channels, 0);
            if (img) {
                logger.info("Using cached PNG: " + normalized_output_path);
                stbi_image_free(img);
                return normalized_output_path;
            }
            else {
                logger.warning("Cached PNG " + normalized_output_path + " is corrupted");
                fs::remove(normalized_output_path);
            }
        }

        fs::path temp_dir = output_dir.empty() ? fs::current_path() : output_dir;
        ktx_path = (temp_dir / ("temp_" + fs::path(normalized_btx_path).stem().string() + ".ktx")).string();
        std::replace(ktx_path.begin(), ktx_path.end(), '\\', '/');

        logger.info("Extracting KTX to: " + ktx_path);
        std::unique_ptr<TempFileDeleter> ktx_deleter = std::make_unique<TempFileDeleter>(ktx_path, logger);

        {
            std::ifstream btx_file(normalized_btx_path, std::ios::binary);
            if (!btx_file.is_open()) {
                logger.error("Failed to open BTX file: " + normalized_btx_path);
                return "";
            }
            btx_file.seekg(4);
            if (btx_file.fail()) {
                logger.error("Failed to skip BTX header");
                return "";
            }

            std::ofstream ktx_file(ktx_path, std::ios::binary);
            if (!ktx_file.is_open()) {
                logger.error("Failed to create KTX file: " + ktx_path);
                return "";
            }
            ktx_file << btx_file.rdbuf();
            ktx_file.close();

            if (!fs::exists(ktx_path) || fs::file_size(ktx_path) == 0) {
                logger.error("KTX file was not created or is empty: " + ktx_path);
                return "";
            }
        }

        logger.info("KTX file created successfully, size: " + std::to_string(fs::file_size(ktx_path)) + " bytes");
        pvrtexlib::PVRTexture texture(ktx_path.c_str());

        if (texture.GetTextureDataSize() == 0) {
            logger.error("Failed to load texture from KTX file");
            return "";
        }

        texture.SetTextureColourSpace(PVRTLCS_sRGB);
        if (!texture.Decompress(10)) {
            logger.error("Failed to decompress texture");
            return "";
        }

        if (!texture.SaveSurfaceToImageFile(normalized_output_path.c_str())) {
            logger.error("Failed to save PNG");
            return "";
        }

        if (fs::exists(normalized_output_path)) {
            logger.info("Successfully converted BTX to PNG: " + normalized_output_path);
            return normalized_output_path;
        }

        logger.error("PNG " + normalized_output_path + " was not created");
        return "";

    }
    catch (const std::exception& e) {
        logger.error("Exception in convert_btxtopng: " + std::string(e.what()));
        if (!ktx_path.empty() && fs::exists(ktx_path)) {
            try { fs::remove(ktx_path); }
            catch (...) {}
        }
        return "";
    }
}

// convert_png_to_btx
bool convert_png_to_btx(const std::string& png_path, const std::string& output_btx_path, const std::string& compress_mode, const std::string& quality_mode, Logger& logger) {
    std::string temp_png_path, ktx_path;
    try {
        std::string normalized_png_path = png_path;
        std::string normalized_btx_path = output_btx_path;
        std::replace(normalized_png_path.begin(), normalized_png_path.end(), '\\', '/');
        std::replace(normalized_btx_path.begin(), normalized_btx_path.end(), '\\', '/');

        logger.info("Starting PNG to BTX conversion for " + normalized_png_path + " -> " + normalized_btx_path);

        if (!fs::exists(normalized_png_path)) {
            logger.error("PNG file not found: " + normalized_png_path);
            return false;
        }

        int width, height, channels;
        unsigned char* img = stbi_load(normalized_png_path.c_str(), &width, &height, &channels, 4);
        if (!img) {
            logger.error("Failed to load PNG: " + normalized_png_path);
            return false;
        }

        fs::path output_dir = fs::path(normalized_btx_path).parent_path();
        if (!output_dir.empty() && !fs::exists(output_dir)) {
            fs::create_directories(output_dir);
            logger.info("Created output directory: " + output_dir.string());
        }

        temp_png_path = (output_dir / "temp_input.png").string();
        std::replace(temp_png_path.begin(), temp_png_path.end(), '\\', '/');
        std::unique_ptr<TempFileDeleter> png_deleter = std::make_unique<TempFileDeleter>(temp_png_path, logger);
        if (!stbi_write_png(temp_png_path.c_str(), width, height, 4, img, width * 4)) {
            logger.error("Failed to save temporary PNG: " + temp_png_path);
            stbi_image_free(img);
            return false;
        }
        stbi_image_free(img);

        pvrtexlib::PVRTexture texture(temp_png_path.c_str());
        if (!texture.PreMultiplyAlpha() || !texture.Bleed() || !texture.GenerateMIPMaps(PVRTLRM_Linear)) {
            logger.error("Failed to process texture");
            return false;
        }

        auto quality = parse_quality(quality_mode);
        auto compress = parse_compress(compress_mode);

        if (!texture.Transcode(
            compress,
            PVRTLVT_UnsignedByteNorm,
            PVRTLCS_sRGB,
            quality
        )) {
            logger.error("Failed to transcode texture");
            return false;
        }

        ktx_path = (output_dir / "temp.ktx").string();
        std::replace(ktx_path.begin(), ktx_path.end(), '\\', '/');
        std::unique_ptr<TempFileDeleter> ktx_deleter = std::make_unique<TempFileDeleter>(ktx_path, logger);
        if (!texture.SaveToFile(ktx_path.c_str())) {
            logger.error("Failed to save KTX");
            return false;
        }

        {
            std::ifstream ktx_file(ktx_path, std::ios::binary);
            std::ofstream btx_file(normalized_btx_path, std::ios::binary);
            btx_file.write("\x02\x00\x00\x00", 4);
            btx_file << ktx_file.rdbuf();
            if (!btx_file) {
                logger.error("Failed to create BTX: " + normalized_btx_path);
                return false;
            }
        }

        if (fs::exists(normalized_btx_path)) {
            logger.info("Converted PNG to BTX: " + normalized_btx_path);
            return true;
        }

        logger.error("BTX " + normalized_btx_path + " was not created");
        return false;
    }
    catch (const std::exception& e) {
        logger.error("Failed to convert PNG to BTX: " + std::string(e.what()));
        return false;
    }
}

// convert_auto_btx_and_png
bool convert_auto_btx_and_png(const std::string& input_path, const std::string& output_path, const std::string& compress_mode, const std::string& quality_mode, Logger& logger) {
    try {
        std::string normalized_input = input_path;
        std::string normalized_output = output_path;
        std::replace(normalized_input.begin(), normalized_input.end(), '\\', '/');
        std::replace(normalized_output.begin(), normalized_output.end(), '\\', '/');

        logger.info("Starting conversion: " + normalized_input + " -> " + normalized_output);

        if (!fs::exists(normalized_input)) {
            logger.error("Input file not found: " + normalized_input);
            return false;
        }

        fs::path input_file_path(normalized_input);
        std::string extension = input_file_path.extension().string();
        std::transform(extension.begin(), extension.end(), extension.begin(), ::tolower);

        if (extension == ".btx") {
            // BTX > PNG
            std::string result = convert_btxtopng(normalized_input, normalized_output, logger);
            if (!result.empty()) {
                logger.info("Successfully converted BTX to PNG: " + normalized_output);
                std::cout << "Successfully converted to: " << normalized_output << std::endl;
                return true;
            }
            else {
                logger.error("Failed to convert BTX to PNG");
                return false;
            }
        }
        else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg") {
            // PNG/JPG > BTX
            bool result = convert_png_to_btx(normalized_input, normalized_output, compress_mode, quality_mode, logger);
            if (result) {
                logger.info("Successfully converted image to BTX: " + normalized_output);
                std::cout << "Successfully converted to: " << normalized_output << std::endl;
                return true;
            }
            else {
                logger.error("Failed to convert image to BTX");
                return false;
            }
        }
        else {
            logger.error("Unsupported file format: " + extension);
            std::cout << "Unsupported file format: " << extension << std::endl;
            std::cout << "Supported formats: .btx, .png, .jpg, .jpeg" << std::endl;
            return false;
        }
    }
    catch (const std::exception& e) {
        logger.error("Conversion failed: " + std::string(e.what()));
        return false;
    }
}