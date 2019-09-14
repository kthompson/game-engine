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
    /// <summary>The SDL thread priority.</summary>
/// <remarks>On many systems you require special privileges to set high or time critical priority.</remarks>
    public enum ThreadPriority
    {
        THREAD_PRIORITY_LOW = 0,
        THREAD_PRIORITY_NORMAL = 1,
        THREAD_PRIORITY_HIGH = 2,
        THREAD_PRIORITY_TIME_CRITICAL = 3
    }

    /// <summary>
/// <para>The function passed to SDL_CreateThread().</para>
/// <para>It is passed a void* user context parameter and returns an int.</para>
/// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int ThreadFunction(global::System.IntPtr data);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate ulong PfnSDL_CurrentBeginThread(global::System.IntPtr _0, uint _1, global::SharpSDL.Delegates.Func_uint_IntPtr func, global::System.IntPtr _2, uint _3, uint* _4);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void PfnSDL_CurrentEndThread(uint code);

    public unsafe partial class Thread
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Thread> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.Thread>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.Thread __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.Thread(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.Thread __CreateInstance(global::SharpSDL.Thread.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.Thread(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.Thread.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.Thread.__Internal));
            *(global::SharpSDL.Thread.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Thread(global::SharpSDL.Thread.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Thread(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class SDL_thread
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_CreateThread")]
            internal static extern global::System.IntPtr CreateThread(global::System.IntPtr fn, [MarshalAs(UnmanagedType.LPStr)] string name, global::System.IntPtr data, global::System.IntPtr pfnBeginThread, global::System.IntPtr pfnEndThread);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_CreateThreadWithStackSize")]
            internal static extern global::System.IntPtr CreateThreadWithStackSize(global::System.IntPtr fn, [MarshalAs(UnmanagedType.LPStr)] string name, ulong stacksize, global::System.IntPtr data, global::System.IntPtr pfnBeginThread, global::System.IntPtr pfnEndThread);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetThreadName")]
            internal static extern global::System.IntPtr GetThreadName(global::System.IntPtr thread);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_ThreadID")]
            internal static extern uint ThreadID();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetThreadID")]
            internal static extern uint GetThreadID(global::System.IntPtr thread);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SetThreadPriority")]
            internal static extern int SetThreadPriority(global::SharpSDL.ThreadPriority priority);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_WaitThread")]
            internal static extern void WaitThread(global::System.IntPtr thread, int* status);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_DetachThread")]
            internal static extern void DetachThread(global::System.IntPtr thread);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_TLSCreate")]
            internal static extern uint TLSCreate();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_TLSGet")]
            internal static extern global::System.IntPtr TLSGet(uint id);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_TLSSet")]
            internal static extern int TLSSet(uint id, global::System.IntPtr value, global::System.IntPtr destructor);
        }

        /// <summary>Create a thread.</summary>
        public static global::SharpSDL.Thread CreateThread(global::SharpSDL.ThreadFunction fn, string name, global::System.IntPtr data, global::SharpSDL.PfnSDL_CurrentBeginThread pfnBeginThread, global::SharpSDL.PfnSDL_CurrentEndThread pfnEndThread)
        {
            var __arg0 = fn == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(fn);
            var __arg3 = pfnBeginThread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(pfnBeginThread);
            var __arg4 = pfnEndThread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(pfnEndThread);
            var __ret = __Internal.CreateThread(__arg0, name, data, __arg3, __arg4);
            global::SharpSDL.Thread __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Thread.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Thread) global::SharpSDL.Thread.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Thread.__CreateInstance(__ret);
            return __result0;
        }

        public static global::SharpSDL.Thread CreateThreadWithStackSize(global::SharpSDL.Delegates.Func_int_IntPtr fn, string name, ulong stacksize, global::System.IntPtr data, global::SharpSDL.PfnSDL_CurrentBeginThread pfnBeginThread, global::SharpSDL.PfnSDL_CurrentEndThread pfnEndThread)
        {
            var __arg0 = fn == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(fn);
            var __arg4 = pfnBeginThread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(pfnBeginThread);
            var __arg5 = pfnEndThread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(pfnEndThread);
            var __ret = __Internal.CreateThreadWithStackSize(__arg0, name, stacksize, data, __arg4, __arg5);
            global::SharpSDL.Thread __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.Thread.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.Thread) global::SharpSDL.Thread.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.Thread.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>
/// <para>Get the thread name, as it was specified in SDL_CreateThread().</para>
/// <para>This function returns a pointer to a UTF-8 string that names the</para>
/// <para>specified thread, or NULL if it doesn't have a name. This is internal</para>
/// <para>memory, not to be free()'d by the caller, and remains valid until the</para>
/// <para>specified thread is cleaned up by SDL_WaitThread().</para>
/// </summary>
        public static string GetThreadName(global::SharpSDL.Thread thread)
        {
            var __arg0 = ReferenceEquals(thread, null) ? global::System.IntPtr.Zero : thread.__Instance;
            var __ret = __Internal.GetThreadName(__arg0);
            return Marshal.PtrToStringAnsi(__ret);
        }

        /// <summary>Get the thread identifier for the current thread.</summary>
        public static uint ThreadID()
        {
            var __ret = __Internal.ThreadID();
            return __ret;
        }

        /// <summary>Get the thread identifier for the specified thread.</summary>
/// <remarks>Equivalent to SDL_ThreadID() if the specified thread is NULL.</remarks>
        public static uint GetThreadID(global::SharpSDL.Thread thread)
        {
            var __arg0 = ReferenceEquals(thread, null) ? global::System.IntPtr.Zero : thread.__Instance;
            var __ret = __Internal.GetThreadID(__arg0);
            return __ret;
        }

        /// <summary>Set the priority for the current thread</summary>
        public static int SetThreadPriority(global::SharpSDL.ThreadPriority priority)
        {
            var __ret = __Internal.SetThreadPriority(priority);
            return __ret;
        }

        /// <summary>
/// <para>Wait for a thread to finish. Threads that haven't been detached will</para>
/// <para>remain (as a &quot;zombie&quot;) until this function cleans them up. Not doing so</para>
/// <para>is a resource leak.</para>
/// </summary>
/// <remarks>
/// <para>Once a thread has been cleaned up through this function, the SDL_Thread</para>
/// <para>that references it becomes invalid and should not be referenced again.</para>
/// <para>As such, only one thread may call SDL_WaitThread() on another.</para>
/// <para>The return code for the thread function is placed in the area</para>
/// <para>pointed to byifis not NULL.</para>
/// <para>You may not wait on a thread that has been used in a call to</para>
/// <para>SDL_DetachThread(). Use either that function or this one, but not</para>
/// <para>both, or behavior is undefined.</para>
/// <para>It is safe to pass NULL to this function; it is a no-op.</para>
/// </remarks>
        public static void WaitThread(global::SharpSDL.Thread thread, ref int status)
        {
            var __arg0 = ReferenceEquals(thread, null) ? global::System.IntPtr.Zero : thread.__Instance;
            fixed (int* __status1 = &status)
            {
                var __arg1 = __status1;
                __Internal.WaitThread(__arg0, __arg1);
            }
        }

        /// <summary>
/// <para>A thread may be &quot;detached&quot; to signify that it should not remain until</para>
/// <para>another thread has called SDL_WaitThread() on it. Detaching a thread</para>
/// <para>is useful for long-running threads that nothing needs to synchronize</para>
/// <para>with or further manage. When a detached thread is done, it simply</para>
/// <para>goes away.</para>
/// </summary>
/// <remarks>
/// <para>There is no way to recover the return code of a detached thread. If you</para>
/// <para>need this, don't detach the thread and instead use SDL_WaitThread().</para>
/// <para>Once a thread is detached, you should usually assume the SDL_Thread isn't</para>
/// <para>safe to reference again, as it will become invalid immediately upon</para>
/// <para>the detached thread's exit, instead of remaining until someone has called</para>
/// <para>SDL_WaitThread() to finally clean it up. As such, don't detach the same</para>
/// <para>thread more than once.</para>
/// <para>If a thread has already exited when passed to SDL_DetachThread(), it will</para>
/// <para>stop waiting for a call to SDL_WaitThread() and clean up immediately.</para>
/// <para>It is not safe to detach a thread that might be used with SDL_WaitThread().</para>
/// <para>You may not call SDL_WaitThread() on a thread that has been detached.</para>
/// <para>Use either that function or this one, but not both, or behavior is</para>
/// <para>undefined.</para>
/// <para>It is safe to pass NULL to this function; it is a no-op.</para>
/// </remarks>
        public static void DetachThread(global::SharpSDL.Thread thread)
        {
            var __arg0 = ReferenceEquals(thread, null) ? global::System.IntPtr.Zero : thread.__Instance;
            __Internal.DetachThread(__arg0);
        }

        /// <summary>Create an identifier that is globally visible to all threads but refers to data that is thread-specific.</summary>
/// <returns>The newly created thread local storage identifier, or 0 on error</returns>
/// <remarks>
/// <para>SDL_TLSGet()</para>
/// <para>SDL_TLSSet()</para>
/// </remarks>
        public static uint TLSCreate()
        {
            var __ret = __Internal.TLSCreate();
            return __ret;
        }

        /// <summary>Get the value associated with a thread local storage ID for the current thread.</summary>
/// <param name="id">The thread local storage ID</param>
/// <returns>The value associated with the ID for the current thread, or NULL if no value has been set.</returns>
/// <remarks>
/// <para>SDL_TLSCreate()</para>
/// <para>SDL_TLSSet()</para>
/// </remarks>
        public static global::System.IntPtr TLSGet(uint id)
        {
            var __ret = __Internal.TLSGet(id);
            return __ret;
        }

        /// <summary>Set the value associated with a thread local storage ID for the current thread.</summary>
/// <param name="id">The thread local storage ID</param>
/// <param name="value">The value to associate with the ID for the current thread</param>
/// <param name="destructor">A function called when the thread exits, to free the value.</param>
/// <returns>0 on success, -1 on error</returns>
/// <remarks>
/// <para>SDL_TLSCreate()</para>
/// <para>SDL_TLSGet()</para>
/// </remarks>
        public static int TLSSet(uint id, global::System.IntPtr value, global::SharpSDL.Delegates.Action_IntPtr destructor)
        {
            var __arg2 = destructor == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(destructor);
            var __ret = __Internal.TLSSet(id, value, __arg2);
            return __ret;
        }
    }
}
