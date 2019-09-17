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
    public enum SensorType
    {
        /// <summary>Returned for an invalid sensor</summary>
        SENSOR_INVALID = -1,
        /// <summary>Unknown sensor type</summary>
        SENSOR_UNKNOWN = 0,
        /// <summary>Accelerometer</summary>
        SENSOR_ACCEL = 1,
        /// <summary>Gyroscope</summary>
        SENSOR_GYRO = 2
    }

    /// <summary>
/// <para>This is a unique ID for a sensor for the time it is connected to the system,</para>
/// <para>and is never reused for the lifetime of the application.</para>
/// </summary>
/// <remarks>The ID value starts at 0 and increments from there. The value -1 is an invalid ID.</remarks>
    /// <summary>SDL_sensor.h</summary>
/// <remarks>
/// <para>In order to use these functions, SDL_Init() must have been called</para>
/// <para>with the ::SDL_INIT_SENSOR flag.  This causes SDL to scan the system</para>
/// <para>for sensors, and load appropriate drivers.</para>
/// </remarks>
    public unsafe partial class SDL_Sensor
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.SDL_Sensor> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::SharpSDL.SDL_Sensor>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::SharpSDL.SDL_Sensor __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::SharpSDL.SDL_Sensor(native.ToPointer(), skipVTables);
        }

        internal static global::SharpSDL.SDL_Sensor __CreateInstance(global::SharpSDL.SDL_Sensor.__Internal native, bool skipVTables = false)
        {
            return new global::SharpSDL.SDL_Sensor(native, skipVTables);
        }

        private static void* __CopyValue(global::SharpSDL.SDL_Sensor.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::SharpSDL.SDL_Sensor.__Internal));
            *(global::SharpSDL.SDL_Sensor.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private SDL_Sensor(global::SharpSDL.SDL_Sensor.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected SDL_Sensor(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class SDLSensor
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_NumSensors")]
            internal static extern int NumSensors();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetDeviceName")]
            internal static extern global::System.IntPtr SensorGetDeviceName(int device_index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetDeviceType")]
            internal static extern global::SharpSDL.SensorType SensorGetDeviceType(int device_index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetDeviceNonPortableType")]
            internal static extern int SensorGetDeviceNonPortableType(int device_index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetDeviceInstanceID")]
            internal static extern int SensorGetDeviceInstanceID(int device_index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorOpen")]
            internal static extern global::System.IntPtr SensorOpen(int device_index);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorFromInstanceID")]
            internal static extern global::System.IntPtr SensorFromInstanceID(int instance_id);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetName")]
            internal static extern global::System.IntPtr SensorGetName(global::System.IntPtr sensor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetType")]
            internal static extern global::SharpSDL.SensorType SensorGetType(global::System.IntPtr sensor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetNonPortableType")]
            internal static extern int SensorGetNonPortableType(global::System.IntPtr sensor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetInstanceID")]
            internal static extern int SensorGetInstanceID(global::System.IntPtr sensor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorGetData")]
            internal static extern int SensorGetData(global::System.IntPtr sensor, float* data, int num_values);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorClose")]
            internal static extern void SensorClose(global::System.IntPtr sensor);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_SensorUpdate")]
            internal static extern void SensorUpdate();
        }

        /// <summary>Count the number of sensors attached to the system right now</summary>
        public static int NumSensors()
        {
            var __ret = __Internal.NumSensors();
            return __ret;
        }

        /// <summary>Get the implementation dependent name of a sensor.</summary>
/// <returns>The sensor name, or NULL if device_index is out of range.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static string SensorGetDeviceName(int device_index)
        {
            var __ret = __Internal.SensorGetDeviceName(device_index);
            return Marshal.PtrToStringAnsi(__ret);
        }

        /// <summary>Get the type of a sensor.</summary>
/// <returns>The sensor type, or SDL_SENSOR_INVALID if device_index is out of range.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static global::SharpSDL.SensorType SensorGetDeviceType(int device_index)
        {
            var __ret = __Internal.SensorGetDeviceType(device_index);
            return __ret;
        }

        /// <summary>Get the platform dependent type of a sensor.</summary>
/// <returns>The sensor platform dependent type, or -1 if device_index is out of range.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static int SensorGetDeviceNonPortableType(int device_index)
        {
            var __ret = __Internal.SensorGetDeviceNonPortableType(device_index);
            return __ret;
        }

        /// <summary>Get the instance ID of a sensor.</summary>
/// <returns>The sensor instance ID, or -1 if device_index is out of range.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static int SensorGetDeviceInstanceID(int device_index)
        {
            var __ret = __Internal.SensorGetDeviceInstanceID(device_index);
            return __ret;
        }

        /// <summary>Open a sensor for use.</summary>
/// <returns>A sensor identifier, or NULL if an error occurred.</returns>
/// <remarks>The index passed as an argument refers to the N'th sensor on the system.</remarks>
        public static global::SharpSDL.SDL_Sensor SensorOpen(int device_index)
        {
            var __ret = __Internal.SensorOpen(device_index);
            global::SharpSDL.SDL_Sensor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.SDL_Sensor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.SDL_Sensor) global::SharpSDL.SDL_Sensor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.SDL_Sensor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Return the SDL_Sensor associated with an instance id.</summary>
        public static global::SharpSDL.SDL_Sensor SensorFromInstanceID(int instance_id)
        {
            var __ret = __Internal.SensorFromInstanceID(instance_id);
            global::SharpSDL.SDL_Sensor __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::SharpSDL.SDL_Sensor.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::SharpSDL.SDL_Sensor) global::SharpSDL.SDL_Sensor.NativeToManagedMap[__ret];
            else __result0 = global::SharpSDL.SDL_Sensor.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>Get the implementation dependent name of a sensor.</summary>
/// <returns>The sensor name, or NULL if the sensor is NULL.</returns>
        public static string SensorGetName(global::SharpSDL.SDL_Sensor sensor)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            var __ret = __Internal.SensorGetName(__arg0);
            return Marshal.PtrToStringAnsi(__ret);
        }

        /// <summary>Get the type of a sensor.</summary>
/// <returns>The sensor type, or SDL_SENSOR_INVALID if the sensor is NULL.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static global::SharpSDL.SensorType SensorGetType(global::SharpSDL.SDL_Sensor sensor)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            var __ret = __Internal.SensorGetType(__arg0);
            return __ret;
        }

        /// <summary>Get the platform dependent type of a sensor.</summary>
/// <returns>The sensor platform dependent type, or -1 if the sensor is NULL.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static int SensorGetNonPortableType(global::SharpSDL.SDL_Sensor sensor)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            var __ret = __Internal.SensorGetNonPortableType(__arg0);
            return __ret;
        }

        /// <summary>Get the instance ID of a sensor.</summary>
/// <returns>The sensor instance ID, or -1 if the sensor is NULL.</returns>
/// <remarks>This can be called before any sensors are opened.</remarks>
        public static int SensorGetInstanceID(global::SharpSDL.SDL_Sensor sensor)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            var __ret = __Internal.SensorGetInstanceID(__arg0);
            return __ret;
        }

        /// <summary>Get the current state of an opened sensor.</summary>
/// <param name="sensor">The sensor to query</param>
/// <param name="data">A pointer filled with the current sensor state</param>
/// <param name="num_values">The number of values to write to data</param>
/// <returns>0 or -1 if an error occurred.</returns>
/// <remarks>The number of values and interpretation of the data is sensor dependent.</remarks>
        public static int SensorGetData(global::SharpSDL.SDL_Sensor sensor, ref float data, int num_values)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            fixed (float* __data1 = &data)
            {
                var __arg1 = __data1;
                var __ret = __Internal.SensorGetData(__arg0, __arg1, num_values);
                return __ret;
            }
        }

        /// <summary>Close a sensor previously opened with SDL_SensorOpen()</summary>
        public static void SensorClose(global::SharpSDL.SDL_Sensor sensor)
        {
            var __arg0 = ReferenceEquals(sensor, null) ? global::System.IntPtr.Zero : sensor.__Instance;
            __Internal.SensorClose(__arg0);
        }

        /// <summary>Update the current state of the open sensors.</summary>
/// <remarks>
/// <para>This is called automatically by the event loop if sensor events are enabled.</para>
/// <para>This needs to be called from the thread that initialized the sensor subsystem.</para>
/// </remarks>
        public static void SensorUpdate()
        {
            __Internal.SensorUpdate();
        }
    }
}
