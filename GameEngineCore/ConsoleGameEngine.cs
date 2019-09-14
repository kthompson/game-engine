using System;
using System.Diagnostics;
using System.IO;
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
        private MovingAverage _average = new MovingAverage();

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
            // https://www.youtube.com/watch?v=cWc0hgYwZyc

            if (SDL.Init((uint)InitFlags.SDL_INIT_VIDEO) != 0)
            {
                throw new InvalidOperationException("Failed to init SDL");
            }

            // TODO: enable mouse input

            _window = SDL_video.CreateWindow("Hello World!", 30, 30, ScreenWidth, ScreenHeight, (uint)(WindowFlags.WINDOW_SHOWN | WindowFlags.WINDOW_RESIZABLE));
            if (_window == null)
            {
                SDL.Quit();
                throw new InvalidOperationException("Failed to create window");
            }

            _renderer = SDL_render.CreateRenderer(_window, -1,
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

        public void Run()
        {
            this.Initialize();

            this.Active = true;
            SDL_mouse.ShowCursor(0);

            double t1 = Stopwatch.GetTimestamp();
            var evnt = new Event();
            while (this.Active)
            {
                // Handle Timing
                double t2 = Stopwatch.GetTimestamp();
                var elapsed = (t2 - t1) / TimeSpan.TicksPerMillisecond;
                var elapsedS = (t2 - t1) / TimeSpan.TicksPerSecond;
                t1 = t2;

                // Handle Keyboard Input

                // Handle events - we only care about mouse clicks and movement

                while (SDL_events.PollEvent(evnt) != 0)
                {
                    switch (evnt.Type)
                    {
                        case (uint)EventType.QUIT:
                        case (uint)EventType.KEYDOWN:
                        case (uint)EventType.MOUSEBUTTONDOWN:
                            break;

                        default:
                            Console.WriteLine($"Event: {evnt.Type}");
                            continue;
                    }

                    this.Active = false;
                    break;
                }

                if (!this.OnUpdate(elapsed))
                {
                    this.Active = false;
                }

                SDL_video.SetWindowTitle(_window, $"Console Game Engine - FPS: {1.0 / _average.ComputeAverage(elapsedS):F4}");

                PresentFrame();
            }

            SDL_mouse.ShowCursor(1);
        }

        protected void PresentFrame()
        {
            SDL_render.RenderPresent(_renderer);
        }

        protected virtual bool OnUpdate(double elapsedMs)
        {
            return true;
        }

        protected void Draw(int x, int y, PixelType c = PixelType.PixelSolid, Color color = Color.ForegroundWhite)
        {
            Draw(x, y, (char)c, color);
        }

        protected void Draw(int x, int y, char c = (char)0x2588, Color color = Color.ForegroundWhite)
        {
            if (x >= 0 && x < this.ScreenWidth && y >= 0 && y < this.ScreenHeight)
            {
                SetColor(color);
                SDL_render.RenderDrawPoint(_renderer, x, y);
            }
        }

        private void SetColor(Color color)
        {
            switch (color)
            {
                case Color.ForegroundBlack:
                    SDL_render.SetRenderDrawColor(_renderer, 12, 12, 12, 255);
                    break;

                case Color.ForegroundDarkBlue:
                    SDL_render.SetRenderDrawColor(_renderer, 0, 55, 218, 255);
                    break;

                case Color.ForegroundDarkGreen:
                    SDL_render.SetRenderDrawColor(_renderer, 19, 161, 14, 255);
                    break;

                case Color.ForegroundDarkCyan:
                    SDL_render.SetRenderDrawColor(_renderer, 58, 150, 221, 255);
                    break;

                case Color.ForegroundDarkRed:
                    SDL_render.SetRenderDrawColor(_renderer, 197, 15, 31, 255);
                    break;

                case Color.ForegroundDarkMagenta:
                    SDL_render.SetRenderDrawColor(_renderer, 136, 23, 152, 255);
                    break;

                case Color.ForegroundDarkYellow:
                    SDL_render.SetRenderDrawColor(_renderer, 193, 156, 0, 255);
                    break;

                case Color.ForegroundGrey:
                    SDL_render.SetRenderDrawColor(_renderer, 204, 204, 204, 255);
                    break;

                case Color.ForegroundDarkGrey:
                    SDL_render.SetRenderDrawColor(_renderer, 118, 118, 118, 255);
                    break;

                case Color.ForegroundBlue:
                    SDL_render.SetRenderDrawColor(_renderer, 59, 120, 255, 255);
                    break;

                case Color.ForegroundGreen:
                    SDL_render.SetRenderDrawColor(_renderer, 22, 198, 12, 255);
                    break;

                case Color.ForegroundCyan:
                    SDL_render.SetRenderDrawColor(_renderer, 97, 214, 214, 255);
                    break;

                case Color.ForegroundRed:
                    SDL_render.SetRenderDrawColor(_renderer, 231, 72, 86, 255);
                    break;

                case Color.ForegroundMagenta:
                    SDL_render.SetRenderDrawColor(_renderer, 180, 0, 158, 255);
                    break;

                case Color.ForegroundYellow:
                    SDL_render.SetRenderDrawColor(_renderer, 249, 241, 165, 255);
                    break;

                case Color.ForegroundWhite:
                    SDL_render.SetRenderDrawColor(_renderer, 242, 242, 242, 255);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        protected void DrawString(int x, int y, string s, Color color = Color.ForegroundWhite)
        {
            for (int i = 0; i < s.Length; i++)
            {
                //Draw(x + i, y, s[i], color);
                // TODO
                //_buffer[y * this.ScreenWidth + x + i].UnicodeChar = s[i];
                //_buffer[y * this.ScreenWidth + x + i].Attributes = (ushort)color;
            }
        }

        protected void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, PixelType c = PixelType.PixelSolid, Color color = Color.ForegroundWhite)
        {
            DrawLine(x1, y1, x2, y2, c, color);
            DrawLine(x2, y2, x3, y3, c, color);
            DrawLine(x3, y3, x1, y1, c, color);
        }

        protected void DrawLine(int x1, int y1, int x2, int y2, PixelType c = PixelType.PixelSolid, Color col = Color.ForegroundWhite)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            var dx1 = Math.Abs(dx);
            var dy1 = Math.Abs(dy);

            var px = 2 * dy1 - dx1;
            var py = 2 * dx1 - dy1;

            int x;
            int xe;
            int y;
            int ye;

            if (dy1 <= dx1)
            {
                if (dx >= 0)
                {
                    x = x1;
                    y = y1;
                    xe = x2;
                }
                else
                {
                    x = x2;
                    y = y2;
                    xe = x1;
                }

                Draw(x, y, c, col);

                while (x < xe)
                {
                    x++;
                    if (px < 0)
                    {
                        px += 2 * dy1;
                    }
                    else
                    {
                        if (dx < 0 && dy < 0 || dx > 0 && dy > 0)
                        {
                            y += 1;
                        }
                        else
                        {
                            y -= 1;
                        }

                        px += 2 * (dy1 - dx1);
                    }

                    Draw(x, y, c, col);
                }
            }
            else
            {
                if (dy >= 0)
                {
                    x = x1;
                    y = y1;
                    ye = y2;
                }
                else
                {
                    x = x2;
                    y = y2;
                    ye = y1;
                }

                Draw(x, y, c, col);

                while (y < ye)
                {
                    y += 1;
                    if (py <= 0)
                    {
                        py += 2 * dx1;
                    }
                    else
                    {
                        if (dx < 0 && dy < 0 || dx > 0 && dy > 0)
                        {
                            x += 1;
                        }
                        else
                        {
                            x -= 1;
                        }
                        py += 2 * (dx1 - dy1);
                    }
                    Draw(x, y, c, col);
                }
            }
        }

        private void Clip(ref int x, ref int y)
        {
            if (x < 0) x = 0;
            if (x >= ScreenWidth) x = ScreenWidth;
            if (y < 0) y = 0;
            if (y >= ScreenHeight) y = ScreenHeight;
        }

        protected void ClearScreen(Color color)
        {
            SetColor(color);
            SDL_render.RenderClear(_renderer);
        }

        protected void Fill(int x1, int y1, int x2, int y2, PixelType c = PixelType.PixelSolid, Color color = Color.ForegroundWhite)
        {
            Fill(x1, y1, x2, y2, (char)c, color);
        }

        protected void Fill(int x1, int y1, int x2, int y2, char c, Color color = Color.ForegroundWhite)
        {
            Clip(ref x1, ref y1);
            Clip(ref x2, ref y2);

            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    Draw(x, y, c, color);
                }
            }
        }

        private void ReleaseUnmanagedResources()
        {
            SDL_render.DestroyRenderer(_renderer);
            SDL_video.DestroyWindow(_window);
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