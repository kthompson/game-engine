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
    /// <summary>Cursor types for SDL_CreateSystemCursor().</summary>
    public enum SystemCursor
    {
        /// <summary>Arrow</summary>
        SYSTEM_CURSOR_ARROW = 0,
        /// <summary>I-beam</summary>
        SYSTEM_CURSOR_IBEAM = 1,
        /// <summary>Wait</summary>
        SYSTEM_CURSOR_WAIT = 2,
        /// <summary>Crosshair</summary>
        SYSTEM_CURSOR_CROSSHAIR = 3,
        /// <summary>Small wait cursor (or Wait if not available)</summary>
        SYSTEM_CURSOR_WAITARROW = 4,
        /// <summary>Double arrow pointing northwest and southeast</summary>
        SYSTEM_CURSOR_SIZENWSE = 5,
        /// <summary>Double arrow pointing northeast and southwest</summary>
        SYSTEM_CURSOR_SIZENESW = 6,
        /// <summary>Double arrow pointing west and east</summary>
        SYSTEM_CURSOR_SIZEWE = 7,
        /// <summary>Double arrow pointing north and south</summary>
        SYSTEM_CURSOR_SIZENS = 8,
        /// <summary>Four pointed arrow pointing north, south, east, and west</summary>
        SYSTEM_CURSOR_SIZEALL = 9,
        /// <summary>Slashed circle or crossbones</summary>
        SYSTEM_CURSOR_NO = 10,
        /// <summary>Hand</summary>
        SYSTEM_CURSOR_HAND = 11,
        NUM_SYSTEM_CURSORS = 12
    }

    /// <summary>Scroll direction types for the Scroll event</summary>
    public enum MouseWheelDirection
    {
        /// <summary>The scroll direction is normal</summary>
        MOUSEWHEEL_NORMAL = 0,
        /// <summary>The scroll direction is flipped / natural</summary>
        MOUSEWHEEL_FLIPPED = 1
    }

    public unsafe partial class Cursor
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Cursor> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Cursor>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.Cursor __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.Cursor(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.Cursor __CreateInstance(global::SharpSDL.Cursor.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.Cursor(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.Cursor.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Cursor.__Internal));
            *(global::SharpSDL.Cursor.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Cursor(global::SharpSDL.Cursor.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Cursor(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class SDLMouse
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetMouseFocus")]
            internal static extern global::System.IntPtr GetMouseFocus();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetMouseState")]
            internal static extern uint GetMouseState(int* x, int* y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetGlobalMouseState")]
            internal static extern uint GetGlobalMouseState(int* x, int* y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetRelativeMouseState")]
            internal static extern uint GetRelativeMouseState(int* x, int* y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_WarpMouseInWindow")]
            internal static extern void WarpMouseInWindow(global::System.IntPtr window, int x, int y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_WarpMouseGlobal")]
            internal static extern int WarpMouseGlobal(int x, int y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_CreateCursor")]
            internal static extern global::System.IntPtr CreateCursor(byte* data, byte* mask, int w, int h, int hot_x, int hot_y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_CreateColorCursor")]
            internal static extern global::System.IntPtr CreateColorCursor(global::System.IntPtr surface, int hot_x, int hot_y);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_CreateSystemCursor")]
            internal static extern global::System.IntPtr CreateSystemCursor(global::SharpSDL.SystemCursor id);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SetCursor")]
            internal static extern void SetCursor(global::System.IntPtr cursor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetCursor")]
            internal static extern global::System.IntPtr GetCursor();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetDefaultCursor")]
            internal static extern global::System.IntPtr GetDefaultCursor();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_FreeCursor")]
            internal static extern void FreeCursor(global::System.IntPtr cursor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_ShowCursor")]
            internal static extern int ShowCursor(int toggle);
        }

        /// <summary>Get the window which currently has mouse focus.</summary>
        public static global::SharpSDL.Window GetMouseFocus()
        {
            var __ret = __Internal.GetMouseFocus();
            global::SharpSDL.Window __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Window.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Window) global::SharpSDL.Window.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Window.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Retrieve the current state of the mouse.</summary>
/// <remarks>
/// <para>The current button state is returned as a button bitmask, which can</para>
/// <para>be tested using the SDL_BUTTON(X) macros, and x and y are set to the</para>
/// <para>mouse cursor position relative to the focus window for the currently</para>
/// <para>selected mouse.  You can pass NULL for either x or y.</para>
/// </remarks>
        public static uint GetMouseState(ref int x, ref int y)
        {
            fixed (int* __x0 = &x)
            {
                var __arg0 = __x0;
                fixed (int* __y1 = &y)
                {
                    var __arg1 = __y1;
                    var __ret = __Internal.GetMouseState(__arg0, __arg1);
                    return __ret;
                }
            }
        }

        /// <summary>Get the current state of the mouse, in relation to the desktop</summary>
/// <param name="x">Returns the current X coord, relative to the desktop. Can be NULL.</param>
/// <param name="y">Returns the current Y coord, relative to the desktop. Can be NULL.</param>
/// <returns>The current button state as a bitmask, which can be tested using the SDL_BUTTON(X) macros.</returns>
/// <remarks>
/// <para>This works just like SDL_GetMouseState(), but the coordinates will be</para>
/// <para>reported relative to the top-left of the desktop. This can be useful if</para>
/// <para>you need to track the mouse outside of a specific window and</para>
/// <para>SDL_CaptureMouse() doesn't fit your needs. For example, it could be</para>
/// <para>useful if you need to track the mouse while dragging a window, where</para>
/// <para>coordinates relative to a window might not be in sync at all times.</para>
/// <para>SDL_GetMouseState() returns the mouse position as SDL understands</para>
/// <para>it from the last pump of the event queue. This function, however,</para>
/// <para>queries the OS for the current mouse position, and as such, might</para>
/// <para>be a slightly less efficient function. Unless you know what you're</para>
/// <para>doing and have a good reason to use this function, you probably want</para>
/// <para>SDL_GetMouseState() instead.</para>
/// <para>SDL_GetMouseState</para>
/// </remarks>
        public static uint GetGlobalMouseState(ref int x, ref int y)
        {
            fixed (int* __x0 = &x)
            {
                var __arg0 = __x0;
                fixed (int* __y1 = &y)
                {
                    var __arg1 = __y1;
                    var __ret = __Internal.GetGlobalMouseState(__arg0, __arg1);
                    return __ret;
                }
            }
        }

        /// <summary>Retrieve the relative state of the mouse.</summary>
/// <remarks>
/// <para>The current button state is returned as a button bitmask, which can</para>
/// <para>be tested using the SDL_BUTTON(X) macros, and x and y are set to the</para>
/// <para>mouse deltas since the last call to SDL_GetRelativeMouseState().</para>
/// </remarks>
        public static uint GetRelativeMouseState(ref int x, ref int y)
        {
            fixed (int* __x0 = &x)
            {
                var __arg0 = __x0;
                fixed (int* __y1 = &y)
                {
                    var __arg1 = __y1;
                    var __ret = __Internal.GetRelativeMouseState(__arg0, __arg1);
                    return __ret;
                }
            }
        }

        /// <summary>Moves the mouse to the given position within the window.</summary>
/// <param name="window">The window to move the mouse into, or NULL for the current mouse focus</param>
/// <param name="x">The x coordinate within the window</param>
/// <param name="y">The y coordinate within the window</param>
/// <remarks>This function generates a mouse motion event</remarks>
        public static void WarpMouseInWindow(global::SharpSDL.Window window, int x, int y)
        {
            var __arg0 = ReferenceEquals(window, null) ? global::System.IntPtr.Zero : window.__Instance;
            __Internal.WarpMouseInWindow(__arg0, x, y);
        }

        /// <summary>Moves the mouse to the given position in global screen space.</summary>
/// <param name="x">The x coordinate</param>
/// <param name="y">The y coordinate</param>
/// <returns>0 on success, -1 on error (usually: unsupported by a platform).</returns>
/// <remarks>This function generates a mouse motion event</remarks>
        public static int WarpMouseGlobal(int x, int y)
        {
            var __ret = __Internal.WarpMouseGlobal(x, y);
            return __ret;
        }

        /// <summary>
/// <para>Create a cursor, using the specified bitmap data and</para>
/// <para>mask (in MSB format).</para>
/// </summary>
/// <remarks>
/// <para>The cursor width must be a multiple of 8 bits.</para>
/// <para>The cursor is created in black and white according to the following:</para>
/// <para></para>
/// <para>datamaskresulting pixel on screen</para>
/// <para>01White</para>
/// <para>11Black</para>
/// <para>00Transparent</para>
/// <para>10Inverted color if possible, black</para>
/// <para>if not.</para>
/// <para>SDL_FreeCursor()</para>
/// </remarks>
        public static global::SharpSDL.Cursor CreateCursor(byte* data, byte* mask, int w, int h, int hot_x, int hot_y)
        {
            var __ret = __Internal.CreateCursor(data, mask, w, h, hot_x, hot_y);
            global::SharpSDL.Cursor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Cursor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Cursor) global::SharpSDL.Cursor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Cursor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Create a color cursor.</summary>
/// <remarks>SDL_FreeCursor()</remarks>
        public static global::SharpSDL.Cursor CreateColorCursor(global::SharpSDL.Surface surface, int hot_x, int hot_y)
        {
            var __arg0 = ReferenceEquals(surface, null) ? global::System.IntPtr.Zero : surface.__Instance;
            var __ret = __Internal.CreateColorCursor(__arg0, hot_x, hot_y);
            global::SharpSDL.Cursor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Cursor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Cursor) global::SharpSDL.Cursor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Cursor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Create a system cursor.</summary>
/// <remarks>SDL_FreeCursor()</remarks>
        public static global::SharpSDL.Cursor CreateSystemCursor(global::SharpSDL.SystemCursor id)
        {
            var __ret = __Internal.CreateSystemCursor(id);
            global::SharpSDL.Cursor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Cursor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Cursor) global::SharpSDL.Cursor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Cursor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Set the active cursor.</summary>
        public static void SetCursor(global::SharpSDL.Cursor cursor)
        {
            var __arg0 = ReferenceEquals(cursor, null) ? global::System.IntPtr.Zero : cursor.__Instance;
            __Internal.SetCursor(__arg0);
        }

        /// <summary>Return the active cursor.</summary>
        public static global::SharpSDL.Cursor GetCursor()
        {
            var __ret = __Internal.GetCursor();
            global::SharpSDL.Cursor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Cursor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Cursor) global::SharpSDL.Cursor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Cursor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Return the default cursor.</summary>
        public static global::SharpSDL.Cursor GetDefaultCursor()
        {
            var __ret = __Internal.GetDefaultCursor();
            global::SharpSDL.Cursor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Cursor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Cursor) global::SharpSDL.Cursor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Cursor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Frees a cursor created with SDL_CreateCursor() or similar functions.</summary>
/// <remarks>
/// <para>SDL_CreateCursor()</para>
/// <para>SDL_CreateColorCursor()</para>
/// <para>SDL_CreateSystemCursor()</para>
/// </remarks>
        public static void FreeCursor(global::SharpSDL.Cursor cursor)
        {
            var __arg0 = ReferenceEquals(cursor, null) ? global::System.IntPtr.Zero : cursor.__Instance;
            __Internal.FreeCursor(__arg0);
        }

        /// <summary>Toggle whether or not the cursor is shown.</summary>
/// <param name="toggle">
/// <para>1 to show the cursor, 0 to hide it, -1 to query the current</para>
/// <para>state.</para>
/// </param>
/// <returns>1 if the cursor is shown, or 0 if the cursor is hidden.</returns>
        public static int ShowCursor(int toggle)
        {
            var __ret = __Internal.ShowCursor(toggle);
            return __ret;
        }
    }
}
