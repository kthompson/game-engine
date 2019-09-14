// ----------------------------------------------------------------------------
// <auto-generated>
// This is autogenerated code by CppSharp.
// Do not edit this file or all your changes will be lost after re-generation.
// </auto-generated>
// ----------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpSDL
{
    public unsafe partial class SDL_cpuinfo
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetCPUCount")]
            internal static extern int GetCPUCount();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetCPUCacheLineSize")]
            internal static extern int GetCPUCacheLineSize();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetSystemRAM")]
            internal static extern int GetSystemRAM();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SIMDGetAlignment")]
            internal static extern ulong SIMDGetAlignment();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SIMDAlloc")]
            internal static extern global::System.IntPtr SIMDAlloc(ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SIMDFree")]
            internal static extern void SIMDFree(global::System.IntPtr ptr);
        }

        /// <summary>This function returns the number of CPU cores available.</summary>
        public static int GetCPUCount()
        {
            var __ret = __Internal.GetCPUCount();
            return __ret;
        }

        /// <summary>This function returns the L1 cache line size of the CPU</summary>
/// <remarks>
/// <para>This is useful for determining multi-threaded structure padding</para>
/// <para>or SIMD prefetch sizes.</para>
/// </remarks>
        public static int GetCPUCacheLineSize()
        {
            var __ret = __Internal.GetCPUCacheLineSize();
            return __ret;
        }

        /// <summary>This function returns the amount of RAM configured in the system, in MB.</summary>
        public static int GetSystemRAM()
        {
            var __ret = __Internal.GetSystemRAM();
            return __ret;
        }

        /// <summary>Report the alignment this system needs for SIMD allocations.</summary>
/// <remarks>
/// <para>This will return the minimum number of bytes to which a pointer must be</para>
/// <para>aligned to be compatible with SIMD instructions on the current machine.</para>
/// <para>For example, if the machine supports SSE only, it will return 16, but if</para>
/// <para>it supports AVX-512F, it'll return 64 (etc). This only reports values for</para>
/// <para>instruction sets SDL knows about, so if your SDL build doesn't have</para>
/// <para>SDL_HasAVX512F(), then it might return 16 for the SSE support it sees and</para>
/// <para>not 64 for the AVX-512 instructions that exist but SDL doesn't know about.</para>
/// <para>Plan accordingly.</para>
/// </remarks>
        public static ulong SIMDGetAlignment()
        {
            var __ret = __Internal.SIMDGetAlignment();
            return __ret;
        }

        /// <summary>Allocate memory in a SIMD-friendly way.</summary>
/// <param name="len">
/// <para>The length, in bytes, of the block to allocated. The actual</para>
/// <para>allocated block might be larger due to padding, etc.</para>
/// </param>
/// <returns>Pointer to newly-allocated block, NULL if out of memory.</returns>
/// <remarks>
/// <para>This will allocate a block of memory that is suitable for use with SIMD</para>
/// <para>instructions. Specifically, it will be properly aligned and padded for</para>
/// <para>the system's supported vector instructions.</para>
/// <para>The memory returned will be padded such that it is safe to read or write</para>
/// <para>an incomplete vector at the end of the memory block. This can be useful</para>
/// <para>so you don't have to drop back to a scalar fallback at the end of your</para>
/// <para>SIMD processing loop to deal with the final elements without overflowing</para>
/// <para>the allocated buffer.</para>
/// <para>You must free this memory with SDL_FreeSIMD(), not free() or SDL_free()</para>
/// <para>or delete[], etc.</para>
/// <para>Note that SDL will only deal with SIMD instruction sets it is aware of;</para>
/// <para>for example, SDL 2.0.8 knows that SSE wants 16-byte vectors</para>
/// <para>(SDL_HasSSE()), and AVX2 wants 32 bytes (SDL_HasAVX2()), but doesn't</para>
/// <para>know that AVX-512 wants 64. To be clear: if you can't decide to use an</para>
/// <para>instruction set with an SDL_Has*() function, don't use that instruction</para>
/// <para>set with memory allocated through here.</para>
/// <para>SDL_AllocSIMD(0) will return a non-NULL pointer, assuming the system isn't</para>
/// <para>out of memory.</para>
/// <para>SDL_SIMDAlignment</para>
/// <para>SDL_SIMDFree</para>
/// </remarks>
        public static global::System.IntPtr SIMDAlloc(ulong len)
        {
            var __ret = __Internal.SIMDAlloc(len);
            return __ret;
        }

        /// <summary>Deallocate memory obtained from SDL_SIMDAlloc</summary>
/// <remarks>
/// <para>It is not valid to use this function on a pointer from anything but</para>
/// <para>SDL_SIMDAlloc(). It can't be used on pointers from malloc, realloc,</para>
/// <para>SDL_malloc, memalign, new[], etc.</para>
/// <para>However, SDL_SIMDFree(NULL) is a legal no-op.</para>
/// <para>SDL_SIMDAlloc</para>
/// </remarks>
        public static void SIMDFree(global::System.IntPtr ptr)
        {
            __Internal.SIMDFree(ptr);
        }
    }
}