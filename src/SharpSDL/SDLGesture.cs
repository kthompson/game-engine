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
    public unsafe partial class SDLGesture
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_RecordGesture")]
            internal static extern int RecordGesture(long touchId);
        }

        /// <summary>Begin Recording a gesture on the specified touch, or all touches (-1)</summary>
        public static int RecordGesture(long touchId)
        {
            var __ret = __Internal.RecordGesture(touchId);
            return __ret;
        }
    }
}
