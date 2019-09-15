using System;

namespace GameEngineCore
{
    internal struct Vector3
    {
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X;
        public float Y;
        public float Z;

        public static readonly Vector3 Zero = new Vector3();
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        public Vector3 Normalize()
        {
            // convert to unit vector
            var mag = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            return new Vector3(X / mag, Y / mag, Z / mag);
        }

        public static Vector3 Cross(Vector3 left, Vector3 right) =>
            new Vector3(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X
            );

        public static float Dot(Vector3 a, Vector3 b) =>
            a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static Vector3 operator -(Vector3 left, Vector3 right) =>
            new Vector3(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z
            );

        public static Vector3 operator /(Vector3 left, float right) =>
            new Vector3(
                left.X / right,
                left.Y / right,
                left.Z / right
            );
    }
}