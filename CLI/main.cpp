#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <fstream>
#include <filesystem>
#include <string>
#include <vector>
#include <sstream>
#include <iomanip>
#include <direct.h>
#include <zip.h>
#include <cstdint>
#include <sys/stat.h>
#include "btx_editor.h"
#include "include/stb_image.h"
#include "include/stb_image_write.h"

using namespace std;
namespace fs = std::filesystem;

void Color(std::string hex, const std::string& imagePath);
void Button(std::string hex);
void Hp(std::string hex);
bool xor_file(const std::string& input_path, const std::string& output_path);
void Convert(const std::string& file_path);
void Map(const std::string& imagePath);
void CopyBild(std::string BildFile);
void CopyListva(std::string ListvaFile);
void CopyLogo(std::string LogoFile);
void ReplaceText(std::string& str, const std::string from, const std::string to);
void Tcyc(std::string hexupsk, std::string hexdownsk, std::string hexcloud, std::string hexsun);
void Ccyc(std::string hex);
void converted(const std::string filePath);
bool check(const std::string path);
bool convert_auto_btx_and_png(const std::string& input_path, Logger& logger);
extern "C" void Colored(uint8_t* input, uint8_t* output, int w, int h, int r, int g, int b);
struct RGB;
struct FileResult;
const uint8_t XOR_KEY[] = { 0x31, 0x63, 0x4B, 0x31, 0x61, 0x35, 0x55, 0x46, 0x32, 0x74, 0x55, 0x38, 0x2A, 0x47, 0x32, 0x6C, 0x57, 0x23, 0x26, 0x25 };
const size_t XOR_KEY_LENGTH = 20;

int main() {
    setlocale(LC_ALL, "RUS");
    int a;
    std::string b;
    std::string c;
    std::string upsk;
    std::string downsk;
    std::string cloud;
    std::string sun;

    std::cout << "Введите что хотите использовать:\n";
    std::cout << "1. Билдбоард\n";
    std::cout << "2. Листва\n";
    std::cout << "3. Логотипы\n";
    std::cout << "4. Создание карты\n";
    std::cout << "5. Таймсус\n";
    std::cout << "6. Колорсус\n";
    std::cout << "7. Покраска\n";
    std::cout << "8. Покраска кнопок\n";
    std::cout << "9. Покраска хп\n";
    std::cout << "10. bpc <=> zip\n";
    std::cout << "11. BTX <=> PNG/JPG/ZIP\n";
    std::cout << "-- ";
    cin >> a;

    switch (a) {
    case 1:
        std::cout << "Введите файл для создания Билдборда: ";
        cin >> b;
        if (!check(b)) {
            std::cout << "Файла: " << b << " не существует!" << std::endl;
            break;
        }
        CopyBild(b);
        break;
    case 2:
        std::cout << "Введите файл для создания Листвы: ";
        cin >> b;
        if (!check(b)) {
            std::cout << "Файла: " << b << " не существует!" << std::endl;
            break;
        }
        CopyListva(b);
        break;
    case 3:
        std::cout << "Введите файл для создания Логотипов: ";
        cin >> b;
        if (!check(b)) {
            std::cout << "Файла: " << b << " не существует!" << std::endl;
            break;
        }
        CopyLogo(b);
        break;
    case 4:
        std::cout << "Введите путь к картинке для создания карты: ";
        cin >> b;
        Map(b);
        break;
    case 5:
        std::cout << "Введите Hex для Таймсуса" << std::endl;
        std::cout << "Низ неба: ";
        cin >> downsk;
        std::cout << "Верх неба: ";
        cin >> upsk;
        std::cout << "Облака: ";
        cin >> cloud;
        std::cout << "Солнце: ";
        cin >> sun;
        Tcyc(upsk, downsk, cloud, sun);
        break;
    case 6:
        std::cout << "Введите Hex для Колорсуса: ";
        cin >> b;
        Ccyc(b);
        break;
    case 7:
        std::cout << "Введите Hex для покраски: ";
        cin >> b;
        std::cout << "Введите путь изображения: ";
        cin >> c;
        Color(b, c);
        break;
    case 8:
        std::cout << "Введите Hex для покраски: ";
        cin >> b;
        Button(b);
        break;
    case 9:
        std::cout << "Введите Hex для покраски: ";
        cin >> b;
        Hp(b);
        break;
    case 10:
        std::cout << "Введите путь к .bcp/.zip: ";
        cin >> b;
        Convert(b);
        break;
    case 11:
        std::cout << "Введите путь к файлу для конвертации (.btx, .png, .jpg, .zip): ";
        cin >> b;
        if (!check(b)) {
            std::cout << "Файла: " << b << " не существует!" << std::endl;
            break;
        }
        else {
            converted(b);
        }
        break;

    default:
        std::cout << "Неверный выбор!" << std::endl;
    }

    return 0;
}

