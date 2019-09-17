using System.Numerics;

namespace GameEngineCore
{
    internal struct Triangle
    {
        public Triangle(Vector4 a, Vector4 b, Vector4 c, Vector4? color = null)
        {
            A = a;
            B = b;
            C = c;
            Color = color ?? new Vector4(0, 0, 0, 1);
        }

        public Vector4 A;
        public Vector4 B;
        public Vector4 C;
        public Vector4 Color;
    }
}