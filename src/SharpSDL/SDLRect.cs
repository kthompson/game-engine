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
    /// <summary>The structure that defines a point (integer)</summary>
/// <remarks>
/// <para>SDL_EnclosePoints</para>
/// <para>SDL_PointInRect</para>
/// </remarks>
    public unsafe partial class Point : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int x;

            [FieldOffset(4)]
            internal int y;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0SDL_Point@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Point> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Point>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.Point __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.Point(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.Point __CreateInstance(global::SharpSDL.Point.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.Point(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.Point.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Point.__Internal));
            *(global::SharpSDL.Point.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Point(global::SharpSDL.Point.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Point(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public Point()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Point.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public Point(global::SharpSDL.Point _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Point.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::SharpSDL.Point.__Internal*) __Instance) = *((global::SharpSDL.Point.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::SharpSDL.Point __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public int X
        {
            get
            {
                return ((global::SharpSDL.Point.__Internal*) __Instance)->x;
            }

            set
            {
                ((global::SharpSDL.Point.__Internal*)__Instance)->x = value;
            }
        }

        public int Y
        {
            get
            {
                return ((global::SharpSDL.Point.__Internal*) __Instance)->y;
            }

            set
            {
                ((global::SharpSDL.Point.__Internal*)__Instance)->y = value;
            }
        }
    }

    /// <summary>The structure that defines a point (floating point)</summary>
/// <remarks>
/// <para>SDL_EnclosePoints</para>
/// <para>SDL_PointInRect</para>
/// </remarks>
    public unsafe partial class FPoint : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal float x;

            [FieldOffset(4)]
            internal float y;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0SDL_FPoint@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.FPoint> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.FPoint>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.FPoint __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.FPoint(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.FPoint __CreateInstance(global::SharpSDL.FPoint.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.FPoint(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.FPoint.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FPoint.__Internal));
            *(global::SharpSDL.FPoint.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private FPoint(global::SharpSDL.FPoint.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected FPoint(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public FPoint()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FPoint.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public FPoint(global::SharpSDL.FPoint _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FPoint.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::SharpSDL.FPoint.__Internal*) __Instance) = *((global::SharpSDL.FPoint.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::SharpSDL.FPoint __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public float X
        {
            get
            {
                return ((global::SharpSDL.FPoint.__Internal*) __Instance)->x;
            }

            set
            {
                ((global::SharpSDL.FPoint.__Internal*)__Instance)->x = value;
            }
        }

        public float Y
        {
            get
            {
                return ((global::SharpSDL.FPoint.__Internal*) __Instance)->y;
            }

            set
            {
                ((global::SharpSDL.FPoint.__Internal*)__Instance)->y = value;
            }
        }
    }

    /// <summary>A rectangle, with the origin at the upper left (integer).</summary>
/// <remarks>
/// <para>SDL_RectEmpty</para>
/// <para>SDL_RectEquals</para>
/// <para>SDL_HasIntersection</para>
/// <para>SDL_IntersectRect</para>
/// <para>SDL_UnionRect</para>
/// <para>SDL_EnclosePoints</para>
/// </remarks>
    public unsafe partial class Rect : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int x;

            [FieldOffset(4)]
            internal int y;

            [FieldOffset(8)]
            internal int w;

            [FieldOffset(12)]
            internal int h;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0SDL_Rect@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Rect> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Rect>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.Rect __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.Rect(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.Rect __CreateInstance(global::SharpSDL.Rect.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.Rect(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.Rect.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Rect.__Internal));
            *(global::SharpSDL.Rect.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Rect(global::SharpSDL.Rect.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Rect(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public Rect()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Rect.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public Rect(global::SharpSDL.Rect _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Rect.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::SharpSDL.Rect.__Internal*) __Instance) = *((global::SharpSDL.Rect.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::SharpSDL.Rect __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public int X
        {
            get
            {
                return ((global::SharpSDL.Rect.__Internal*) __Instance)->x;
            }

            set
            {
                ((global::SharpSDL.Rect.__Internal*)__Instance)->x = value;
            }
        }

        public int Y
        {
            get
            {
                return ((global::SharpSDL.Rect.__Internal*) __Instance)->y;
            }

            set
            {
                ((global::SharpSDL.Rect.__Internal*)__Instance)->y = value;
            }
        }

        public int W
        {
            get
            {
                return ((global::SharpSDL.Rect.__Internal*) __Instance)->w;
            }

            set
            {
                ((global::SharpSDL.Rect.__Internal*)__Instance)->w = value;
            }
        }

        public int H
        {
            get
            {
                return ((global::SharpSDL.Rect.__Internal*) __Instance)->h;
            }

            set
            {
                ((global::SharpSDL.Rect.__Internal*)__Instance)->h = value;
            }
        }
    }

    /// <summary>A rectangle, with the origin at the upper left (floating point).</summary>
    public unsafe partial class FRect : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal float x;

            [FieldOffset(4)]
            internal float y;

            [FieldOffset(8)]
            internal float w;

            [FieldOffset(12)]
            internal float h;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0SDL_FRect@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.FRect> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.FRect>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.FRect __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.FRect(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.FRect __CreateInstance(global::SharpSDL.FRect.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.FRect(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.FRect.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FRect.__Internal));
            *(global::SharpSDL.FRect.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private FRect(global::SharpSDL.FRect.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected FRect(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public FRect()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FRect.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public FRect(global::SharpSDL.FRect _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::SharpSDL.FRect.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::SharpSDL.FRect.__Internal*) __Instance) = *((global::SharpSDL.FRect.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::SharpSDL.FRect __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public float X
        {
            get
            {
                return ((global::SharpSDL.FRect.__Internal*) __Instance)->x;
            }

            set
            {
                ((global::SharpSDL.FRect.__Internal*)__Instance)->x = value;
            }
        }

        public float Y
        {
            get
            {
                return ((global::SharpSDL.FRect.__Internal*) __Instance)->y;
            }

            set
            {
                ((global::SharpSDL.FRect.__Internal*)__Instance)->y = value;
            }
        }

        public float W
        {
            get
            {
                return ((global::SharpSDL.FRect.__Internal*) __Instance)->w;
            }

            set
            {
                ((global::SharpSDL.FRect.__Internal*)__Instance)->w = value;
            }
        }

        public float H
        {
            get
            {
                return ((global::SharpSDL.FRect.__Internal*) __Instance)->h;
            }

            set
            {
                ((global::SharpSDL.FRect.__Internal*)__Instance)->h = value;
            }
        }
    }

    public unsafe partial class SDLRect
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_UnionRect")]
            internal static extern void UnionRect(global::System.IntPtr A, global::System.IntPtr B, global::System.IntPtr result);
        }

        /// <summary>Calculate the union of two rectangles.</summary>
        public static void UnionRect(global::SharpSDL.Rect A, global::SharpSDL.Rect B, global::SharpSDL.Rect result)
        {
            var __arg0 = ReferenceEquals(A, null) ? global::System.IntPtr.Zero : A.__Instance;
            var __arg1 = ReferenceEquals(B, null) ? global::System.IntPtr.Zero : B.__Instance;
            var __arg2 = ReferenceEquals(result, null) ? global::System.IntPtr.Zero : result.__Instance;
            __Internal.UnionRect(__arg0, __arg1, __arg2);
        }
    }
}
