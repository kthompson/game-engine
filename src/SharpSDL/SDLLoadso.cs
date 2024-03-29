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
    public unsafe partial class SDLLoadso
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_LoadObject")]
            internal static extern global::System.IntPtr LoadObject([MarshalAs(UnmanagedType.LPStr)] string sofile);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_LoadFunction")]
            internal static extern global::System.IntPtr LoadFunction(global::System.IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_UnloadObject")]
            internal static extern void UnloadObject(global::System.IntPtr handle);
        }

        /// <summary>
/// <para>This function dynamically loads a shared object and returns a pointer</para>
/// <para>to the object handle (or NULL if there was an error).</para>
/// <para>The 'sofile' parameter is a system dependent name of the object file.</para>
/// </summary>
        public static global::System.IntPtr LoadObject(string sofile)
        {
            var __ret = __Internal.LoadObject(sofile);
            return __ret;
        }

        /// <summary>
/// <para>Given an object handle, this function looks up the address of the</para>
/// <para>named function in the shared object and returns it.  This address</para>
/// <para>is no longer valid after calling SDL_UnloadObject().</para>
/// </summary>
        public static global::System.IntPtr LoadFunction(global::System.IntPtr handle, string name)
        {
            var __ret = __Internal.LoadFunction(handle, name);
            return __ret;
        }

        /// <summary>Unload a shared object from memory.</summary>
        public static void UnloadObject(global::System.IntPtr handle)
        {
            __Internal.UnloadObject(handle);
        }
    }
}