struct RGB {
    int r, g, b;
};

RGB HexToRGB(const std::string hextorgb) {
    std::string Hex = hextorgb;
    if (!hextorgb.empty() && Hex[0] == '#')
        Hex = hextorgb.substr(1);

    if (Hex.length() != 6) {
        std::cout << "Ошибка: HEX должен содержать 6 символов" << std::endl;
        return RGB{ 0, 0, 0 };
    }

    RGB rgb;

    try {
        rgb.r = stoi(Hex.substr(0, 2), nullptr, 16);
        rgb.g = stoi(Hex.substr(2, 2), nullptr, 16);
        rgb.b = stoi(Hex.substr(4, 2), nullptr, 16);
    }
    catch (const exception& e) {
        std::cout << "Ошибка преобразования HEX: " << e.what() << std::endl;
        return RGB{ 0, 0, 0 };
    }

    return rgb;
}

struct FileResult {
    bool success;
    std::string message;
};

bool xor_file(const std::string& input_path, const std::string& output_path) {
    ifstream input_file(input_path, ios::binary);
    ofstream output_file(output_path, ios::binary);

    if (!input_file.is_open() || !output_file.is_open()) {
        return false;
    }

    vector<uint8_t> buffer((istreambuf_iterator<char>(input_file)),
        istreambuf_iterator<char>());

    for (size_t i = 0; i < buffer.size(); ++i) {
        buffer[i] ^= XOR_KEY[i % XOR_KEY_LENGTH];
    }

    output_file.write(reinterpret_cast<const char*>(buffer.data()), buffer.size());

    return true;
}

FileResult encrypt_zip_to_bpc(const std::string& zip_path, const std::string& bpc_path) {
    if (!xor_file(zip_path, bpc_path)) {
        return { false, "Ошибка шифрования файла" };
    }
    return { true, "Файл успешно запакован" };
}

FileResult decrypt_bpc_to_zip(const std::string& bpc_path, const std::string& zip_path) {
    if (!xor_file(bpc_path, zip_path)) {
        return { false, "Ошибка расшифровки файла" };
    }
    return { true, "Файл успешно распакован" };
}

void Convert(const std::string& file_path) {
    if (!check(file_path)) {
        std::cout << "Файла: " << file_path << " не существует!" << std::endl;
        return;
    }

    system("mkdir Bpc 2>nul");

    std::string output_file;
    FileResult result;

    if (file_path.find(".bpc") != std::string::npos || file_path.find(".BPC") != std::string::npos) {
        output_file = "Bpc/kotek_common.zip";
        result = decrypt_bpc_to_zip(file_path, output_file);
    }
    else if (file_path.find(".zip") != std::string::npos || file_path.find(".ZIP") != std::string::npos) {
        output_file = "Bpc/kotek_common.bpc";
        result = encrypt_zip_to_bpc(file_path, output_file);
    }
    else {
        std::cout << "Файл должен быть .bpc или .zip" << std::endl;
        return;
    }

    if (result.success) {
        std::cout << "Успех: " << result.message << std::endl;
        std::cout << "Результат сохранен в: " << output_file << std::endl;
    }
    else {
        std::cout << "Ошибка: " << result.message << std::endl;
    }
}

