#pragma once

#ifdef NATIVELIBRARY_EXPORTS
#define NATIVELIBRARY_API __declspec(dllexport)
#else
#define NATIVELIBRARY_API __declspec(dllimport)
#endif

extern "C" {
    NATIVELIBRARY_API char** KoTeK_UnPackZip(
        const char** zipFilePaths,  // массив путей к ZIP файлам
        int fileCount,              // количество ZIP файлов
        const char* extractPath,    // папка для распаковки
        bool createSubfolders       // создавать подпапки для каждого ZIP
    );

    NATIVELIBRARY_API void KoTeK_FreeMemory(char** array);

    NATIVELIBRARY_API int TestFunction();
}