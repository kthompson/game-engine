using System;
using System.Runtime.CompilerServices;

namespace GameEngineCore
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float value) : this(value, value, value)
        {
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Zero => new Vector3();
        public static Vector3 UnitX => new Vector3(1.0f, 0.0f, 0.0f);
        public static Vector3 UnitY => new Vector3(0.0f, 1.0f, 0.0f);
        public static Vector3 UnitZ => new Vector3(0.0f, 0.0f, 1.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(
                vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                vector1.Z * vector2.X - vector1.X * vector2.Z,
                vector1.X * vector2.Y - vector1.Y * vector2.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X +
                   vector1.Y * vector2.Y +
                   vector1.Z * vector2.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(Vector3 value)
        {
            float ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
            float length = MathF.Sqrt(ls);
            return new Vector3(value.X / length, value.Y / length, value.Z / length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
        {
            return new Vector3(
                position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
                position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
                position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Length()
        {
            var ls = X * X + Y * Y + Z * Z;
            return MathF.Sqrt(ls);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(Vector3 left, float right)
        {
            return left * new Vector3(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(float left, Vector3 right)
        {
            return new Vector3(left) * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(Vector3 value1, float value2)
        {
            return value1 / new Vector3(value2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 value)
        {
            return Zero - value;
        }
    }
}