void Color(std::string hex, const std::string& imagePat) {
    fs::path imagePath(imagePat);

    if (imagePath.extension() == ".png" || imagePath.extension() == ".jpg") {
        std::string pathcolor = "Color";
        RGB color = HexToRGB(hex);
        int r = color.r;
        int g = color.g;
        int b = color.b;
        int w, h, c;
        unsigned char* image = stbi_load(imagePath.string().c_str(), &w, &h, &c, 4);

        if (!image) {
            std::cout << "Не удалось загрузить: " << imagePath;
            return;
        }

        fs::remove_all(pathcolor);
        fs::create_directories(pathcolor);

        vector<uint8_t> origcolor(w * h * 4);
        vector<uint8_t> newcolor(w * h * 4);

        for (int y = 0; y < h; ++y) {
            for (int x = 0; x < w; ++x) {
                int idx = (y * w + x) * 4;
                origcolor[idx] = image[idx];
                origcolor[idx + 1] = image[idx + 1];
                origcolor[idx + 2] = image[idx + 2];
                origcolor[idx + 3] = image[idx + 3];
            }
        }

        Colored(origcolor.data(), newcolor.data(), w, h, r, g, b);

        fs::path saveimage = fs::path(pathcolor) / fs::path(imagePath).filename();
        stbi_write_png(saveimage.string().c_str(), w, h, 4, newcolor.data(), w * 4);
        stbi_image_free(image);
    }

    else if (imagePath.extension() == ".zip") {
        fs::path pathres;
        fs::path folder = "Color";
        const char* name;

        if (fs::exists(folder)) {
            fs::remove_all(folder);
        }

        if (!fs::exists(folder)) {
            fs::create_directories(folder);
        }

        zip_t* archive = zip_open(imagePath.string().c_str(), 0, 0);

        if (!archive) {
			std::cout << "Не удалось открыть архив: " << imagePath << std::endl;
        }

        zip_int64_t num_ent = zip_get_num_entries(archive, 0);

        for (int8_t i = 0; i < num_ent; ++i) {
            name = zip_get_name(archive, i, 0);
            pathres = "Color" / fs::path(name);

            zip_file_t* file = zip_fopen_index(archive, i, 0);
            if (!file) {
				std::cout << "Не удалось открыть файл в архиве" << name << std::endl;
            }

            zip_stat_t stat;
            zip_stat_init(&stat);
            zip_stat_index(archive, i, 0, &stat);
            zip_uint64_t size = stat.size;

            vector<char> buffer(size);
            zip_fread(file, buffer.data(), size);
            zip_fclose(file);

            std::string str_name = name;
            if (str_name.back() == '/') {
                continue;
            }

            ofstream outzip(pathres, ios::binary);
            outzip.write(buffer.data(), size);
			outzip.close();
        }

        vector<std::string> files;
        for (const auto& ent : fs::directory_iterator(folder)) {
            if (ent.is_regular_file()) {
                files.push_back(ent.path().string());
            }
        }

        for (const auto& file : files) {
            RGB color = HexToRGB(hex);
            int w = 0, h = 0, c = 0;

            unsigned char* image = stbi_load(file.c_str(), &w, &h, &c, 4);
            if (!image) {
                std::cout << "Не удалось загрузить изображение из ZIP: " << file << std::endl;
                continue;
            }

            std::vector<uint8_t> origcolor(w * h * 4);
            std::vector<uint8_t> newcolor(w * h * 4);

            for (int y = 0; y < h; ++y) {
                for (int x = 0; x < w; ++x) {
                    int idx = (y * w + x) * 4;
                    origcolor[idx] = image[idx];
                    origcolor[idx + 1] = image[idx + 1];
                    origcolor[idx + 2] = image[idx + 2];
                    origcolor[idx + 3] = image[idx + 3];
                }
            }

            Colored(origcolor.data(), newcolor.data(), w, h, color.r, color.g, color.b);

            fs::path output_path = fs::path("Color") / fs::path(file).filename();
            stbi_write_png(output_path.string().c_str(), w, h, 4, newcolor.data(), w * 4);

            stbi_image_free(image);
        }

		fs::path zipname = "Color/kotek_color.zip";
        zip_t* zip_archive = zip_open(zipname.string().c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);

        for (const auto& ent : files) {
            fs::path filepath = fs::path("Color") / fs::path(ent).filename();
            zip_source_t* source = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
            if (!source) {
                cerr << "Не удалось создать источник для: " << filepath << std::endl;
                continue;
            }
            zip_file_add(zip_archive, filepath.filename().string().c_str(), source, ZIP_FL_ENC_UTF_8);
        }

        zip_close(archive);
        zip_close(zip_archive);

        for (const auto& ent : files) {
            fs::remove(ent);
        }

        fs::path zipf = "Color" / imagePath;
        fs::remove(zipf);
    }

    else {
		std::cout << "Формат не распознан: Можно использовать только .png, .jpg или .zip" << std::endl;
    }
}

