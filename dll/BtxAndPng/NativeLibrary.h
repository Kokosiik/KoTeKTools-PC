#pragma once

#ifdef _WIN32
#ifdef NATIVELIBRARY_EXPORTS
#define NATIVELIBRARY_API __declspec(dllexport)
#else
#define NATIVELIBRARY_API __declspec(dllimport)
#endif
#else
#define NATIVELIBRARY_API
#endif

#ifdef __cplusplus
extern "C" {
#endif

    extern "C" NATIVELIBRARY_API bool KoTeK_ConvertBtxAndPack(
        const char* FilePath[],
        const char* saveDirPath,
        const char* folderName,
        const char* compress,
        const char* quality,
        int FileCout,
        bool zip_yes_no
    );

    NATIVELIBRARY_API int TestFunction();

#ifdef __cplusplus
}
#endif