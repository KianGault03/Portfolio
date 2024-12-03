#include "cuda_runtime.h"
#include "device_launch_parameters.h"
#include "gpuErrchk.h"

#include <stdio.h>
#include <iostream>
#include <vector>
#include <cuda_runtime.h>
#include <device_launch_parameters.h>



__global__ void myKernal(const int* A, const int* B, int* C);
int Addition();