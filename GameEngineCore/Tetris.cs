using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace GameEngineCore
{
    internal class Tetris : ConsoleGameEngine
    {
        private string[] tetrominos = {
            "  X " +
            "  X " +
            "  X " +
            "  X ",

            "  X " +
            " XX " +
            " X  " +
            "    ",

            " X  " +
            " XX " +
            "  X " +
            "    ",

            "    " +
            " XX " +
            " XX " +
            "    ",

            "    " +
            "  X " +
            " XX " +
            "  X ",

            "    " +
            " XXX" +
            " X  " +
            "    ",

            "    " +
            " XXX" +
            "   X" +
            "    ",
        };

        private string _glyphs = " ABCDEFG=#";

        private const int fieldWidth = 12;
        private const int fieldHeight = 18;
        private int[] _field = new int[fieldWidth * fieldHeight];

        private Random rnd = new Random();

        private VirtualKey[] _inputs =
        {
            VirtualKey.RIGHT,
            VirtualKey.LEFT,
            VirtualKey.DOWN,
            VirtualKey.Z,
            VirtualKey.Q,
        };

        // game state
        private bool _gameOver = false;

        private int _currentPiece = 0;
        private int _currentRotation = 0;
        private int _currentX = fieldWidth / 2;
        private int _currentY = 0;

        private bool[] _keyState = new bool[5];
        private bool _rotateHeld = false;
        private int _speed = 20;
        private int _speedCounter = 0;
        private int _pieceCount = 0;
        private int _score = 0;
        private bool _forceDown = false;
        private List<int> _lines = new List<int>();

        public Tetris()
            : base(80, 30, 16, 16)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int x = 0; x < fieldWidth; x++)
            {
                for (int y = 0; y < fieldHeight; y++)
                {
                    _field[y * fieldWidth + x] = (x == 0 || x == fieldWidth - 1 || y == fieldHeight - 1) ? 9 : 0;
                }
            }

            ClearScreen();
            //Fill(0, 0, ScreenWidth, ScreenHeight, ' ');
        }

        protected override bool OnUpdate(double elapsedMs)
        {
            if (_gameOver)
                return false;

            Thread.Sleep(50);
            _speedCounter++;
            var forceDown = _speedCounter == _speed;

            // Collect Input
            for (int k = 0; k < _inputs.Length; k++)
            {
                _keyState[k] = (0x8000 & GetAsyncKeyState(_inputs[k])) != 0;
            }

            // Game logic

            if (_keyState[0] && DoesPieceFit(_currentPiece, _currentRotation, _currentX + 1, _currentY)) // Right
            {
                _currentX += 1;
            }

            if (_keyState[1] && DoesPieceFit(_currentPiece, _currentRotation, _currentX - 1, _currentY)) // Left
            {
                _currentX -= 1;
            }

            if (_keyState[2] && DoesPieceFit(_currentPiece, _currentRotation, _currentX, _currentY + 1)) // Down
            {
                _currentY += 1;
            }

            if (_keyState[3]) // Rotate
            {
                if (!_rotateHeld && DoesPieceFit(_currentPiece, _currentRotation + 1, _currentX, _currentY))
                {
                    _currentRotation += 1;
                }

                _rotateHeld = true;
            }
            else
            {
                _rotateHeld = false;
            }

            if (_keyState[4]) // Quit
            {
                return false;
            }

            if (forceDown)
            {
                if (DoesPieceFit(_currentPiece, _currentRotation, _currentX, _currentY + 1))
                {
                    // force down
                    _currentY++;
                }
                else
                {
                    // piece cant be moved down so lock it into place
                    // lock current piece into the field
                    for (int px = 0; px < 4; px++)
                    {
                        for (int py = 0; py < 4; py++)
                        {
                            if (tetrominos[_currentPiece][Rotate(px, py, _currentRotation)] == 'X')
                            {
                                _field[(_currentY + py) * fieldWidth + _currentX + px] = _currentPiece + 1;
                            }
                        }
                    }

                    // increase speed after 10 pieces
                    _pieceCount++;
                    if (_pieceCount % 10 == 0 && _speed >= 10)
                    {
                        _speed--;
                    }

                    // check for lines
                    for (int py = 0; py < 4; py++)
                    {
                        if (_currentY + py >= fieldHeight - 1)
                            continue;

                        var line = true;
                        // 1 to fieldWidth-1 excludes boundaries
                        for (var px = 1; px < fieldWidth - 1; px++)
                        {
                            line &= (_field[(_currentY + py) * fieldWidth + px]) != 0;
                        }

                        if (!line)
                            continue;

                        for (var px = 1; px < fieldWidth - 1; px++)
                        {
                            _field[(_currentY + py) * fieldWidth + px] = 8; // =
                        }

                        _lines.Add(_currentY + py);
                    }

                    // update score
                    _score += 25;
                    if (_lines.Count > 0)
                    {
                        _score += (1 << _lines.Count) * 100;
                    }

                    // choose next piece
                    _currentX = fieldWidth / 2;
                    _currentY = 0;
                    _currentRotation = 0;
                    _currentPiece = rnd.Next(0, 7);

                    // if next field doesn't fit
                    _gameOver = !DoesPieceFit(_currentPiece, _currentRotation, _currentX, _currentY);
                }

                _speedCounter = 0;
            }

            // Draw Field
            for (int x = 0; x < fieldWidth; x++)
            {
                for (int y = 0; y < fieldHeight; y++)
                {
                    Draw(x + 2, y + 2);
                }
            }

            // Draw Current Piece
            for (int px = 0; px < 4; px++)
            {
                for (int py = 0; py < 4; py++)
                {
                    if (tetrominos[_currentPiece][Rotate(px, py, _currentRotation)] == 'X')
                    {
                        Draw(_currentX + px + 2, _currentY + py + 2);
                    }
                }
            }

            // Draw score
            DrawString(fieldWidth + 6, 2, $"SCORE: {_score:C0}");

            if (_lines.Count > 0)
            {
                // we set our lines to `=======` now present the frame and let them see it
                PresentFrame();
                Thread.Sleep(400);

                // clear the lines
                foreach (var line in _lines)
                {
                    for (int px = 1; px < fieldWidth - 1; px++)
                    {
                        for (int py = line; py > 0; py--)
                        {
                            _field[py * fieldWidth + px] = _field[(py - 1) * fieldWidth + px];
                        }

                        _field[px] = 0;
                    }
                }

                _lines.Clear();
            }

            return base.OnUpdate(elapsedMs);
        }

        private bool DoesPieceFit(int tetromino, int rotation, int posX, int posY)
        {
            for (int px = 0; px < 4; px++)
            {
                for (int py = 0; py < 4; py++)
                {
                    // get index into piece
                    var pi = Rotate(px, py, rotation);

                    // get index into field
                    var fi = (posY + py) * fieldWidth + (posX + px);

                    if (posX + px < 0 || posX + px >= fieldWidth)
                        continue;

                    if (posY + py < 0 || posY + py >= fieldHeight)
                        continue;

                    if (tetrominos[tetromino][pi] == 'X' && _field[fi] != 0)
                        return false;
                }
            }

            return true;
        }

        private int Rotate(int px, int py, int r)
        {
            switch (r % 4)
            {
                case 0:
                    return py * 4 + px; // 0 degrees
                case 1:
                    return 12 + py - (px * 4); // 90 degrees
                case 2:
                    return 15 - (py * 4) - px; // 180 degrees
                case 3:
                    return 3 - py + (px * 4); // 270 degrees
                default:
                    return 0;
            }
        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(VirtualKey vKey);

        private enum VirtualKey : int
        {
            LBUTTON = 0x01,
            RBUTTON = 0x02,
            CANCEL = 0x03,
            MBUTTON = 0x04, /* NOT contiguous with L & RBUTTON */

            XBUTTON1 = 0x05, /* NOT contiguous with L & RBUTTON */
            XBUTTON2 = 0x06, /* NOT contiguous with L & RBUTTON */

            /*
             * 0x07 : reserved
             */

            BACK = 0x08,
            TAB = 0x09,

            /*
             * 0x0A - 0x0B : reserved
             */

            CLEAR = 0x0C,
            RETURN = 0x0D,

            /*
             * 0x0E - 0x0F : unassigned
             */

            SHIFT = 0x10,
            CONTROL = 0x11,
            MENU = 0x12,
            PAUSE = 0x13,
            CAPITAL = 0x14,

            KANA = 0x15,
            HANGEUL = 0x15, /* old name - should be here for compatibility */
            HANGUL = 0x15,

            /*
             * 0x16 : unassigned
             */

            JUNJA = 0x17,
            FINAL = 0x18,
            HANJA = 0x19,
            KANJI = 0x19,

            /*
             * 0x1A : unassigned
             */

            ESCAPE = 0x1B,

            CONVERT = 0x1C,
            NONCONVERT = 0x1D,
            ACCEPT = 0x1E,
            MODECHANGE = 0x1F,

            SPACE = 0x20,
            PRIOR = 0x21,
            NEXT = 0x22,
            END = 0x23,
            HOME = 0x24,
            LEFT = 0x25,
            UP = 0x26,
            RIGHT = 0x27,
            DOWN = 0x28,
            SELECT = 0x29,
            PRINT = 0x2A,
            EXECUTE = 0x2B,
            SNAPSHOT = 0x2C,
            INSERT = 0x2D,
            DELETE = 0x2E,
            HELP = 0x2F,

            Key0 = 0x30,
            Key1 = 0x31,
            Key2 = 0x32,
            Key3 = 0x33,
            Key4 = 0x34,
            Key5 = 0x35,
            Key6 = 0x36,
            Key7 = 0x37,
            Key8 = 0x38,
            Key9 = 0x39,

            /*
             * VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
             * 0x3A - 0x40 : unassigned
             * VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
             */

            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A,

            LWIN = 0x5B,
            RWIN = 0x5C,
            APPS = 0x5D,

            /*
             * 0x5E : reserved
             */

            SLEEP = 0x5F,

            NUMPAD0 = 0x60,
            NUMPAD1 = 0x61,
            NUMPAD2 = 0x62,
            NUMPAD3 = 0x63,
            NUMPAD4 = 0x64,
            NUMPAD5 = 0x65,
            NUMPAD6 = 0x66,
            NUMPAD7 = 0x67,
            NUMPAD8 = 0x68,
            NUMPAD9 = 0x69,
            MULTIPLY = 0x6A,
            ADD = 0x6B,
            SEPARATOR = 0x6C,
            SUBTRACT = 0x6D,
            DECIMAL = 0x6E,
            DIVIDE = 0x6F,
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B,
            F13 = 0x7C,
            F14 = 0x7D,
            F15 = 0x7E,
            F16 = 0x7F,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 0x82,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,

            /*
             * 0x88 - 0x8F : UI navigation
             */

            NAVIGATION_VIEW = 0x88, // reserved
            NAVIGATION_MENU = 0x89, // reserved
            NAVIGATION_UP = 0x8A, // reserved
            NAVIGATION_DOWN = 0x8B, // reserved
            NAVIGATION_LEFT = 0x8C, // reserved
            NAVIGATION_RIGHT = 0x8D, // reserved
            NAVIGATION_ACCEPT = 0x8E, // reserved
            NAVIGATION_CANCEL = 0x8F, // reserved

            NUMLOCK = 0x90,
            SCROLL = 0x91,

            /*
             * NEC PC-9800 kbd definitions
             */
            OEM_NEC_EQUAL = 0x92, // '=' key on numpad

            /*
             * Fujitsu/OASYS kbd definitions
             */
            OEM_FJ_JISHO = 0x92, // 'Dictionary' key
            OEM_FJ_MASSHOU = 0x93, // 'Unregister word' key
            OEM_FJ_TOUROKU = 0x94, // 'Register word' key
            OEM_FJ_LOYA = 0x95, // 'Left OYAYUBI' key
            OEM_FJ_ROYA = 0x96, // 'Right OYAYUBI' key

            /*
             * 0x97 - 0x9F : unassigned
             */

            /*
             * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
             * Used only as parameters to GetAsyncKeyState() and GetKeyState().
             * No other API or message will distinguish left and right keys in this way.
             */
            LSHIFT = 0xA0,
            RSHIFT = 0xA1,
            LCONTROL = 0xA2,
            RCONTROL = 0xA3,
            LMENU = 0xA4,
            RMENU = 0xA5,

            BROWSER_BACK = 0xA6,
            BROWSER_FORWARD = 0xA7,
            BROWSER_REFRESH = 0xA8,
            BROWSER_STOP = 0xA9,
            BROWSER_SEARCH = 0xAA,
            BROWSER_FAVORITES = 0xAB,
            BROWSER_HOME = 0xAC,

            VOLUME_MUTE = 0xAD,
            VOLUME_DOWN = 0xAE,
            VOLUME_UP = 0xAF,
            MEDIA_NEXT_TRACK = 0xB0,
            MEDIA_PREV_TRACK = 0xB1,
            MEDIA_STOP = 0xB2,
            MEDIA_PLAY_PAUSE = 0xB3,
            LAUNCH_MAIL = 0xB4,
            LAUNCH_MEDIA_SELECT = 0xB5,
            LAUNCH_APP1 = 0xB6,
            LAUNCH_APP2 = 0xB7,

            /*
             * 0xB8 - 0xB9 : reserved
             */

            OEM_1 = 0xBA, // ';:' for US
            OEM_PLUS = 0xBB, // '+' any country
            OEM_COMMA = 0xBC, // ',' any country
            OEM_MINUS = 0xBD, // '-' any country
            OEM_PERIOD = 0xBE, // '.' any country
            OEM_2 = 0xBF, // '/?' for US
            OEM_3 = 0xC0, // '`~' for US

            /*
             * 0xC1 - 0xC2 : reserved
             */

            GAMEPAD_A = 0xC3, // reserved
            GAMEPAD_B = 0xC4, // reserved
            GAMEPAD_X = 0xC5, // reserved
            GAMEPAD_Y = 0xC6, // reserved
            GAMEPAD_RIGHT_SHOULDER = 0xC7, // reserved
            GAMEPAD_LEFT_SHOULDER = 0xC8, // reserved
            GAMEPAD_LEFT_TRIGGER = 0xC9, // reserved
            GAMEPAD_RIGHT_TRIGGER = 0xCA, // reserved
            GAMEPAD_DPAD_UP = 0xCB, // reserved
            GAMEPAD_DPAD_DOWN = 0xCC, // reserved
            GAMEPAD_DPAD_LEFT = 0xCD, // reserved
            GAMEPAD_DPAD_RIGHT = 0xCE, // reserved
            GAMEPAD_MENU = 0xCF, // reserved
            GAMEPAD_VIEW = 0xD0, // reserved
            GAMEPAD_LEFT_THUMBSTICK_BUTTON = 0xD1, // reserved
            GAMEPAD_RIGHT_THUMBSTICK_BUTTON = 0xD2, // reserved
            GAMEPAD_LEFT_THUMBSTICK_UP = 0xD3, // reserved
            GAMEPAD_LEFT_THUMBSTICK_DOWN = 0xD4, // reserved
            GAMEPAD_LEFT_THUMBSTICK_RIGHT = 0xD5, // reserved
            GAMEPAD_LEFT_THUMBSTICK_LEFT = 0xD6, // reserved
            GAMEPAD_RIGHT_THUMBSTICK_UP = 0xD7, // reserved
            GAMEPAD_RIGHT_THUMBSTICK_DOWN = 0xD8, // reserved
            GAMEPAD_RIGHT_THUMBSTICK_RIGHT = 0xD9, // reserved
            GAMEPAD_RIGHT_THUMBSTICK_LEFT = 0xDA, // reserved

            OEM_4 = 0xDB, //  '[{' for US
            OEM_5 = 0xDC, //  '\|' for US
            OEM_6 = 0xDD, //  ']}' for US
            OEM_7 = 0xDE, //  ''"' for US
            OEM_8 = 0xDF,

            /*
             * 0xE0 : reserved
             */

            /*
             * Various extended or enhanced keyboards
             */
            OEM_AX = 0xE1, //  'AX' key on Japanese AX kbd
            OEM_102 = 0xE2, //  "<>" or "\|" on RT 102-key kbd.
            ICO_HELP = 0xE3, //  Help key on ICO
            ICO_00 = 0xE4, //  00 key on ICO

            PROCESSKEY = 0xE5,

            ICO_CLEAR = 0xE6,

            PACKET = 0xE7,

            /*
             * 0xE8 : unassigned
             */

            /*
             * Nokia/Ericsson definitions
             */
            OEM_RESET = 0xE9,
            OEM_JUMP = 0xEA,
            OEM_PA1 = 0xEB,
            OEM_PA2 = 0xEC,
            OEM_PA3 = 0xED,
            OEM_WSCTRL = 0xEE,
            OEM_CUSEL = 0xEF,
            OEM_ATTN = 0xF0,
            OEM_FINISH = 0xF1,
            OEM_COPY = 0xF2,
            OEM_AUTO = 0xF3,
            OEM_ENLW = 0xF4,
            OEM_BACKTAB = 0xF5,

            ATTN = 0xF6,
            CRSEL = 0xF7,
            EXSEL = 0xF8,
            EREOF = 0xF9,
            PLAY = 0xFA,
            ZOOM = 0xFB,
            NONAME = 0xFC,
            PA1 = 0xFD,
            OEM_CLEAR = 0xFE,
        }
    }
}