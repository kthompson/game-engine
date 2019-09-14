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
    /// <summary>An enumeration of hint priorities</summary>
    public enum HintPriority
    {
        HINT_DEFAULT = 0,
        HINT_NORMAL = 1,
        HINT_OVERRIDE = 2
    }

    /// <summary>type definition of the hint callback function.</summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void HintCallback(global::System.IntPtr userdata, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string oldValue, [MarshalAs(UnmanagedType.LPStr)] string newValue);

    public unsafe partial class SDL_hints
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetHint")]
            internal static extern global::System.IntPtr GetHint([MarshalAs(UnmanagedType.LPStr)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_AddHintCallback")]
            internal static extern void AddHintCallback([MarshalAs(UnmanagedType.LPStr)] string name, global::System.IntPtr callback, global::System.IntPtr userdata);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_DelHintCallback")]
            internal static extern void DelHintCallback([MarshalAs(UnmanagedType.LPStr)] string name, global::System.IntPtr callback, global::System.IntPtr userdata);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_ClearHints")]
            internal static extern void ClearHints();
        }

        /// <summary>Get a hint</summary>
/// <returns>The string value of a hint variable.</returns>
        public static string GetHint(string name)
        {
            var __ret = __Internal.GetHint(name);
            return Marshal.PtrToStringAnsi(__ret);
        }

        /// <summary>Add a function to watch a particular hint</summary>
/// <param name="name">The hint to watch</param>
/// <param name="callback">The function to call when the hint value changes</param>
/// <param name="userdata">A pointer to pass to the callback function</param>
        public static void AddHintCallback(string name, global::SharpSDL.HintCallback callback, global::System.IntPtr userdata)
        {
            var __arg1 = callback == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback);
            __Internal.AddHintCallback(name, __arg1, userdata);
        }

        /// <summary>Remove a function watching a particular hint</summary>
/// <param name="name">The hint being watched</param>
/// <param name="callback">The function being called when the hint value changes</param>
/// <param name="userdata">A pointer being passed to the callback function</param>
        public static void DelHintCallback(string name, global::SharpSDL.HintCallback callback, global::System.IntPtr userdata)
        {
            var __arg1 = callback == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback);
            __Internal.DelHintCallback(name, __arg1, userdata);
        }

        /// <summary>Clear all hints</summary>
/// <remarks>This function is called during SDL_Quit() to free stored hints.</remarks>
        public static void ClearHints()
        {
            __Internal.ClearHints();
        }
    }
}
