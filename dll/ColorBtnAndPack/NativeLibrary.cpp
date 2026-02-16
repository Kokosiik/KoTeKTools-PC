#include "pch.h"
#include "resource.h"
#define NATIVELIBRARY_EXPORTS
#include "NativeLibrary.h"
#include <windows.h>
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

const char* g_PngNames[] = {
    "accelerate.png",               // IDB_PNG1
    "brake.png",                    // IDB_PNG2
    "Brown.png",                    // IDB_PNG3
    "cam-toggle.png",               // IDB_PNG4
    "crane_down.png",               // IDB_PNG5
    "crane_top.png",                // IDB_PNG6
    "handbrake.png",                // IDB_PNG7
    "horn.png",                     // IDB_PNG8
    "hud_arrow_left.png",           // IDB_PNG9
    "hud_arrow_right.png",          // IDB_PNG10
    "hud_bike.png",                 // IDB_PNG11
    "hud_boat.png",                 // IDB_PNG12
    "hud_car.png",                  // IDB_PNG13
    "hud_chopper.png",              // IDB_PNG14
    "hud_circle.png",               // IDB_PNG15
    "hud_daily_case.png",           // IDB_PNG16
    "hud_daily_case_active.png",    // IDB_PNG17
    "hud_dildo2.png",               // IDB_PNG18
    "hud_lockon.png",               // IDB_PNG19
    "hud_monstertruck.png",         // IDB_PNG20
    "hud_nitro.png",                // IDB_PNG21
    "hud_swim.png",                 // IDB_PNG22
    "leftshoot.png",                // IDB_PNG23
    "punch.png",                    // IDB_PNG24
    "radio_widget.png",             // IDB_PNG25
    "shoot.png",                    // IDB_PNG26
    "sprint.png",                   // IDB_PNG27
    "WidgetGetIn.png"               // IDB_PNG28
};

const UINT g_PngResourceIDs[] = {
    IDB_PNG1, IDB_PNG2, IDB_PNG3, IDB_PNG4, IDB_PNG5,
    IDB_PNG6, IDB_PNG7, IDB_PNG8, IDB_PNG9, IDB_PNG10,
    IDB_PNG11, IDB_PNG12, IDB_PNG13, IDB_PNG14, IDB_PNG15,
    IDB_PNG16, IDB_PNG17, IDB_PNG18, IDB_PNG19, IDB_PNG20,
    IDB_PNG21, IDB_PNG22, IDB_PNG23, IDB_PNG24, IDB_PNG25,
    IDB_PNG26, IDB_PNG27, IDB_PNG28
};

const int g_ResourceCount = sizeof(g_PngResourceIDs) / sizeof(g_PngResourceIDs[0]);

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
        output[idx * 4 + 3] = image[idx * 4 + 3];                 // A
    }
}

bool LoadPNGFromResource(HMODULE hModule, UINT resourceID, void** outData, size_t* outSize) {
    HRSRC hResInfo = FindResource(hModule, MAKEINTRESOURCE(resourceID), L"PNG");
    if (!hResInfo) return false;

    HGLOBAL hResData = LoadResource(hModule, hResInfo);
    if (!hResData) return false;

    DWORD size = SizeofResource(hModule, hResInfo);
    void* data = LockResource(hResData);
    if (!data || size == 0) return false;

    void* copy = malloc(size);
    if (!copy) return false;
    memcpy(copy, data, size);

    *outData = copy;
    *outSize = static_cast<size_t>(size);
    return true;
}

extern "C" __declspec(dllexport)
bool KoTeK_ColorBTNAndPack(
    const char* saveDirPath,
    const char* folderName,
    const char* hex,
    bool zip_yes_no
);

extern "C" NATIVELIBRARY_API
bool KoTeK_ColorBTNAndPack(
    const char* saveDirPath,
    const char* folderName,
    const char* hex,
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

    HMODULE hDll = nullptr;
    GetModuleHandleExW(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT,
        reinterpret_cast<LPCWSTR>(&KoTeK_ColorBTNAndPack), &hDll);
    if (!hDll) {
        return false;
    }

    std::vector<fs::path> outputFiles;

    auto processImage = [&](void* imageData, size_t imageSize, const std::string& filename) -> bool {
        int w, h, c;
        unsigned char* pixels = stbi_load_from_memory(
            static_cast<const stbi_uc*>(imageData),
            static_cast<int>(imageSize),
            &w, &h, &c, 4
        );
        if (!pixels || w <= 0 || h <= 0) {
            free(imageData);
            return false;
        }

        std::vector<unsigned char> newcolor(w * h * 4);
        if (IsNvidiaGPUAvailable()) {
            Colors(pixels, newcolor.data(), w, h,
                static_cast<float>(r),
                static_cast<float>(g),
                static_cast<float>(b));
        }
        else {
            ColorsCPU(pixels, newcolor.data(), w, h,
                static_cast<float>(r),
                static_cast<float>(g),
                static_cast<float>(b));
        }

        fs::path outputPath = fs::path(outputDir) / filename;
        stbi_write_png(outputPath.string().c_str(), w, h, 4, newcolor.data(), w * 4);
        stbi_image_free(pixels);
        free(imageData);

        outputFiles.push_back(outputPath);
        return true;
        };

    for (int i = 0; i < g_ResourceCount; ++i) {
        void* data = nullptr;
        size_t size = 0;
        if (!LoadPNGFromResource(hDll, g_PngResourceIDs[i], &data, &size)) {
            continue;
        }

        std::string filename = g_PngNames[i];
        processImage(data, size, filename);
    }

    if (zip_yes_no) {
        fs::path zipPath = fullpath / "kotek_button.zip";
        zip_t* zip = zip_open(zipPath.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, nullptr);
        if (zip) {
            for (const auto& filePath : outputFiles) {
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
        }
        for (const auto& f : outputFiles) {
            fs::remove(f);
        }
    }

    return true;
}

extern "C" NATIVELIBRARY_API int TestFunction() {
    return 131;
}