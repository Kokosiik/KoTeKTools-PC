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

// Реализация Logger
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

// Структура для автоматического удаления временных файлов
struct TempFileDeleter {
    std::string path;
    Logger& logger;
    TempFileDeleter(const std::string& p, Logger& l) : path(p), logger(l) {}
    ~TempFileDeleter() {
        if (!path.empty() && fs::exists(path)) {
            try {
                fs::remove(path);
                logger.info("Removed temporary file: " + path);
            } catch (const std::exception& e) {
                logger.error("Failed to remove temporary file " + path + ": " + std::string(e.what()));
            }
        }
    }
};

// convert_btxtopng
std::string convert_btxtopng(const std::string& btx_path, const std::string& output_path, Logger& logger) {
    std::string ktx_path;
    try {
        std::string normalized_btx_path = btx_path;
        std::string normalized_output_path = output_path;
        std::replace(normalized_btx_path.begin(), normalized_btx_path.end(), '\\', '/');
        std::replace(normalized_output_path.begin(), normalized_output_path.end(), '\\', '/');

        logger.info("Starting BTX to PNG conversion for " + normalized_btx_path);

        // Проверяем существование исходного файла
        if (!fs::exists(normalized_btx_path)) {
            logger.error("BTX file not found: " + normalized_btx_path);
            return "";
        }

        // Проверяем размер файла
        if (fs::file_size(normalized_btx_path) < 4) {
            logger.error("Invalid BTX file (too small): " + normalized_btx_path);
            return "";
        }

        // Создаем директорию для выходного файла если нужно
        fs::path output_dir = fs::path(normalized_output_path).parent_path();
        if (!output_dir.empty() && !fs::exists(output_dir)) {
            fs::create_directories(output_dir);
            logger.info("Created output directory: " + output_dir.string());
        }

        // Проверяем кэшированный PNG
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

        // Создаем путь для временного KTX файла в той же директории что и выходной файл
        fs::path temp_dir = output_dir.empty() ? fs::current_path() : output_dir;
        ktx_path = (temp_dir / ("temp_" + fs::path(normalized_btx_path).stem().string() + ".ktx")).string();
        std::replace(ktx_path.begin(), ktx_path.end(), '\\', '/');

        logger.info("Extracting KTX to: " + ktx_path);

        std::unique_ptr<TempFileDeleter> ktx_deleter = std::make_unique<TempFileDeleter>(ktx_path, logger);

        // Извлекаем KTX из BTX
        {
            std::ifstream btx_file(normalized_btx_path, std::ios::binary);
            if (!btx_file.is_open()) {
                logger.error("Failed to open BTX file: " + normalized_btx_path);
                return "";
            }

            // Пропускаем заголовок BTX (4 байта)
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

            // Копируем данные
            ktx_file << btx_file.rdbuf();
            ktx_file.close();

            // Проверяем успешность операции
            if (!fs::exists(ktx_path) || fs::file_size(ktx_path) == 0) {
                logger.error("KTX file was not created or is empty: " + ktx_path);
                return "";
            }
        }

        logger.info("KTX file created successfully, size: " + std::to_string(fs::file_size(ktx_path)) + " bytes");
        logger.info("Loading texture from: " + ktx_path);

        // Загружаем текстуру из KTX
        pvrtexlib::PVRTexture texture(ktx_path.c_str());

        // Проверяем успешность загрузки текстуры
        if (texture.GetTextureDataSize() == 0) {
            logger.error("Failed to load texture from KTX file");
            return "";
        }

        logger.info("Texture loaded successfully, data size: " + std::to_string(texture.GetTextureDataSize()));
        logger.info("Pixel format: " + std::to_string(texture.GetTexturePixelFormat()));
        logger.info("Current colour space: " + std::to_string(texture.GetColourSpace()));

        logger.info("Setting sRGB colour space");
        texture.SetTextureColourSpace(PVRTLCS_sRGB);

        logger.info("Decompressing texture");
        if (!texture.Decompress(10)) {
            logger.error("Failed to decompress texture");
            return "";
        }

        logger.info("Saving PNG to: " + normalized_output_path);
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
        // Удаляем временный файл если он был создан
        if (!ktx_path.empty() && fs::exists(ktx_path)) {
            try {
                fs::remove(ktx_path);
            }
            catch (...) {
                // Игнорируем ошибки удаления
            }
        }
        return "";
    }
}

