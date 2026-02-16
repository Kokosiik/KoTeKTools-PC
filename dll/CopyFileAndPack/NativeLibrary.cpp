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

namespace fs = std::filesystem;

extern "C" __declspec(dllexport)
bool KoTeK_CopyAndPack(
    const char* sourceFilePath,
    const char* saveDirPath,
    const char* folderName,
    const char* const* fileNames,
    int fileCount
);

extern "C" NATIVELIBRARY_API
bool KoTeK_CopyAndPack
(
    const char* sourceFilePath,
    const char* saveDirPath,
    const char* folderName,
    const char* const* fileNames,
    int fileCount
) {
    if (!fs::exists(sourceFilePath)) {
        return false;
    }

    fs::path outDir = fs::path(saveDirPath) / fs::path(folderName);
    fs::path outZip = fs::path(saveDirPath) / fs::path(folderName) / (std::string(folderName) + ".zip");

    if (fs::exists(outDir)) {
        fs::remove_all(outDir);
    }

    fs::create_directory(outDir);

    std::vector<std::string> names;
    for (int i = 0; i < fileCount; ++i) {
        if (!fileNames[i]) {
            fs::remove_all(outDir);
            return false;
        }
        names.push_back(fileNames[i]);
    }

    for (const auto& el : names) {
        fs::copy(sourceFilePath, outDir / el, fs::copy_options::overwrite_existing);
    }

    zip_t* archive = zip_open(outZip.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, nullptr);
    if (!archive) {
        fs::remove_all(outDir);
        return false;
    }

    bool success = true;
    for (const auto& name : names) {
        fs::path fullPath = outDir / name;
        zip_source_t* src = zip_source_file(archive, fullPath.string().c_str(), 0, 0);
        if (!src) {
            success = false;
            break;
        }
        zip_file_add(archive, name.c_str(), src, ZIP_FL_OVERWRITE);
    }

    zip_close(archive);

    for (const auto& el : names) {
        fs::path FilePath = outDir / fs::path(el);
        fs::remove(FilePath);
    }
}

extern "C" NATIVELIBRARY_API int TestFunction() {
    return 131;

}