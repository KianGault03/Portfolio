#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <cuda_runtime.h>
#include <chrono>
#include <cmath>

#include "gpuErrchk.h"

/*
 GPU device function that performs the check to see if the found token is a non letter or not 
*/
__device__ bool is_non_letter(char c) {
     
    return (c < 'a' || c > 'z');
}

/*
 GPU device function that performs the compare token check by comparing the current index
 Threads will access this device function in parallel 
*/
__device__ bool compare_token(const char* data, const char* token, int token_len) {
    // loop around the token length to check if the current index is a match 
    for (int i = 0; i < token_len; ++i) {
        if (data[i] != token[i])
            return false;
    }
    return true;
}

/*
 GPU kernel that performs the count for word occurences 
 __global__ keyword used to declare the function as a kernel
*/
__global__ void count_occurrences_gpu(const char* data, int data_len, const char* token, int token_len, int* result) {
    // calculate the unique index to allow all threads to work in parallel
    int idx = blockIdx.x * blockDim.x + threadIdx.x;
    // Check to see if the index is in valid bounds before beginning 
    if (idx + token_len > data_len) return;

    // calls the device function to compare the token and see if that match is a non letter 
    if (compare_token(&data[idx], token, token_len)) {
        bool prefix_valid = (idx == 0 || is_non_letter(data[idx - 1]));
        bool suffix_valid = (idx + token_len == data_len || is_non_letter(data[idx + token_len]));

        // if the token match is a valid match then use atomic add to increment the counter 
        if (prefix_valid && suffix_valid) {
            atomicAdd(result, 1);
        }
    }
}

/*
 Modified function that now performs CUDA operations such as memory allocations and calling a CUDA kernel
*/
int calc_token_occurrences_gpu(const std::vector<char>& data, const char* token) {
    // Record the length of data and token as these values are needed for block calculation 
    int data_len = data.size();
    int token_len = strlen(token);

    // Allocate device memory
    char* d_data;
    char* d_token;
    int* d_result;
    int h_result = 0;

    // Use cudaMalloc to allocate memory on the device for the incoming data
    cudaMalloc(&d_data, data_len * sizeof(char));
    cudaMalloc(&d_token, token_len * sizeof(char));
    cudaMalloc(&d_result, sizeof(int));

    // Copy data to device, note that HostToDevice is used 
    cudaMemcpy(d_data, data.data(), data_len * sizeof(char), cudaMemcpyHostToDevice);
    cudaMemcpy(d_token, token, token_len * sizeof(char), cudaMemcpyHostToDevice);
    cudaMemcpy(d_result, &h_result, sizeof(int), cudaMemcpyHostToDevice);

    // Define block and thread sizes
    int numThreads = 256;
    // formula is used to dynamically calculate the block size to ensure the whole incoming file can be searched
    int numBlocks = (data_len + numThreads - 1) / numThreads;

    // Launch kernel
    count_occurrences_gpu<<<numBlocks, numThreads>>>(d_data, data_len, d_token, token_len, d_result);

    // Copy result back to host
    cudaMemcpy(&h_result, d_result, sizeof(int), cudaMemcpyDeviceToHost);

    // Free device memory
    cudaFree(d_data);
    cudaFree(d_token);
    cudaFree(d_result);

    return h_result;
}

/*
 Original C++ function
 No changes in this build 
*/
int calc_token_occurrences(const std::vector<char>& data, const char* token)
{
    int numOccurrences = 0;
    int tokenLen = int(strlen(token));
    for (int i = 0; i< int(data.size()); ++i)
    {
        // test 1: does this match the token?
        auto diff = strncmp(&data[i], token, tokenLen);
        if (diff != 0)
            continue;

        // test 2: is the prefix a non-letter character?
        auto iPrefix = i - 1;
        if (iPrefix >= 0 && data[iPrefix] >= 'a' && data[iPrefix] <= 'z')
            continue;

        // test 3: is the prefix a non-letter character?
        auto iSuffix = i + tokenLen;
        if (iSuffix < int(data.size()) && data[iSuffix] >= 'a' && data[iSuffix] <= 'z')
            continue;
        ++numOccurrences;
    }
    return numOccurrences;
}
/*
 Original C++ function
 No changes in this build
*/
std::vector<char> read_file(const char* filename) {
    std::ifstream file(filename, std::ios::binary);

    if (!file) {
        std::cerr << "Error: Could not open the file " << filename << std::endl;
        return {};
    }

    file.seekg(0, std::ios::end);
    std::streamsize fileSize = file.tellg();
    file.seekg(0, std::ios::beg);

    std::vector<char> buffer(fileSize);

    if (!file.read(buffer.data(), fileSize)) {
        std::cerr << "Error: Could not read the file content." << std::endl;
        return {};
    }

    file.close();

    std::transform(buffer.begin(), buffer.end(), buffer.begin(), [](char c) { return std::tolower(c); });

    return buffer;
}

