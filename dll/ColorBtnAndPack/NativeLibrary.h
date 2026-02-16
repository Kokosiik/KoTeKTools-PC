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

    extern "C" NATIVELIBRARY_API bool KoTeK_ColorBTNAndPack
    (
        const char* saveDirPath,
        const char* folderName,
        const char* hexColor,
        bool zip_yes_no
    );

    NATIVELIBRARY_API int TestFunction();

#ifdef __cplusplus
}
#endif