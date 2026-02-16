#pragma once
#include <string>
#include <fstream>

#ifdef _WIN32
#ifdef BTX_EDITOR_EXPORTS
#define BTX_EDITOR_API __declspec(dllexport)
#else
#define BTX_EDITOR_API __declspec(dllimport)
#endif
#define BTX_EDITOR_API __declspec(dllimport)
#else
#define BTX_EDITOR_API
#endif

class BTX_EDITOR_API Logger {
private:
    std::ofstream log_file;
    std::string get_current_time();

public:
    Logger(const std::string& filename);
    ~Logger();
    void info(const std::string& message);
    void error(const std::string& message);
    void warning(const std::string& message);
};

BTX_EDITOR_API std::string convert_btxtopng(const std::string& btx_path, const std::string& output_png_path, Logger& logger);
BTX_EDITOR_API bool convert_png_to_btx(const std::string& png_path, const std::string& btx_path, const std::string& compress_mode, const std::string& quality_mode, Logger& logger);
BTX_EDITOR_API bool convert_auto_btx_and_png(const std::string& input_path, const std::string& output_path, const std::string& compress_mode, const std::string& quality_mode, Logger& logger);