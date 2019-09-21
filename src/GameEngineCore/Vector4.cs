using System.Runtime.CompilerServices;

namespace GameEngineCore
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector4(float x, float y, float z, float w)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector4 Zero => new Vector4();

        /// <summary>
        /// Returns the vector (1,1,1,1).
        /// </summary>
        public static Vector4 One => new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

        public static Vector4 UnitX => new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        public static Vector4 UnitY => new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
        public static Vector4 UnitZ => new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
        public static Vector4 UnitW => new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 Transform(Vector3 position, Matrix4x4 matrix)
        {
            return new Vector4(
                position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
                position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
                position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43,
                position.X * matrix.M14 + position.Y * matrix.M24 + position.Z * matrix.M34 + matrix.M44);
        }
    }
}