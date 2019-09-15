namespace GameEngineCore
{
    internal struct Triangle
    {
        public Triangle(Vector3 a, Vector3 b, Vector3 c, Vector3? color = null)
        {
            A = a;
            B = b;
            C = c;
            Color = color ?? Vector3.Zero;
        }

        public Vector3 A;
        public Vector3 B;
        public Vector3 C;
        public Vector3 Color;
    }
}