/*
 C++ function that calculates the current device specs 
*/
int deviceInformation() {

    // Get number of devices on system
    int deviceCount;
    gpuErrchk(cudaGetDeviceCount(&deviceCount));

    std::cout << "Number of devices: " << deviceCount << std::endl;
    for (int i = 0; i < deviceCount; ++i)
    {
        // Get properties for device
        cudaDeviceProp deviceProp;
        cudaGetDeviceProperties(&deviceProp, i);

        std::cout << "Device " << i << std::endl;
        std::cout << "Name " << deviceProp.name << std::endl;
        std::cout << "Revision " << deviceProp.major << "." << deviceProp.minor << std::endl;
        std::cout << "Memory " << deviceProp.totalGlobalMem / 1024 / 1024 << "MB" << std::endl;
        std::cout << "Warp Size " << deviceProp.warpSize << std::endl;
        std::cout << "Clock " << deviceProp.clockRate << std::endl;
        std::cout << "Multiprocessors " << deviceProp.multiProcessorCount << std::endl;
    }
    return 0;
}

/*
 Main function that has been modified to allow the user to select which data file they wish to search through
 CPU and GPU comparsions are done through performace tracking tools 
 The record times are compared and shown to the user for added clarity 
 Option is given to the user to restart the application for an additional search
*/
int main() {

    // Display the current machines hardware 
    deviceInformation();
    
    // List of words to use as search tokens alongside file and file choice variables 
    const char* words[] = { "sword", "fire", "death", "love", "hate", "the", "man", "woman" };
    const char* filepath; 
    int fileChoice;
    int choice;

    // List of console messages to list the options to the user 
    std::cout << "\nWelcome to the application! Please enter the number of the text file to search: " << std::endl;
    std::cout << "1. shakespeare " << std::endl;
    std::cout << "2. beowulf " << std::endl;
    std::cout << "3. crime and punishment " << std::endl;
    std::cout << "4. edgar allan poe " << std::endl;
    std::cout << "5. pride and prejudice \n" << std::endl;

    // Users choice is stored 
    std::cin >> fileChoice;

    // Switch statement to handle the users choice and store the chosen file path
    switch(fileChoice) {
    case 1:
        filepath = "dataset/shakespeare.txt";
        std::cout << "Now searching shakespeare.txt for word occurences" << std::endl;
        break;
    case 2: 
        filepath = "dataset/beowulf.txt";
        std::cout << "Now searching beowulf.txt for word occurences" << std::endl;
        break;
    case 3:
        filepath = "dataset/crime_and_punishment.txt";
        std::cout << "Now searching crime_and_punishment.txt for word occurences" << std::endl;
        break;
    case 4:
        filepath = "dataset/edgar_allan_poe.txt";
        std::cout << "Now searching edgar_allan_poe.txt for word occurences" << std::endl;
        break;
    case 5:
        filepath = "dataset/pride_and_prejudice.txt";
        std::cout << "Now searching pride_and_prejudice.txt for word occurences" << std::endl;
        break;
    default:
        std::cout << "You must select a valid option!\n" << std::endl;
        main();
    }

    // the chosen file path is transfered to the read file function to open
    std::vector<char> file_data = read_file(filepath);
    if (file_data.empty()) return -1;

    // CPU version timing using chrono libary
    std::cout << "\nCPU version of text search:" << std::endl;
    auto cpu_start = std::chrono::high_resolution_clock::now();
    for (const char* word : words) {
        int occurrences = calc_token_occurrences(file_data, word);
        std::cout << "Found " << occurrences << " occurrences of word: " << word << std::endl;
    }
    auto cpu_end = std::chrono::high_resolution_clock::now();
    int cpu_duration = std::chrono::duration_cast<std::chrono::milliseconds>(cpu_end - cpu_start).count();
    std::cout << "CPU version took " << cpu_duration << "ms." << std::endl;


    // GPU version timing
    std::cout << "\nGPU version of text search:" << std::endl;
    cudaEvent_t gpu_start, gpu_stop;
    float gpu_time = 0.0f;

    // cuda Events used to create two events to track the start and end timings 
    cudaEventCreate(&gpu_start);
    cudaEventCreate(&gpu_stop);
    // recording starts to track the timing 
    cudaEventRecord(gpu_start);

    for (const char* word : words) {
        int occurrences = calc_token_occurrences_gpu(file_data, word);
        std::cout << "Found " << occurrences << " occurrences of word: " << word << std::endl;
    }

    // Records the end timing and synchronizes to ensure all operations are completed before recording the time
    cudaEventRecord(gpu_stop);
    cudaEventSynchronize(gpu_stop);
    // Adds the two timings together 
    cudaEventElapsedTime(&gpu_time, gpu_start, gpu_stop);

    // Round GPU time to the nearest millisecond
    int gpu_duration = static_cast<int>(std::round(gpu_time));
    std::cout << "GPU version took " << gpu_duration << "ms." << std::endl;

    // Cleanup CUDA events
    cudaEventDestroy(gpu_start);
    cudaEventDestroy(gpu_stop);


    // Speed comparison
    if (gpu_duration < cpu_duration) {
        std::cout << "\nThe GPU version is faster by " << (cpu_duration - gpu_duration) << "ms." << std::endl;
    }
    else if (cpu_duration < gpu_duration) {
        std::cout << "\nThe CPU version is faster by " << (gpu_duration - cpu_duration) << "ms." << std::endl;
    }
    else {
        std::cout << "\nBoth versions took the same amount of time." << std::endl;
    }

    // User is giving the option to restart the program 
    std::cout << "\nTo select another file enter 1 or to exit enter 0" << std::endl;
    std::cin >> choice;

    if (choice == 1)
    {
        main();
    }
    else
    {
        return 0;
    }

  
   
}