void Button(std::string hex) {
    RGB color = HexToRGB(hex);
    std::string path = "Color";
    std::string buttonpath = path + "/Button";
    std::string name[] = {"Debug\\Brown.png", "Debug\\accelerate.png"};
    std::string zipname = buttonpath + "/kotek_button.zip";
    int w, h, c;

    if(fs::exists(buttonpath)) {
        fs::remove_all(buttonpath);
    }

    fs::create_directories(buttonpath);

    for (int i = 0; i < size(name); i++) {
        unsigned char* image = stbi_load(name[i].c_str(), &w, &h, &c, 4);

        if (!image) {
            continue;
        }

        vector<uint8_t> newcolor(w * h * 4);

        for (int y = 0; y < h; y++) {
            for (int x = 0; x < w; x++) {
                int idx = (y * w + x) * 4;

                uint8_t orig_r = image[idx];
                uint8_t orig_g = image[idx + 1];
                uint8_t orig_b = image[idx + 2];
                uint8_t orig_a = image[idx + 3];

                float lum = (orig_r * 0.299f + orig_g * 0.587f + orig_b * 0.114f) / 255.0f;

                newcolor[idx] = (uint8_t)(lum * color.r);
                newcolor[idx + 1] = (uint8_t)(lum * color.g);
                newcolor[idx + 2] = (uint8_t)(lum * color.b);
                newcolor[idx + 3] = orig_a;
            }
        }

        fs::path saveimage = fs::path(buttonpath) / fs::path(name[i]).filename();
        stbi_write_png(saveimage.string().c_str(), w, h, 4, newcolor.data(), w * 4);
        stbi_image_free(image);
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);

    for (int i = 0; i < size(name); i++) {
        fs::path filepath = fs::path(buttonpath) / fs::path(name[i]).filename();

        if (fs::exists(filepath)) {
            zip_source_t* source = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
            std::string filename = fs::path(name[i]).filename().string();
            zip_file_add(zip_archive, filename.c_str(), source, ZIP_FL_ENC_UTF_8);
        }
    }

    zip_close(zip_archive);

    for (const auto& ent : name) {
        fs::path filepath = fs::path(buttonpath) / fs::path(ent).filename();
        fs::remove(filepath);
    }
}

void Hp(std::string hex) {
    RGB color = HexToRGB(hex);
    std::string path = "Color";
    std::string hppath = path + "/Hp";
    std::string name[] = { "Debug\\Brown.png", "Debug\\accelerate.png" };
    std::string zipname = hppath + "/kotek_hp.zip";
    int w, h, c;

    if (fs::exists(hppath)) {
        fs::remove_all(hppath);
    }
    fs::create_directories(hppath);

    for (int i = 0; i < size(name); i++) {
        unsigned char* image = stbi_load(name[i].c_str(), &w, &h, &c, 4);

        if (!image) {
            continue;
        }

        vector<uint8_t> new_color(w * h * 4);

        for (int y = 0; y < h; y++) {
            for (int x = 0; x < w; x++) {
                int idx = (y * w + x) * 4;

                uint8_t orig_r = image[idx];
                uint8_t orig_g = image[idx + 1];
                uint8_t orig_b = image[idx + 2];
                uint8_t orig_a = image[idx + 3];

                float lum = (orig_r * 0.299f + orig_g * 0.587f + orig_b * 0.114f) / 255.0f;

                new_color[idx] = (uint8_t)(lum * color.r);
                new_color[idx + 1] = (uint8_t)(lum * color.g);
                new_color[idx + 2] = (uint8_t)(lum * color.b);
                new_color[idx + 3] = orig_a;
            }
        }
        fs::path saveimage = fs::path(hppath) / fs::path(name[i]).filename();
        stbi_write_png(saveimage.string().c_str(), w, h, 4, new_color.data(), w * 4);
        stbi_image_free(image);
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);

    for (int i = 0; i < size(name); i++) {
        fs::path filepath = fs::path(hppath) / fs::path(name[i]).filename();

        if (fs::exists(hppath)) {
            zip_source_t* source = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
            std::string filename = fs::path(name[i]).filename().string();
            zip_file_add(zip_archive, filename.c_str(), source, ZIP_FL_ENC_UTF_8);
        }
    }

    zip_close(zip_archive);

    for (const auto& ent : name) {
        fs::path filepath = fs::path(hppath) / fs::path(ent).filename();
        fs::remove(filepath);
    }
}

