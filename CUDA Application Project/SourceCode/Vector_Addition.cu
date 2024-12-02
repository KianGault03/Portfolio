#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include "gpuErrchk.h"

#include <stdio.h>
#include <iostream>
#include <vector>
#include <cuda_runtime.h>
#include <device_launch_parameters.h>

constexpr size_t ELEMENTS = 2048;

__global__ void myKernal(const int* A, const int* B, int* C) {

    unsigned int block_idx = blockIdx.x;
    unsigned int thread_idx = threadIdx.x;
    unsigned int block_dim = blockDim.x;
    unsigned int idx = (block_idx * block_dim) + thread_idx;

    C[idx] = A[idx] + B[idx];

}

int Addition() {

    auto data_size = sizeof(int) * ELEMENTS;
    std::vector<int> A(ELEMENTS);
    std::vector<int> B(ELEMENTS);
    std::vector<int> C(ELEMENTS);

    for (unsigned int i = 0; i < ELEMENTS; i++)
    {
        A[i] = B[i] = i;
    }

    int* buffer_A, * buffer_B, * buffer_C;

    cudaMalloc((void**)&buffer_A, data_size);
    cudaMalloc((void**)&buffer_B, data_size);
    cudaMalloc((void**)&buffer_C, data_size);

    cudaMemcpy(buffer_A, &A[0], data_size, cudaMemcpyHostToDevice);
    cudaMemcpy(buffer_A, &B[0], data_size, cudaMemcpyHostToDevice);

    myKernal<<<ELEMENTS / 1024, 1024 >>>(buffer_A, buffer_B, buffer_C);

    cudaDeviceSynchronize();

    cudaMemcpy(&C[0], buffer_C, data_size, cudaMemcpyDeviceToHost);

    cudaFree(buffer_A);
    cudaFree(buffer_B);
    cudaFree(buffer_C);

    for (int i = 0; i < 2048; ++i)
        if (C[i] != i + i)
            std::cout << "Error: " << i << std::endl;

    std::cout << "Finished" << std::endl;

    return 0;
}