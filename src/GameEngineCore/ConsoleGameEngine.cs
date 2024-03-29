﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.Win32.SafeHandles;
using SharpSDL;

namespace GameEngineCore
{
    internal class ConsoleGameEngine : IDisposable
    {
        private Window _window;
        private Renderer _renderer;
        private readonly MovingAverage _average = new MovingAverage();

        public int ScreenWidth { get; }
        public int ScreenHeight { get; }
        public int FontWidth { get; }
        public int FontHeight { get; }
        public bool Active { get; private set; }

        public ConsoleGameEngine(int screenWidth, int screenHeight, int fontWidth, int fontHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            FontWidth = fontWidth;
            FontHeight = fontHeight;
        }

        private void Initialize()
        {
            if (SDL.Init((uint)InitFlags.SDL_INIT_VIDEO) != 0)
            {
                throw new InvalidOperationException("Failed to init SDL");
            }

            // TODO: enable mouse input

            _window = SDLVideo.CreateWindow("Hello World!", 30, 30, ScreenWidth, ScreenHeight, (uint)(WindowFlags.WINDOW_SHOWN | WindowFlags.WINDOW_RESIZABLE));
            if (_window == null)
            {
                SDL.Quit();
                throw new InvalidOperationException("Failed to create window");
            }

            _renderer = SDLRender.CreateRenderer(_window, -1,
                (uint)(RendererFlags.RENDERER_ACCELERATED));

            if (_renderer == null)
            {
                SDL.Quit();
                throw new InvalidOperationException("Failed to create renderer");
            }

            this.OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        private bool[] _lastKeys = null;
        private bool[] _keys = null;

        protected bool IsKeyPressed(ScanCode code) =>
            _keys[(int)code];

        protected bool IsKeyUp(ScanCode code) =>
            _keys[(int)code] == false && _lastKeys != null && _lastKeys[(int)code];

        protected bool IsKeyHeld(ScanCode code) =>
            _keys[(int)code] && _lastKeys != null && _lastKeys[(int)code];

        public void Run()
        {
            this.Initialize();

            this.Active = true;
            SDLMouse.ShowCursor(0);

            double t1 = Stopwatch.GetTimestamp();
            //var evnt = new Event();
            while (this.Active)
            {
                // Handle Timing
                double t2 = Stopwatch.GetTimestamp();
                var elapsedTicks = t2 - t1;
                var elapsed = elapsedTicks / TimeSpan.TicksPerMillisecond;
                var elapsedS = elapsedTicks / TimeSpan.TicksPerSecond;
                t1 = t2;

                // Handle Keyboard Input

                _lastKeys = _keys;
                _keys = SDLKeyboard.GetKeyboardState().ToArray();

                // Handle events - we only care about mouse clicks and movement
                while (SDLEvents.PollEvent2(out var evnt) != 0)
                {
                    switch (evnt.Type)
                    {
                        case (uint)EventType.QUIT:
                            break;

                        case (uint)EventType.KEYDOWN:
                            continue;

                        default:
                            Console.WriteLine($"Event: {evnt.Type}");
                            continue;
                    }

                    this.Active = false;
                    break;
                }

                if (!this.OnUpdate(elapsedS))
                {
                    this.Active = false;
                }

                SDLVideo.SetWindowTitle(_window, $"Console Game Engine - FPS: {1.0 / elapsedS:F4}");

                PresentFrame();
            }

            SDLMouse.ShowCursor(1);
        }

        protected void PresentFrame()
        {
            SDLRender.RenderPresent(_renderer);
        }

        protected virtual bool OnUpdate(double elapsedSeconds)
        {
            return true;
        }

        protected void Draw(int x, int y, Vector4? color = null)
        {
            if (x >= 0 && x < this.ScreenWidth && y >= 0 && y < this.ScreenHeight)
            {
                SetColor(color ?? Vector4.One);
                SDLRender.RenderDrawPoint(_renderer, x, y);
            }
        }

        protected Vector4 GetColor(float value)
        {
            // value is in -1 to 1

            if (value < 0)
            {
                //var f = 255 - (int)(255 * value);
                //var step = f / 32;
                //return new Vector3(step * 32, step * 32, step * 32);
                return Vector4.UnitW;
            }
            else
            {
                var f = (int)(16 * value) * 12;
                return new Vector4(f, f, f, 1);
            }
        }

        protected Vector4 GetColor(Color color)
        {
            var b = 255f;
            switch (color)
            {
                case Color.Black:
                    return new Vector4(12 / b, 12 / b, 12 / b, 1);

                case Color.DarkBlue:
                    return new Vector4(0, 55 / b, 218 / b, 1);

                case Color.DarkGreen:
                    return new Vector4(19 / b, 161 / b, 14 / b, 1);

                case Color.DarkCyan:
                    return new Vector4(58 / b, 150 / b, 221 / b, 1);

                case Color.DarkRed:
                    return new Vector4(197 / b, 15 / b, 31 / b, 1);

                case Color.DarkMagenta:
                    return new Vector4(136 / b, 23 / b, 152 / b, 1);

                case Color.DarkYellow:
                    return new Vector4(193 / b, 156 / b, 0 / b, 1);

                case Color.Grey:
                    return new Vector4(204 / b, 204 / b, 204 / b, 1);

                case Color.DarkGrey:
                    return new Vector4(118 / b, 118 / b, 118 / b, 1);

                case Color.Blue:
                    return new Vector4(59 / b, 120 / b, 255 / b, 1);

                case Color.Green:
                    return new Vector4(22 / b, 198 / b, 12 / b, 1);

                case Color.Cyan:
                    return new Vector4(97 / b, 214 / b, 214 / b, 1);

                case Color.Red:
                    return new Vector4(231 / b, 72 / b, 86 / b, 1);

                case Color.Magenta:
                    return new Vector4(180 / b, 0, 158 / b, 1);

                case Color.Yellow:
                    return new Vector4(249 / b, 241 / b, 165 / b, 1);

                case Color.White:
                    return new Vector4(242 / b, 242 / b, 242 / b, 1);

                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        private void SetColor(Vector4 color)
        {
            SDLRender.SetRenderDrawColor(_renderer, (byte)(color.X * 255), (byte)(color.Y * 255), (byte)(color.Z * 255), (byte)(color.W * 255));
        }

        protected void DrawString(int x, int y, string s, Color color = Color.White)
        {
            int keys;

            for (int i = 0; i < s.Length; i++)
            {
                //Draw(x + i, y, s[i], color);
                // TODO
                //_buffer[y * this.ScreenWidth + x + i].UnicodeChar = s[i];
                //_buffer[y * this.ScreenWidth + x + i].Attributes = (ushort)color;
            }
        }

        protected void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Vector4? color)
        {
            DrawLine(x1, y1, x2, y2, color);
            DrawLine(x2, y2, x3, y3, color);
            DrawLine(x3, y3, x1, y1, color);
        }

        // https://www.avrfreaks.net/sites/default/files/triangles.c
        protected void FillTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Vector4? col)
        {
            void Swap(ref int swapX, ref int swapY)
            {
                var t = swapX;
                swapX = swapY;
                swapY = t;
            }

            void Drawline(int sx, int ex, int ny)
            {
                DrawLine(sx, ny, ex, ny, col);
            };

            int t2x;
            int y;
            int minx;
            int maxx;
            int t1xp;
            int t2xp;
            bool changed1 = false;
            bool changed2 = false;
            int signx1, signx2;
            int e1;
            // Sort vertices
            if (y1 > y2)
            {
                Swap(ref y1, ref y2);
                Swap(ref x1, ref x2);
            }

            if (y1 > y3)
            {
                Swap(ref y1, ref y3);
                Swap(ref x1, ref x3);
            }

            if (y2 > y3)
            {
                Swap(ref y2, ref y3);
                Swap(ref x2, ref x3);
            }

            var t1x = t2x = x1; y = y1;   // Starting points
            var dx1 = (int)(x2 - x1);
            if (dx1 < 0)
            {
                dx1 = -dx1;
                signx1 = -1;
            }
            else
            {
                signx1 = 1;
            }
            var dy1 = (int)(y2 - y1);

            var dx2 = (int)(x3 - x1);
            if (dx2 < 0)
            {
                dx2 = -dx2;
                signx2 = -1;
            }
            else
            {
                signx2 = 1;
            }
            var dy2 = (int)(y3 - y1);

            if (dy1 > dx1)
            {   // swap values
                Swap(ref dx1, ref dy1);
                changed1 = true;
            }
            if (dy2 > dx2)
            {   // swap values
                Swap(ref dy2, ref dx2);
                changed2 = true;
            }

            var e2 = (int)(dx2 >> 1);
            // Flat top, just process the second half
            if (y1 == y2)
            {
                goto next;
            }
            e1 = (int)(dx1 >> 1);

            for (int i = 0; i < dx1;)
            {
                t1xp = 0; t2xp = 0;
                if (t1x < t2x)
                {
                    minx = t1x;
                    maxx = t2x;
                }
                else
                {
                    minx = t2x;
                    maxx = t1x;
                }
                // process first line until y value is about to change
                while (i < dx1)
                {
                    i++;
                    e1 += dy1;
                    while (e1 >= dx1)
                    {
                        e1 -= dx1;
                        if (changed1)
                        {
                            t1xp = signx1;
                            //t1x += signx1;
                        }
                        else
                        {
                            goto next1;
                        }
                    }

                    if (changed1)
                    {
                        break;
                    }
                    else
                    {
                        t1x += signx1;
                    }
                }
            // Move line
            next1:
                // process second line until y value is about to change
                while (true)
                {
                    e2 += dy2;
                    while (e2 >= dx2)
                    {
                        e2 -= dx2;
                        if (changed2)
                        {
                            t2xp = signx2; //t2x += signx2;
                        }
                        else
                        {
                            goto next2;
                        }
                    }

                    if (changed2)
                    {
                        break;
                    }
                    else
                    {
                        t2x += signx2;
                    }
                }
            next2:
                if (minx > t1x)
                {
                    minx = t1x;
                }

                if (minx > t2x)
                {
                    minx = t2x;
                }

                if (maxx < t1x)
                {
                    maxx = t1x;
                }

                if (maxx < t2x)
                {
                    maxx = t2x;
                }
                DrawLine(minx, y, maxx, y, col);    // Draw line from min to max points found on the y
                                                    // Now increase y
                if (!changed1) t1x += signx1;
                t1x += t1xp;
                if (!changed2) t2x += signx2;
                t2x += t2xp;
                y += 1;
                if (y == y2) break;
            }
        next:
            // Second half
            dx1 = (int)(x3 - x2);
            if (dx1 < 0)
            {
                dx1 = -dx1;
                signx1 = -1;
            }
            else
            {
                signx1 = 1;
            }
            dy1 = (int)(y3 - y2);
            t1x = x2;

            if (dy1 > dx1)
            {   // swap values
                Swap(ref dy1, ref dx1);
                changed1 = true;
            }
            else
            {
                changed1 = false;
            }

            e1 = (int)(dx1 >> 1);

            for (var i = 0; i <= dx1; i++)
            {
                t1xp = 0; t2xp = 0;
                if (t1x < t2x)
                {
                    minx = t1x;
                    maxx = t2x;
                }
                else
                {
                    minx = t2x;
                    maxx = t1x;
                }
                // process first line until y value is about to change
                while (i < dx1)
                {
                    e1 += dy1;
                    while (e1 >= dx1)
                    {
                        e1 -= dx1;
                        if (changed1) { t1xp = signx1; break; }//t1x += signx1;
                        else goto next3;
                    }
                    if (changed1) break;
                    else t1x += signx1;
                    if (i < dx1) i++;
                }
            next3:
                // process second line until y value is about to change
                while (t2x != x3)
                {
                    e2 += dy2;
                    while (e2 >= dx2)
                    {
                        e2 -= dx2;
                        if (changed2)
                        {
                            t2xp = signx2;
                        }
                        else
                        {
                            goto next4;
                        }
                    }

                    if (changed2)
                    {
                        break;
                    }
                    else
                    {
                        t2x += signx2;
                    }
                }
            next4:

                if (minx > t1x)
                {
                    minx = t1x;
                }

                if (minx > t2x)
                {
                    minx = t2x;
                }

                if (maxx < t1x)
                {
                    maxx = t1x;
                }

                if (maxx < t2x)
                {
                    maxx = t2x;
                }
                DrawLine(minx, y, maxx, y, col);
                if (!changed1)
                {
                    t1x += signx1;
                }
                t1x += t1xp;
                if (!changed2)
                {
                    t2x += signx2;
                }
                t2x += t2xp;
                y += 1;
                if (y > y3) return;
            }
        }

        protected void DrawLine(int x1, int y1, int x2, int y2, Vector4? col = null)
        {
            SetColor(col ?? Vector4.One);
            SDLRender.RenderDrawLine(_renderer, x1, y1, x2, y2);

            //var dx = x2 - x1;
            //var dy = y2 - y1;
            //var dx1 = Math.Abs(dx);
            //var dy1 = Math.Abs(dy);

            //var px = 2 * dy1 - dx1;
            //var py = 2 * dx1 - dy1;

            //int x;
            //int xe;
            //int y;
            //int ye;

            //if (dy1 <= dx1)
            //{
            //    if (dx >= 0)
            //    {
            //        x = x1;
            //        y = y1;
            //        xe = x2;
            //    }
            //    else
            //    {
            //        x = x2;
            //        y = y2;
            //        xe = x1;
            //    }

            //    Draw(x, y, col);

            //    while (x < xe)
            //    {
            //        x++;
            //        if (px < 0)
            //        {
            //            px += 2 * dy1;
            //        }
            //        else
            //        {
            //            if (dx < 0 && dy < 0 || dx > 0 && dy > 0)
            //            {
            //                y += 1;
            //            }
            //            else
            //            {
            //                y -= 1;
            //            }

            //            px += 2 * (dy1 - dx1);
            //        }

            //        Draw(x, y, col);
            //    }
            //}
            //else
            //{
            //    if (dy >= 0)
            //    {
            //        x = x1;
            //        y = y1;
            //        ye = y2;
            //    }
            //    else
            //    {
            //        x = x2;
            //        y = y2;
            //        ye = y1;
            //    }

            //    Draw(x, y, col);

            //    while (y < ye)
            //    {
            //        y += 1;
            //        if (py <= 0)
            //        {
            //            py += 2 * dx1;
            //        }
            //        else
            //        {
            //            if (dx < 0 && dy < 0 || dx > 0 && dy > 0)
            //            {
            //                x += 1;
            //            }
            //            else
            //            {
            //                x -= 1;
            //            }
            //            py += 2 * (dx1 - dy1);
            //        }
            //        Draw(x, y, col);
            //    }
            //}
        }

        private void Clip(ref int x, ref int y)
        {
            if (x < 0) x = 0;
            if (x >= ScreenWidth) x = ScreenWidth;
            if (y < 0) y = 0;
            if (y >= ScreenHeight) y = ScreenHeight;
        }

        protected void ClearScreen(Vector4? color = null)
        {
            SetColor(color ?? GetColor(Color.Cyan));
            SDLRender.RenderClear(_renderer);
        }

        protected void Fill(int x1, int y1, int x2, int y2, Vector4? color = null)
        {
            Clip(ref x1, ref y1);
            Clip(ref x2, ref y2);

            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    Draw(x, y, color);
                }
            }
        }

        private void ReleaseUnmanagedResources()
        {
            SDLRender.DestroyRenderer(_renderer);
            SDLVideo.DestroyWindow(_window);
            SDL.Quit();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~ConsoleGameEngine()
        {
            ReleaseUnmanagedResources();
        }
    }
}