void Map(const std::string& imagePath) {
    std::string Mapdir = "Map";
    std::string zipname = Mapdir + "/Map.zip";

    int w, h, c;
    unsigned char* data = stbi_load(imagePath.c_str(), &w, &h, &c, 0);

    fs::remove_all(Mapdir);
    fs::create_directories(Mapdir);

    if (!data) {
        std::cout << "Ошибка загрузки изображения!";
        return;
    }

    size_t targetW = 14;
    size_t targetH = 14;

    int partW = (w + targetW - 1) / targetW;
    int partH = (h + targetH - 1) / targetH;

    int partsX = (w + partW - 1) / partW;
    int partsY = (h + partH - 1) / partH;

    std::cout << "Создаем " << partsX << "x" << partsY << " = "
        << partsX * partsY << " кусочков" << std::endl;

    for (int partY = 0; partY < partsY; partY++) {
        for (int partX = 0; partX < partsX; partX++) {

            int startX = partX * partW;
            int startY = partY * partH;
            int lastPw = min(partW, w - startX);
            int lastPh = min(partH, h - startY);
            int Index = partY * partsX + partX;
            vector<unsigned char> PartData(lastPw * lastPh * c);

            for (int y = 0; y < lastPh; y++) {
                for (int x = 0; x < lastPw; x++) {
                    int FirstIn = ((startY + y) * w + (startX + x)) * c;
                    int EndIn = (y * lastPw + x) * c;

                    for (int Call = 0; Call < c; Call++) {
                        PartData[EndIn + Call] = data[FirstIn + Call];
                    }
                }
            }

            std::stringstream filename;
            filename << Mapdir << "/radar"
                << std::setw(2) << std::setfill('0') << Index
                << ".png";

            stbi_write_png(filename.str().c_str(),
                lastPw, lastPh, c, PartData.data(), lastPw * c);
        }
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);
    if (!zip_archive) {
        stbi_image_free(data);
        return;
    }

    vector<std::string> Map;

    for (const auto& ent : fs::directory_iterator(Mapdir)) {
        if (ent.is_regular_file()) {
            std::string filename = ent.path().filename().string();
            if (filename != "Map.zip") {
                Map.push_back(filename);
            }
        }
    }

    for (const auto& Mapfile : Map) {
        fs::path filepath = fs::path(Mapdir) / Mapfile;

        ifstream file(filepath, ios::binary | ios::ate);
        if (!file.is_open()) {
            continue;
        }

        size_t size = file.tellg();
        file.seekg(0, ios::beg);

        vector<char> buffer(size);
        file.read(buffer.data(), size);

        zip_source_t* zip_source = zip_source_buffer(zip_archive, buffer.data(), size, 0);

        zip_file_add(zip_archive, Mapfile.c_str(), zip_source, ZIP_FL_ENC_UTF_8);

    }

    zip_close(zip_archive);

    for (const auto& ent : Map) {
        fs::path filepath = fs::path(Mapdir) / ent;
        if (ent != "Map.zip") {
            fs::remove(filepath);
        }

    }

    stbi_image_free(data);
}

void ReplaceText(std::string& str, const std::string from, const std::string to) {
    size_t start_pos = 0;
    while ((start_pos = str.find(from, start_pos)) != std::string::npos) {
        str.replace(start_pos, from.length(), to);
        start_pos += to.length();
    }
}

void Ccyc(std::string hex) {
    std::string CcycFile = "Debug\\cc.txt";
    std::string tempCcyc = "tempCcyc.txt";
    std::string line;
    std::string PathCcyc = "Colorcycle";

    ifstream Fileout(CcycFile);
    if (!Fileout.is_open()) {
        std::cout << "Не удалось открыть файл: " << CcycFile << std::endl;
        return;
    }

    ofstream Fileinp(tempCcyc);
    if (!Fileinp.is_open()) {
        Fileout.close();
        std::cout << "Не удалось создать временный файл: " << tempCcyc << std::endl;
        return;
    }

    RGB color = HexToRGB(hex);

    std::string r_value = std::to_string(color.r / 100.0f);
    std::string g_value = std::to_string(color.g / 100.0f);
    std::string b_value = std::to_string(color.b / 100.0f);

    if (r_value.length() > 5) r_value = r_value.substr(0, 5);
    if (g_value.length() > 5) g_value = g_value.substr(0, 5);
    if (b_value.length() > 5) b_value = b_value.substr(0, 5);

    while (getline(Fileout, line)) {
        ReplaceText(line, "r0", r_value);
        ReplaceText(line, "g0", g_value);
        ReplaceText(line, "b0", b_value);

        Fileinp << line << std::endl;
    }

    Fileout.close();
    Fileinp.close();

    if (!fs::exists(PathCcyc)) {
        fs::create_directories(PathCcyc);
    }

    fs::path CopyCcyc = fs::path(PathCcyc) / "colorcycle.dat";

    try {
        if (fs::exists(tempCcyc) && fs::file_size(tempCcyc) > 0) {
            fs::copy(tempCcyc, CopyCcyc, fs::copy_options::overwrite_existing);
            std::cout << "Колорсус: " << CopyCcyc << " изменен." << std::endl;
        }
    }
    catch (const exception& e) {
        std::cout << "Ошибка копирования файла: " << e.what() << std::endl;
    }

    if (fs::exists(tempCcyc)) {
        fs::remove(tempCcyc);
    }
}

