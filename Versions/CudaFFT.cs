using System;

namespace ManagedCuda.CudaFFT
{
    /// <summary>
    /// C# wrapper for the NVIDIA CUFFT API (--> cufft.h)
    /// </summary>
    public static partial class CudaFFTNativeMethods
    {
        internal const string CUFFT_API_DLL_NAME = "cufft64_80";
    }
}