#include "pch.h"
#define NATIVELIBRARY_EXPORTS

#include "NativeLibrary.h"
#include <string>
#include <fstream>
#include <filesystem>
#include <vector>
#include <sstream>
#include <algorithm>
#include <zip.h>
#include <iomanip>

#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"
#define STB_IMAGE_WRITE_IMPLEMENTATION
#include "stb_image_write.h"

namespace fs = std::filesystem;

extern "C" NATIVELIBRARY_API
bool KoTeK_CutMap(
    const char* ImagePath,
    const char* saveDirPath,
    const char* folderName,
    bool zip_yes_no
) {
    std::string outputDir = (fs::path(saveDirPath) / folderName).string();
    fs::path fullpath = fs::path(saveDirPath) / fs::path(folderName);
    std::string zip_name = (fullpath / "kotek_map.zip").string();

    if (fs::exists(fullpath)) {
        fs::remove_all(fullpath);
    }
    fs::create_directory(fullpath);

    int w, h, c;
    unsigned char* data = stbi_load(ImagePath, &w, &h, &c, 0);

    if (!data) {
        return false;
    }

    size_t targetW = 14;
    size_t targetH = 14;

    int partW = (w + targetW - 1) / targetW;
    int partH = (h + targetH - 1) / targetH;

    int partsX = (w + partW - 1) / partW;
    int partsY = (h + partH - 1) / partH;

    for (int partY = 0; partY < partsY; partY++) {
        for (int partX = 0; partX < partsX; partX++) {

            int startX = partX * partW;
            int startY = partY * partH;
            int lastPw = min(partW, w - startX);
            int lastPh = min(partH, h - startY);
            int Index = partY * partsX + partX;
            std::vector<unsigned char> PartData(lastPw * lastPh * c);

            for (int y = 0; y < lastPh; y++) {
                for (int x = 0; x < lastPw; x++) {
                    int FirstIn = ((startY + y) * w + (startX + x)) * c;
                    int EndIn = (y * lastPw + x) * c;

                    for (int Call = 0; Call < c; Call++) {
                        PartData[EndIn + Call] = data[FirstIn + Call];
                    }
                }
            }

            std::ostringstream filename;
            filename << "radar"
                << std::setw(2) << std::setfill('0') << Index
                << ".png";

            fs::path partPath = fullpath / filename.str();

            stbi_write_png(partPath.string().c_str(),
                lastPw, lastPh, c, PartData.data(), lastPw * c);
        }
    }

    if (zip_yes_no) {
        zip_t* zip_archive = zip_open(zip_name.c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);
        if (!zip_archive) {
            stbi_image_free(data);
            return false;
        }

        std::vector<std::string> Map;

        for (const auto& ent : fs::directory_iterator(fullpath)) {
            if (ent.is_regular_file()) {
                std::string filename = ent.path().filename().string();
                if (filename != "kotek_map.zip") {
                    Map.push_back(filename);
                }
            }
        }

        for (const auto& Mapfile : Map) {
            fs::path filepath = fs::path(fullpath) / Mapfile;

            std::ifstream file(filepath, std::ios::binary | std::ios::ate);
            if (!file.is_open()) {
                continue;
            }

            zip_source_t* zip_source = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
            if (!zip_source) {
                continue;
            }

            if (zip_file_add(zip_archive, Mapfile.c_str(), zip_source, ZIP_FL_ENC_UTF_8) < 0) {
                zip_source_free(zip_source);
            }
        }

        zip_close(zip_archive);

        for (const auto& ent : Map) {
            fs::remove(fs::path(fullpath) / ent);
        }

        stbi_image_free(data);
    }
    else {
        stbi_image_free(data);
    }

    return true;
}