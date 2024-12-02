#pragma once
#include <filesystem>
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>



std::vector<char> read_file(const char* filename);
int calc_token_occurrences(const std::vector<char>& data, const char* token);
int OriginalCode_CVersion();