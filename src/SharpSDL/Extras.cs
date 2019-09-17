using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SharpSDL
{
    unsafe partial class SDLEvents
    {
        /// <summary>Polls for currently pending events.</summary>
        /// <param name="event">
        /// <para>If not NULL, the next event is removed from the queue and</para>
        /// <para>stored in that area.</para>
        /// </param>
        /// <returns>1 if there are any pending events, or 0 if there are none available.</returns>
        public static int PollEvent2(out global::SharpSDL.Event @event)
        {
            var ____arg0 = new global::SharpSDL.Event.__Internal();
            var __arg0 = new global::System.IntPtr(&____arg0);
            var __ret = __Internal.PollEvent(__arg0);
            @event = Event.__CreateInstance(__arg0);
            return __ret;
        }
    }

    unsafe partial class SDLKeyboard
    {
        public static Span<bool> GetKeyboardState()
        {
            int numKeys = 0;
            var result = GetKeyboardState(ref numKeys);
            var keyboardState = Unsafe.AsRef<bool[]>(result);
            return new Span<bool>(result, numKeys);
        }
    }
}