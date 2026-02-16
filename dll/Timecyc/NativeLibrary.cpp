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

extern "C" NATIVELIBRARY_API
bool KoTeK_Timecyc(
    const char* saveDirPath,
    const char* folderName,
    const char* hex_up,
    const char* hex_down,
    const char* hex_cloud,
    const char* hex_sun
) {

    if (!saveDirPath || !folderName || !hex_up || !hex_down || !hex_cloud || !hex_sun) {
        return false;
    }

    int r_up, g_up, b_up;
    int r_down, g_down, b_down;
    int r_cloud, g_cloud, b_cloud;
    int r_sun, g_sun, b_sun;

    if (!HexToRGB(hex_up, r_up, g_up, b_up) ||
        !HexToRGB(hex_down, r_down, g_down, b_down) ||
        !HexToRGB(hex_cloud, r_cloud, g_cloud, b_cloud) ||
        !HexToRGB(hex_sun, r_sun, g_sun, b_sun)) {
        return false;
    }

    std::string jsonContent = LoadResourceAsString(IDR_RCDATA1);
    if (jsonContent.empty()) {
        return false;
    }

    fs::path outputDir = fs::u8path(saveDirPath) / fs::u8path(folderName);
    if (!fs::exists(outputDir)) {
        std::error_code ec;
        if (!fs::create_directory(outputDir, ec)) {
            return false;
        }
    }

    // Замена шаблонов
    ReplaceText(jsonContent, "skbr", std::to_string(r_up));
    ReplaceText(jsonContent, "skbg", std::to_string(g_up));
    ReplaceText(jsonContent, "skbb", std::to_string(b_up));

    ReplaceText(jsonContent, "sktr", std::to_string(r_down));
    ReplaceText(jsonContent, "sktg", std::to_string(g_down));
    ReplaceText(jsonContent, "sktb", std::to_string(b_down));

    ReplaceText(jsonContent, "scr", std::to_string(r_cloud));
    ReplaceText(jsonContent, "scg", std::to_string(g_cloud));
    ReplaceText(jsonContent, "scb", std::to_string(b_cloud));

    ReplaceText(jsonContent, "clr", std::to_string(r_sun));
    ReplaceText(jsonContent, "clg", std::to_string(g_sun));
    ReplaceText(jsonContent, "clb", std::to_string(b_sun));

    fs::path outputPath = outputDir / "timecyc.json";
    std::ofstream outFile(outputPath, std::ios::binary);
    if (!outFile.is_open()) {
        return false;
    }
    outFile << jsonContent;
    outFile.close();

    return true;
}