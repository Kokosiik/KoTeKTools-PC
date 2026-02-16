#include "pch.h"
#define NATIVELIBRARY_EXPORTS
#include "NativeLibrary.h"
#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <filesystem>
#include <zip.h>
#include <cstring>
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"
#define STB_IMAGE_WRITE_IMPLEMENTATION
#include "stb_image_write.h"

namespace fs = std::filesystem;

bool IsNvidiaGPUAvailable() {
    int deviceCount = 0;
    cudaError_t error = cudaGetDeviceCount(&deviceCount);

    if (error != cudaSuccess || deviceCount == 0) {
        return false;
    }

    for (int i = 0; i < deviceCount; ++i) {
        cudaDeviceProp prop;
        cudaGetDeviceProperties(&prop, i);

        std::string deviceName(prop.name);
        if (deviceName.find("NVIDIA") != std::string::npos || deviceName.find("GeForce") != std::string::npos || deviceName.find("Tesla") != std::string::npos) {
            return true;
        }
    }

    return false;
}

void Colors(unsigned char* image, unsigned char* h_input, int w, int h, float r, float g, float b);

void ColorsCPU(unsigned char* image, unsigned char* output, int w, int h, float r, float g, float b) {
    int total_pixels = w * h;
    for (int idx = 0; idx < total_pixels; ++idx) {
        float lum = image[idx * 4 + 0] * 0.299f + image[idx * 4 + 1] * 0.587f + image[idx * 4 + 2] * 0.114f;
        float inv255 = 1.0f / 255.0f;
        lum *= inv255;

        output[idx * 4 + 0] = static_cast<unsigned char>(lum * r); // R
        output[idx * 4 + 1] = static_cast<unsigned char>(lum * g); // G
        output[idx * 4 + 2] = static_cast<unsigned char>(lum * b); // B
        output[idx * 4 + 3] = image[idx * 4 + 3];                 // Alpha
    }
}

extern "C" __declspec(dllexport)
bool KoTeK_ColorAndPack(
    const char* imagePaths[],
    const char* saveDirPath,
    const char* folderName,
    const char* hex,
    int fileCount,
    bool zip_yes_no
);

extern "C" NATIVELIBRARY_API
bool KoTeK_ColorAndPack
(
    const char* imagePaths[],
    const char* saveDirPath,
    const char* folderName,
    const char* hex,
    int fileCount,
    bool zip_yes_no
) {
    std::string outputDir = (fs::path(saveDirPath) / folderName).string();
    fs::path fullpath = fs::path(saveDirPath) / fs::path(folderName);
    if (!fs::exists(fullpath)) {
        fs::create_directory(fullpath);
    }

    std::string clearhex = hex;
    if (!clearhex.empty() && clearhex[0] == '#') {
        clearhex = clearhex.substr(1);
    }

    if (clearhex.length() != 6) {
        return false;
    }

    short r = std::stoi(clearhex.substr(0, 2), nullptr, 16);
    short g = std::stoi(clearhex.substr(2, 2), nullptr, 16);
    short b = std::stoi(clearhex.substr(4, 2), nullptr, 16);

    std::vector<fs::path> imagepath;

    for (int i = 0; i < fileCount; ++i) {
        imagepath.push_back(imagePaths[i]);
    }

    if (IsNvidiaGPUAvailable()) {
        for (int i = 0; i < fileCount; ++i) {
            if (!imagePaths[i]) continue;

            fs::path inputPath(imagePaths[i]);
            if (inputPath.extension() != ".png" && inputPath.extension() != ".jpg") {
                continue;
            }

            int w, h, c;
            unsigned char* image = stbi_load(inputPath.string().c_str(), &w, &h, &c, 4);
            if (!image || w <= 0 || h <= 0) {
                if (image) stbi_image_free(image);
                continue;
            }

            std::vector<unsigned char> newcolor(w * h * 4);
            Colors(image, newcolor.data(), w, h,
                static_cast<float>(r),
                static_cast<float>(g),
                static_cast<float>(b));

            fs::path outputPath = outputDir / inputPath.filename();
            stbi_write_png(outputPath.string().c_str(), w, h, 4, newcolor.data(), w * 4);
            stbi_image_free(image);

            imagepath.push_back(outputPath);
        }

        if (zip_yes_no && !imagepath.empty()) {
            fs::path zipPath = outputDir;
            zipPath += ".zip";

            zip_t* zip = zip_open(zipPath.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, nullptr);
            if (zip) {
                for (const auto& filePath : imagepath) {
                    std::string nameInZip = filePath.filename().string();
                    zip_source_t* src = zip_source_file(zip, filePath.string().c_str(), 0, 0);
                    if (src) {
                        zip_file_add(zip, nameInZip.c_str(), src, ZIP_FL_ENC_UTF_8);
                    }
                    else {
                        zip_source_free(src);
                    }
                }
                zip_close(zip);

                for (const auto& name : imagepath) {
                    if (fs::exists(name)) {
                        fs::remove(name);
                    }
                }
            }
        }
        return true;
    }
    else {
        for (int i = 0; i < fileCount; ++i) {
            if (!imagePaths[i]) continue;

            fs::path inputPath(imagePaths[i]);
            if (inputPath.extension() != ".png" && inputPath.extension() != ".jpg") {
                continue;
            }

            int w, h, c;
            unsigned char* image = stbi_load(inputPath.string().c_str(), &w, &h, &c, 4);
            if (!image || w <= 0 || h <= 0) {
                if (image) stbi_image_free(image);
                continue;
            }

            std::vector<unsigned char> newcolor(w * h * 4);
            ColorsCPU(image, newcolor.data(), w, h,
                static_cast<float>(r),
                static_cast<float>(g),
                static_cast<float>(b));

            fs::path outputPath = outputDir / inputPath.filename();
            stbi_write_png(outputPath.string().c_str(), w, h, 4, newcolor.data(), w * 4);
            stbi_image_free(image);

            imagepath.push_back(outputPath);
        }

        if (zip_yes_no && !imagepath.empty()) {
            fs::path zipPath = outputDir;
            zipPath += ".zip";

            zip_t* zip = zip_open(zipPath.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, nullptr);
            if (zip) {
                for (const auto& filePath : imagepath) {
                    std::string nameInZip = filePath.filename().string();
                    zip_source_t* src = zip_source_file(zip, filePath.string().c_str(), 0, 0);
                    if (src) {
                        zip_file_add(zip, nameInZip.c_str(), src, ZIP_FL_ENC_UTF_8);
                    }
                    else {
                        zip_source_free(src);
                    }
                }
                zip_close(zip);

                for (const auto& name : imagepath) {
                    if (fs::exists(name)) {
                        fs::remove(name);
                    }
                }
            }
        }
        return true;
    }
}

extern "C" NATIVELIBRARY_API int TestFunction() {
    return 131;
}