void Tcyc(std::string hexupsk, std::string hexdownsk, std::string hexcloud, std::string hexsun) {
    std::string TcycFile = "Debug\\TCYC.json";
    std::string temptcyc = "temptcyc.txt";
    std::string line;
    std::string PathTcyc = "Timecyc";

    ifstream Fileout(TcycFile);
    if (!Fileout.is_open()) {
        std::cout << "Не удалось открыть файл: " << TcycFile << std::endl;
        return;
    }

    ofstream Fileinp(temptcyc);
    if (!Fileinp.is_open()) {
        Fileout.close();
        std::cout << "Не удалось создать временный файл: " << temptcyc << std::endl;
        return;
    }

    RGB colorupsk = HexToRGB(hexupsk);
    RGB colordownsk = HexToRGB(hexdownsk);
    RGB colorcloud = HexToRGB(hexcloud);
    RGB colorsun = HexToRGB(hexsun);

    while (getline(Fileout, line)) {
        // Вверх неба
        ReplaceText(line, "skbr", std::to_string(colorupsk.r));
        ReplaceText(line, "skbg", std::to_string(colorupsk.g));
        ReplaceText(line, "skbb", std::to_string(colorupsk.b));

        // Низ неба
        ReplaceText(line, "sktr", std::to_string(colordownsk.r));
        ReplaceText(line, "sktg", std::to_string(colordownsk.g));
        ReplaceText(line, "sktb", std::to_string(colordownsk.b));

        // Облака
        ReplaceText(line, "scr", std::to_string(colorcloud.r));
        ReplaceText(line, "scg", std::to_string(colorcloud.g));
        ReplaceText(line, "scb", std::to_string(colorcloud.b));

        // Солнце
        ReplaceText(line, "clr", std::to_string(colorsun.r));
        ReplaceText(line, "clg", std::to_string(colorsun.g));
        ReplaceText(line, "clb", std::to_string(colorsun.b));

        Fileinp << line << std::endl;
    }

    Fileout.close();
    Fileinp.close();

    if (!fs::exists(PathTcyc)) {
        fs::create_directories(PathTcyc);
    }

    fs::path CopyTcyc = fs::path(PathTcyc) / "timecyc.json";

    try {
        if (fs::exists(temptcyc) && fs::file_size(temptcyc) > 0) {
            fs::copy(temptcyc, CopyTcyc, fs::copy_options::overwrite_existing);
            std::cout << "Таймсус: " << CopyTcyc << " изменен." << std::endl;
        }
    }
    catch (const exception& e) {
        std::cout << "Ошибка копирования файла: " << e.what() << std::endl;
    }

    if (fs::exists(temptcyc)) {
        fs::remove(temptcyc);
    }
}

void CopyBild(std::string BildFile) {
    std::string Bild[] = { "Bild1.btx", "Bild2.btx", "Bild3.btx" };
    std::string PathBild = "Bildboard";
    std::string zipname = PathBild + "/Bilboard.zip";

    if (fs::exists(PathBild)) {
        fs::remove_all(PathBild);
    }
    fs::create_directory(PathBild);

    for (int i = 0; i < size(Bild); i++) {
        fs::path CopyBild = fs::path(PathBild) / Bild[i];
        fs::copy(BildFile, CopyBild, fs::copy_options::overwrite_existing);
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, 0);

    for (int i = 0; i < size(Bild); i++) {
        fs::path filepath = fs::path(PathBild) / Bild[i];
        zip_source_t* source = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
        zip_file_add(zip_archive, Bild[i].c_str(), source, 0);
    }

    zip_close(zip_archive);

    for (const auto& ent : Bild) {
        fs::path filepath = fs::path(PathBild) / ent;
        fs::remove(filepath);
    }
}

