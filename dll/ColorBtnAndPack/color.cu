#include "cuda_runtime.h"
#include "device_launch_parameters.h"

__global__ void Colored(
    unsigned char* __restrict__ output,
    const unsigned char* __restrict__ input,
    int width,
    int height,
    float r,
    float g,
    float b
) {
    int idx = blockIdx.x * blockDim.x + threadIdx.x;
    int total_pixels = width * height;

    if (idx >= total_pixels) return;

    const uchar4* in = reinterpret_cast<const uchar4*>(input);
    uchar4* out = reinterpret_cast<uchar4*>(output);

    uchar4 pixel = in[idx];

    float lum = pixel.x * 0.299f + pixel.y * 0.587f + pixel.z * 0.114f;
    float inv255 = 1.0f / 255.0f;
    lum *= inv255;

    out[idx].x = (unsigned char)(lum * r);
    out[idx].y = (unsigned char)(lum * g);
    out[idx].z = (unsigned char)(lum * b);
    out[idx].w = pixel.w;
}

void Colors(
    unsigned char* image,
    unsigned char* h_output,
    int w, int h,
    float r, float g, float b
) {
    unsigned char* d_input = nullptr;
    unsigned char* d_output = nullptr;

    size_t numbytes = w * h * 4 * sizeof(unsigned char);

    cudaMalloc(&d_input, numbytes);
    cudaMalloc(&d_output, numbytes);

    cudaMemcpy(d_input, image, numbytes, cudaMemcpyHostToDevice);

    dim3 blocksize(512);
    dim3 gridsize((w * h + blocksize.x - 1) / blocksize.x);
    Colored << <gridsize, blocksize >> > (d_output, d_input, w, h, r, g, b);

    cudaDeviceSynchronize();

    cudaMemcpy(h_output, d_output, numbytes, cudaMemcpyDeviceToHost);

    cudaFree(d_input);
    cudaFree(d_output);
}