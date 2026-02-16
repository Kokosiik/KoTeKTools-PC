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

namespace fs = std::filesystem;

char** CreateStringArray(const std::vector<std::string>& strings)
{
    if (strings.empty())
    {
        char** result = new char* [1];
        result[0] = nullptr;
        return result;
    }

    char** result = new char* [strings.size() + 1]; // +1 для nullptr в конце

    for (size_t i = 0; i < strings.size(); i++)
    {
        result[i] = new char[strings[i].size() + 1];
        strcpy_s(result[i], strings[i].size() + 1, strings[i].c_str());
    }

    result[strings.size()] = nullptr; // Маркер конца массива
    return result;
}

void FreeStringArray(char** array)
{
    if (!array) return;

    for (int i = 0; array[i] != nullptr; i++)
    {
        delete[] array[i];
    }

    delete[] array;
}

bool UnpackSingleZip(const char* zipFilePath, const char* extractPath,
    std::vector<std::string>& extractedFiles,
    const std::string& subfolder = "")
{
    try
    {
        fs::path zipPath(zipFilePath);
        fs::path extractDir(extractPath);

        // Добавляем подпапку если указана
        if (!subfolder.empty())
        {
            extractDir = extractDir / subfolder;
        }

        // Проверяем существует ли ZIP файл
        if (!fs::exists(zipPath) || zipPath.extension() != ".zip")
            return false;

        // Создаем папку для распаковки
        if (!fs::exists(extractDir))
        {
            fs::create_directories(extractDir);
        }

        // Открываем ZIP архив
        int error = 0;
        zip_t* archive = zip_open(zipFilePath, 0, &error);

        if (!archive)
            return false;

        // Получаем количество файлов в архиве
        zip_int64_t numEntries = zip_get_num_entries(archive, 0);

        // Распаковываем каждый файл
        for (zip_int64_t i = 0; i < numEntries; ++i)
        {
            const char* name = zip_get_name(archive, i, 0);
            if (!name) continue;

            std::string fileName(name);

            // Пропускаем папки
            if (!fileName.empty() && fileName.back() == '/')
                continue;

            // Создаем полный путь для распакованного файла
            fs::path fullPath = extractDir / fs::path(fileName);

            // Создаем папки для файла, если нужно
            fs::path parentDir = fullPath.parent_path();
            if (!parentDir.empty() && !fs::exists(parentDir))
            {
                fs::create_directories(parentDir);
            }

            // Открываем файл в архиве
            zip_file_t* file = zip_fopen_index(archive, i, 0);
            if (!file) continue;

            // Получаем информацию о файле
            zip_stat_t stat;
            zip_stat_init(&stat);
            zip_stat_index(archive, i, 0, &stat);

            // Читаем данные
            std::vector<char> buffer(stat.size);
            zip_int64_t bytesRead = zip_fread(file, buffer.data(), stat.size);
            zip_fclose(file);

            if (bytesRead > 0)
            {
                // Сохраняем файл
                std::ofstream outFile(fullPath, std::ios::binary);
                outFile.write(buffer.data(), bytesRead);
                outFile.close();

                // Добавляем путь к файлу в список
                extractedFiles.push_back(fullPath.string());
            }
        }

        // Закрываем архив
        zip_close(archive);
        return true;
    }
    catch (...)
    {
        return false;
    }
}

extern "C" __declspec(dllexport)
char** KoTeK_UnPackZip(
    const char** zipFilePaths,  // массив путей к ZIP файлам
    int fileCount,              // количество ZIP файлов
    const char* extractPath,    // папка для распаковки
    bool createSubfolders = false  // создавать подпапки для каждого ZIP
)
{
    std::vector<std::string> allExtractedFiles;

    try
    {
        // Если нет файлов - возвращаем пустой массив
        if (fileCount <= 0 || !zipFilePaths)
        {
            return CreateStringArray(allExtractedFiles);
        }

        fs::path extractDir(extractPath);

        // Создаем основную папку, если её нет
        if (!fs::exists(extractDir))
        {
            fs::create_directories(extractDir);
        }

        // Обрабатываем каждый ZIP файл
        for (int i = 0; i < fileCount; ++i)
        {
            const char* zipFilePath = zipFilePaths[i];
            if (!zipFilePath) continue;

            std::string subfolder = "";

            // Если нужно создавать подпапки и файлов больше одного
            if (createSubfolders && fileCount > 1)
            {
                // Используем имя ZIP файла без расширения как имя подпапки
                fs::path zipPath(zipFilePath);
                subfolder = zipPath.stem().string();
            }

            // Распаковываем ZIP
            std::vector<std::string> zipFiles;
            if (UnpackSingleZip(zipFilePath, extractPath, zipFiles, subfolder))
            {
                // Добавляем все файлы из этого ZIP в общий список
                allExtractedFiles.insert(allExtractedFiles.end(),
                    zipFiles.begin(), zipFiles.end());
            }
        }

        // Создаем и возвращаем массив путей
        return CreateStringArray(allExtractedFiles);
    }
    catch (...)
    {
        // В случае ошибки возвращаем пустой массив
        return CreateStringArray(allExtractedFiles);
    }
}

// Функция освобождения памяти
extern "C" __declspec(dllexport)
void KoTeK_FreeMemory(char** array)
{
    FreeStringArray(array);
}

// Для удобства - перегрузка для одного файла (необязательно)
extern "C" __declspec(dllexport)
char** KoTeK_UnPackZipSingle(const char* zipFilePath, const char* extractPath)
{
    const char* singleFile[] = { zipFilePath };
    return KoTeK_UnPackZip(singleFile, 1, extractPath, false);
}

extern "C" NATIVELIBRARY_API int TestFunction() {
    return 131;
}