#include "cuda_runtime.h"
#include "device_launch_parameters.h"

__global__ void D_Colored(uint8_t* output, const uint8_t* input, int w, int h, int r, int g, int b) {
    int idx = blockIdx.x * blockDim.x + threadIdx.x;
    if (idx >= w * h) return;

    int pixel_idx = idx * 4;
    float lum = (input[pixel_idx] * 0.299f + input[pixel_idx + 1] * 0.587f + input[pixel_idx + 2] * 0.114f) / 255.0f;

    output[pixel_idx] = static_cast<uint8_t>(r * lum);
    output[pixel_idx + 1] = static_cast<uint8_t>(g * lum);
    output[pixel_idx + 2] = static_cast<uint8_t>(b * lum);
    output[pixel_idx + 3] = input[pixel_idx + 3];
}

extern "C" void Colored(uint8_t* input, uint8_t* output, int w, int h, int r, int g, int b) {
    size_t numbytes = w * h * 4;

    uint8_t* d_input, * d_output;
    cudaMalloc(&d_input, numbytes);
    cudaMalloc(&d_output, numbytes);

    cudaMemcpy(d_input, input, numbytes, cudaMemcpyHostToDevice);

    int blocksize = 512;
    int gridsize = (w * h + blocksize - 1) / blocksize;

    D_Colored << <gridsize, blocksize >> > (d_output, d_input, w, h, r, g, b);

    cudaDeviceSynchronize();
    cudaMemcpy(output, d_output, numbytes, cudaMemcpyDeviceToHost);

    cudaFree(d_input);
    cudaFree(d_output);
}