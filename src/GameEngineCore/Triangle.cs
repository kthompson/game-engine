namespace GameEngineCore
{
    internal struct Triangle
    {
        public Triangle(Vector3 a, Vector3 b, Vector3 c, Vector4? color = null)
        {
            A = a;
            B = b;
            C = c;
            Color = color ?? new Vector4(0, 0, 0, 1);
        }

        public Vector3 A;
        public Vector3 B;
        public Vector3 C;
        public Vector4 Color;
    }
}