void CopyListva(std::string ListvaFile) {
    std::string Listva[] = { "Listva1.btx", "Listva2.btx", "Listva3.btx" };
    std::string PathListva = "Listva";
    std::string zipname = PathListva + "/Listva.zip";
    int err = 0;

    if (fs::exists(PathListva)) {
        fs::remove_all(PathListva);
    }
    fs::create_directory(PathListva);

    for (int i = 0; i < size(Listva); i++) {
        fs::path File = ListvaFile;
        fs::path CopyListva = fs::path(PathListva) / Listva[i];

        if (fs::exists(File)) {
            fs::copy(File, CopyListva, fs::copy_options::overwrite_existing);
        }
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, &err);

    for (int i = 0; i < size(Listva); i++) {
        fs::path filepath = fs::path(PathListva) / Listva[i];
        zip_source_t* zip = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
        zip_file_add(zip_archive, Listva[i].c_str(), zip, ZIP_FL_ENC_UTF_8);
    }

    zip_close(zip_archive);

    for (const auto& ent : Listva) {
        fs::path filepath = fs::path(PathListva) / ent;
        fs::remove(filepath);
    }
}

void CopyLogo(std::string LogoFile) {
    std::string Logo[] = { "Logo1.btx", "Logo2.btx", "Logo3.btx" };
    std::string PathLogo = "Logo";
    std::string zipname = PathLogo + "/Logo.zip";
    int err = 0;

    if (fs::exists(PathLogo)) {
        fs::remove_all(PathLogo);
    }
    fs::create_directory(PathLogo);

    for (int i = 0; i < size(Logo); i++) {
        fs::path File = LogoFile;
        fs::path CopyLogo = fs::path(PathLogo) / Logo[i];

        if (fs::exists(File)) {
            fs::copy(File, CopyLogo, fs::copy_options::overwrite_existing);
        }
    }

    zip_t* zip_archive = zip_open(zipname.c_str(), ZIP_CREATE | ZIP_TRUNCATE, &err);

    for (int i = 0; i < size(Logo); i++) {
        fs::path filepath = fs::path(PathLogo) / Logo[i];
        zip_source_t* zip = zip_source_file(zip_archive, filepath.string().c_str(), 0, 0);
        zip_file_add(zip_archive, Logo[i].c_str(), zip, ZIP_FL_ENC_UTF_8);
    }

    zip_close(zip_archive);

    for (const auto& ent : Logo) {
        fs::path filepath = fs::path(PathLogo) / ent;
        fs::remove(filepath);
    }
}

void converted(const std::string filePath) {
    fs::path filePath_ = filePath;
    std::string full_path;
    if(filePath_.extension() == ".png" && filePath_.extension() == ".jpg" && filePath_.extension() == ".btx") {
        Logger logger("conversion_log.txt");
        convert_auto_btx_and_png(filePath, logger);
    }
    else if (filePath_.extension() == ".zip") {
        std::string zipname = "KoTeK_" + filePath;
		zip_t* archive = zip_open(filePath.c_str(), 0 , 0);

        if (!archive) {
			std::cout << "Не удалось открыть архив: " << filePath << std::endl;
        }

		zip_int64_t num_ent = zip_get_num_entries(archive, 0);
        for (zip_int64_t i = 0; i < num_ent; ++i) {
            const char* name = zip_get_name(archive, i, 0);
            Logger logger("conversion_log.txt");
            if (!name) continue;
            if (name[strlen(name) - 1] == '/') continue;

            full_path = name;

			zip_file_t* zip = zip_fopen_index(archive, i, 0);
            if (!zip) continue;

            std::ofstream out(full_path, std::ios::binary);
            if (!out) {
                zip_fclose(zip);
                continue;
            }

            char buf[8192];
            zip_int64_t n;
            while ((n = zip_fread(zip, buf, sizeof(buf))) > 0) {
                out.write(buf, n);
            }

            out.close();
            zip_fclose(zip);

        convert_auto_btx_and_png(full_path, logger);

		fs::remove(full_path);
        }
		zip_close(archive);
    }
    else {
        std::cout << "Формат не распознан: Можно использовать только .btx, .png, .jpg, .zip" << std::endl;
	}
}

bool check(const std::string path) {
    ifstream check(path);
    bool exists = check.is_open();
    check.close();
    return exists;
}