#include "pch.h"
#include <windows.h>
#include "resource.h"
#define NATIVELIBRARY_EXPORTS
#include "NativeLibrary.h"
#include <string>
#include <fstream>
#include <filesystem>
#include <sstream>

HINSTANCE g_hInst = NULL;

namespace fs = std::filesystem;

void ReplaceText(std::string& str, const std::string& from, const std::string& to) {
    size_t start_pos = 0;
    while ((start_pos = str.find(from, start_pos)) != std::string::npos) {
        str.replace(start_pos, from.length(), to);
        start_pos += to.length();
    }
}

std::string LoadResourceAsString(UINT resourceID) {
    if (!g_hInst) {
        return {};
    }

    HRSRC hRes = FindResource(g_hInst, MAKEINTRESOURCE(resourceID), RT_RCDATA);
    if (!hRes) {
        return {};
    }

    HGLOBAL hData = LoadResource(g_hInst, hRes);
    if (!hData) {
        return {};
    }

    DWORD size = SizeofResource(g_hInst, hRes);
    if (size == 0) {
        return {};
    }

    const char* pData = static_cast<const char*>(LockResource(hData));
    return std::string(pData, size);
}

bool HexToRGB(const char* hex, int& r, int& g, int& b) {
    if (!hex) return false;
    std::string s = hex;
    if (!s.empty() && s[0] == '#') s = s.substr(1);
    if (s.length() != 6) return false;

    try {
        r = std::stoi(s.substr(0, 2), nullptr, 16);
        g = std::stoi(s.substr(2, 2), nullptr, 16);
        b = std::stoi(s.substr(4, 2), nullptr, 16);
        return true;
    }
    catch (...) {
        return false;
    }
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
        g_hInst = hModule;
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

extern "C" __declspec(dllexport)
bool KoTeK_Colorcycle(
    const char* saveDirPath,
    const char* folderName,
    const char* hex
);

extern "C" NATIVELIBRARY_API
bool KoTeK_Colorcycle(
    const char* saveDirPath,
    const char* folderName,
    const char* hex
) {
    if (!saveDirPath || !folderName || !hex) {
        return false;
    }

    int r, g, b;
    if (!HexToRGB(hex, r, g, b)) {
        return false;
    }

    std::string dataContent = LoadResourceAsString(IDR_RCDATA1);
    if (dataContent.empty()) {
        return false;
    }

    fs::path outputDir = fs::path(saveDirPath) / fs::path(folderName);
    std::error_code ec;
    if (!fs::exists(outputDir)) {
        if (!fs::create_directories(outputDir, ec)) {
            return false;
        }
    }

    ReplaceText(dataContent, "r0", std::to_string(r));
    ReplaceText(dataContent, "g0", std::to_string(g));
    ReplaceText(dataContent, "b0", std::to_string(b));

    fs::path outputPath = outputDir / "colorcycle.dat";
    std::ofstream outFile(outputPath, std::ios::binary);
    if (!outFile.is_open()) {
        return false;
    }
    outFile << dataContent;
    outFile.close();

    return true;
}