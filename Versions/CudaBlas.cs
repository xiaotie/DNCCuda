using System;

namespace ManagedCuda.CudaBlas
{
    public static partial class CudaBlasNativeMethods
    {
        //32bit is no more supported, only 64 bit...
        internal const string CUBLAS_API_DLL_NAME = "cublas64_80";
    }
}