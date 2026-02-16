#include "pch.h"
#define NATIVELIBRARY_EXPORTS
#include "NativeLibrary.h"
#include <string>
#include <vector>
#include <fstream>
#include <filesystem>
#include <ctime>
#include <cstdlib>
#include <algorithm>
#include <zip.h>
#include "btx_editor.h"
#include <random>

namespace fs = std::filesystem;

std::string GenerateRandomNameZip()
{
    const std::string CHARACTERS
        = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    std::random_device rd;
    std::mt19937 generator(rd());

    std::uniform_int_distribution<> distribution(
        0, CHARACTERS.size() - 1);

    std::string random_string;
    for (int i = 0; i < 5; ++i) {
        random_string
            += CHARACTERS[distribution(generator)];
    }

    return random_string;
}

extern "C" __declspec(dllexport)
bool KoTeK_ConvertBtxAndPack(
    const char* FilePath[],
    const char* saveDirPath,
    const char* folderName,
    const char* compress,
    const char* quality,
    int FileCout,
    bool zip_yes_no
);

extern "C" NATIVELIBRARY_API
bool KoTeK_ConvertBtxAndPack(
    const char* FilePath[],
    const char* saveDirPath,
    const char* folderName,
    const char* compress,
    const char* quality,
    int FileCout,
    bool zip_yes_no
) {
    std::string outputDir = (fs::path(saveDirPath) / folderName).string();
    fs::path full_path = fs::path(saveDirPath) / fs::path(folderName);
    std::vector<fs::path> filePaths;
    for (int i = 0; i < FileCout; ++i) {
        filePaths.push_back(FilePath[i]);
    }

    for (const auto& filePath : filePaths) {
        fs::path ext = filePath.extension();
        Logger logger("conversion_log.txt");

        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg") {
            fs::path outputPath = full_path / "btx" / (filePath.stem().string() + ".btx");
            convert_auto_btx_and_png(filePath.string(), outputPath.string(), compress, quality, logger);
        }
        else if (ext == ".btx") {
            fs::path outputPath = full_path / "png" / (filePath.stem().string() + ".png");
            convert_auto_btx_and_png(filePath.string(), outputPath.string(), compress, quality, logger);
        }
    }

    if (zip_yes_no) {
        fs::path zipPath = full_path;
        zipPath += "kotek_convert" + GenerateRandomNameZip() + ".zip";

        zip_t* zip = zip_open(zipPath.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, nullptr);
        if (zip) {
            for (const auto& filePath : filePaths) {
                if (filePath.extension() == ".png" || filePath.extension() == ".jpg") {
                    fs::path newPath = filePath;
                    newPath.replace_extension(".btx");

                    std::string filename = newPath.filename().string();

                    fs::path EndPath = full_path / "btx" / filename;


                    fs::path nameInZip = EndPath.filename();
                    zip_source_t* src = zip_source_file(zip, EndPath.string().c_str(), 0, 0);
                    if (src) {
                        zip_file_add(zip, nameInZip.string().c_str(), src, ZIP_FL_ENC_UTF_8);
                    }
                    else {
                        zip_source_free(src);
                    }
                }
                else if (filePath.extension() == ".btx") {
                    fs::path newPath = filePath;
                    newPath.replace_extension(".png");

                    std::string filename = newPath.filename().string();

                    fs::path EndPath = full_path / "png" / filename;


                    fs::path nameInZip = EndPath.filename();
                    zip_source_t* src = zip_source_file(zip, EndPath.string().c_str(), 0, 0);
                    if (src) {
                        zip_file_add(zip, nameInZip.string().c_str(), src, ZIP_FL_ENC_UTF_8);
                    }
                    else {
                        zip_source_free(src);
                    }
                }
            }
        }
        zip_close(zip);
    }
    return true;
}

extern "C" NATIVELIBRARY_API int TestFunction() {
    return 131;
}