// convert_png_to_btx
bool convert_png_to_btx(const std::string& png_path, const std::string& btx_path, Logger& logger) {
    std::string temp_png_path, ktx_path;
    try {
        std::string normalized_png_path = png_path;
        std::string normalized_btx_path = btx_path;
        std::replace(normalized_png_path.begin(), normalized_png_path.end(), '\\', '/');
        std::replace(normalized_btx_path.begin(), normalized_btx_path.end(), '\\', '/');

        logger.info("Starting PNG to BTX conversion for " + normalized_png_path);

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

        temp_png_path = (fs::path(normalized_btx_path).parent_path() / "temp_input.png").string();
        std::replace(temp_png_path.begin(), temp_png_path.end(), '\\', '/');
        logger.info("Saving temporary PNG: " + temp_png_path);
        std::unique_ptr<TempFileDeleter> png_deleter = std::make_unique<TempFileDeleter>(temp_png_path, logger);
        if (!stbi_write_png(temp_png_path.c_str(), width, height, 4, img, width * 4)) {
            logger.error("Failed to save temporary PNG: " + temp_png_path);
            stbi_image_free(img);
            return false;
        }
        stbi_image_free(img);

        logger.info("Loading texture from: " + temp_png_path);
        pvrtexlib::PVRTexture texture(temp_png_path.c_str());
        logger.info("Current colour space: " + std::to_string(texture.GetColourSpace()));

        if (!texture.PreMultiplyAlpha()) {
            logger.error("Failed to pre-multiply alpha");
            return false;
        }
        if (!texture.Bleed()) {
            logger.error("Failed to apply bleed");
            return false;
        }
        if (!texture.GenerateMIPMaps(PVRTLRM_Linear)) {
            logger.error("Failed to generate MIP maps");
            return false;
        }

        // Транскодирование с sRGB и высоким качеством
        if (!texture.Transcode(
            PVRTLPF_ASTC_4x4,
            PVRTLVT_UnsignedByteNorm,
            PVRTLCS_sRGB,
            PVRTLCQ_ASTCExhaustive
        )) {
            logger.error("Failed to transcode texture");
            return false;
        }

        ktx_path = (fs::path(normalized_btx_path).parent_path() / "temp.ktx").string();
        std::replace(ktx_path.begin(), ktx_path.end(), '\\', '/');
        logger.info("Saving KTX to: " + ktx_path);
        std::unique_ptr<TempFileDeleter> ktx_deleter = std::make_unique<TempFileDeleter>(ktx_path, logger);
        if (!texture.SaveToFile(ktx_path.c_str())) {
            logger.error("Failed to save KTX");
            return false;
        }

        logger.info("Creating BTX: " + normalized_btx_path);
        {
            std::ifstream ktx_file(ktx_path, std::ios::binary);
            std::ofstream btx_file(normalized_btx_path, std::ios::binary);
            btx_file.write("\x02\x00\x00\x00", 4);
            btx_file << ktx_file.rdbuf();
            if (!ktx_file) {
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
    } catch (const std::exception& e) {
        logger.error("Failed to convert PNG to BTX: " + std::string(e.what()));
        return false;
    }
}

// Автоматически определяет тип файла и конвертирует
bool convert_auto_btx_and_png(const std::string& input_path, Logger& logger) {
    try {
        std::string normalized_path = input_path;
        std::replace(normalized_path.begin(), normalized_path.end(), '\\', '/');

        logger.info("Starting conversion for: " + normalized_path);

        if (!fs::exists(normalized_path)) {
            logger.error("File not found: " + normalized_path);
            return false;
        }

        fs::path input_file_path(normalized_path);
        std::string extension = input_file_path.extension().string();
        std::transform(extension.begin(), extension.end(), extension.begin(), ::tolower);

        fs::path output_dir = input_file_path.parent_path() / "converted";
        if (!fs::exists(output_dir)) {
            fs::create_directories(output_dir);
        }

        if (extension == ".btx") {
            std::string output_path = (output_dir / (input_file_path.stem().string() + ".png")).string();
            std::replace(output_path.begin(), output_path.end(), '\\', '/');

            logger.info("Converting BTX to PNG: " + normalized_path + " -> " + output_path);

            std::string result = convert_btxtopng(normalized_path, output_path, logger);
            if (!result.empty()) {
                logger.info("Successfully converted BTX to PNG: " + output_path);
                std::cout << "Successfully converted to: " << output_path << std::endl;
                return true;
            }
            else {
                logger.error("Failed to convert BTX to PNG: " + normalized_path);
                return false;
            }
        }

        else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg") {
            std::string output_path = (output_dir / (input_file_path.stem().string() + ".btx")).string();
            std::replace(output_path.begin(), output_path.end(), '\\', '/');

            logger.info("Converting image to BTX: " + normalized_path + " -> " + output_path);

            bool result = convert_png_to_btx(normalized_path, output_path, logger);
            if (result) {
                logger.info("Successfully converted image to BTX: " + output_path);
                std::cout << "Successfully converted to: " << output_path << std::endl;
                return true;
            }
            else {
                logger.error("Failed to convert image to BTX: " + normalized_path);
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