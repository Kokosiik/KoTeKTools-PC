#pragma once
#include <string>
#include <fstream>
#include <filesystem>

class Logger {
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

std::string convert_btxtopng(const std::string& btx_path, const std::string& output_path, Logger& logger);
bool convert_png_to_btx(const std::string& png_path, const std::string& btx_path, Logger& logger);
bool convert_between_btx_and_image(const std::string& input_path, Logger& logger);