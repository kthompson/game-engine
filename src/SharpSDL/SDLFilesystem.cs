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
    public unsafe partial class SDL_filesystem
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetBasePath")]
            internal static extern sbyte* GetBasePath();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("SDL2", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="SDL_GetPrefPath")]
            internal static extern sbyte* GetPrefPath([MarshalAs(UnmanagedType.LPStr)] string org, [MarshalAs(UnmanagedType.LPStr)] string app);
        }

        /// <summary>Get the path where the application resides.</summary>
/// <returns>String of base dir in UTF-8 encoding, or NULL on error.</returns>
/// <remarks>
/// <para>Get the &quot;base path&quot;. This is the directory where the application was run</para>
/// <para>from, which is probably the installation directory, and may or may not</para>
/// <para>be the process's current working directory.</para>
/// <para>This returns an absolute path in UTF-8 encoding, and is guaranteed to</para>
/// <para>end with a path separator ('\' on Windows, '/' most other places).</para>
/// <para>The pointer returned by this function is owned by you. Please call</para>
/// <para>SDL_free() on the pointer when you are done with it, or it will be a</para>
/// <para>memory leak. This is not necessarily a fast call, though, so you should</para>
/// <para>call this once near startup and save the string if you need it.</para>
/// <para>Some platforms can't determine the application's path, and on other</para>
/// <para>platforms, this might be meaningless. In such cases, this function will</para>
/// <para>return NULL.</para>
/// <para>SDL_GetPrefPath</para>
/// </remarks>
        public static sbyte* GetBasePath()
        {
            var __ret = __Internal.GetBasePath();
            return __ret;
        }

        /// <summary>Get the user-and-app-specific path where files can be written.</summary>
/// <param name="org">The name of your organization.</param>
/// <param name="app">The name of your application.</param>
/// <returns>
/// <para>UTF-8 string of user dir in platform-dependent notation. NULL</para>
/// <para>if there's a problem (creating directory failed, etc).</para>
/// </returns>
/// <remarks>
/// <para>Get the &quot;pref dir&quot;. This is meant to be where users can write personal</para>
/// <para>files (preferences and save games, etc) that are specific to your</para>
/// <para>application. This directory is unique per user, per application.</para>
/// <para>This function will decide the appropriate location in the native filesystem,</para>
/// <para>create the directory if necessary, and return a string of the absolute</para>
/// <para>path to the directory in UTF-8 encoding.</para>
/// <para>On Windows, the string might look like:</para>
/// <para>&quot;C:\Users\bob\AppData\Roaming\My Company\My Program Name\&quot;</para>
/// <para>On Linux, the string might look like:</para>
/// <para>&quot;/home/bob/.local/share/My Program Name/&quot;</para>
/// <para>On Mac OS X, the string might look like:</para>
/// <para>&quot;/Users/bob/Library/Application Support/My Program Name/&quot;</para>
/// <para>(etc.)</para>
/// <para>You specify the name of your organization (if it's not a real organization,</para>
/// <para>your name or an Internet domain you own might do) and the name of your</para>
/// <para>application. These should be untranslated proper names.</para>
/// <para>Both the org and app strings may become part of a directory name, so</para>
/// <para>please follow these rules:</para>
/// <para>- Try to use the same org string (including case-sensitivity) for</para>
/// <para>all your applications that use this function.</para>
/// <para>- Always use a unique app string for each one, and make sure it never</para>
/// <para>changes for an app once you've decided on it.</para>
/// <para>- Unicode characters are legal, as long as it's UTF-8 encoded, but...</para>
/// <para>- ...only use letters, numbers, and spaces. Avoid punctuation like</para>
/// <para>&quot;Game Name 2: Bad Guy's Revenge!&quot; ... &quot;Game Name 2&quot; is sufficient.</para>
/// <para>This returns an absolute path in UTF-8 encoding, and is guaranteed to</para>
/// <para>end with a path separator ('\' on Windows, '/' most other places).</para>
/// <para>The pointer returned by this function is owned by you. Please call</para>
/// <para>SDL_free() on the pointer when you are done with it, or it will be a</para>
/// <para>memory leak. This is not necessarily a fast call, though, so you should</para>
/// <para>call this once near startup and save the string if you need it.</para>
/// <para>You should assume the path returned by this function is the only safe</para>
/// <para>place to write files (and that SDL_GetBasePath(), while it might be</para>
/// <para>writable, or even the parent of the returned path, aren't where you</para>
/// <para>should be writing things).</para>
/// <para>Some platforms can't determine the pref path, and on other</para>
/// <para>platforms, this might be meaningless. In such cases, this function will</para>
/// <para>return NULL.</para>
/// <para>SDL_GetBasePath</para>
/// </remarks>
        public static sbyte* GetPrefPath(string org, string app)
        {
            var __ret = __Internal.GetPrefPath(org, app);
            return __ret;
        }
    }
}