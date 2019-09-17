using System;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace GameEngineCore
{
    public static class MatrixHelpers
    {
        public static Matrix4x4 CreateProjectionMatrix(float fovRad, float aspectRatio, float near, float far)
        {
            return new Matrix4x4
            {
                M11 = aspectRatio * fovRad,
                M22 = fovRad,
                M33 = far / (far - near),
                M43 = (-far * near) / (far - near),
                M34 = 1.0f,
                M44 = 0.0f,
            };
        }
    }

    public static class VectorExtensions
    {
        public static Vector4 Multiply(this Vector4 vector4, Matrix4x4 m)
        {
            var x = vector4.X * m.M11 + vector4.Y * m.M21 + vector4.Z * m.M31 + vector4.W * m.M41;
            var y = vector4.X * m.M12 + vector4.Y * m.M22 + vector4.Z * m.M32 + vector4.W * m.M42;
            var z = vector4.X * m.M13 + vector4.Y * m.M23 + vector4.Z * m.M33 + vector4.W * m.M43;
            var w = vector4.X * m.M14 + vector4.Y * m.M24 + vector4.Z * m.M34 + vector4.W * m.M44;

            return new Vector4(x, y, z, w);
        }

        public static Vector3 DropW(this Vector4 vector4) =>
            new Vector3(vector4.X, vector4.Y, vector4.Z);

        public static Vector4 ToVector4(this Vector3 vector3) =>
            new Vector4(vector3, 1);
    }

    //internal struct Vector3
    //{
    //    public Vector3(float x, float y, float z, float w = 1)
    //    {
    //        X = x;
    //        Y = y;
    //        Z = z;
    //        W = w;
    //    }

    //    public float X;
    //    public float Y;
    //    public float Z;
    //    public float W;

    //    public static readonly Vector3 Zero = new Vector3();
    //    public static readonly Vector3 One = new Vector3(1, 1, 1);

    //    public float Length() => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

    //    public Vector3 Normalize() => this / this.Length();

    //    public static Vector3 Cross(Vector3 left, Vector3 right) =>
    //        new Vector3(
    //            left.Y * right.Z - left.Z * right.Y,
    //            left.Z * right.X - left.X * right.Z,
    //            left.X * right.Y - left.Y * right.X
    //        );

    //    public static float Dot(Vector3 a, Vector3 b) =>
    //        a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    //    public static Vector3 operator -(Vector3 left, Vector3 right) =>
    //        new Vector3(
    //            left.X - right.X,
    //            left.Y - right.Y,
    //            left.Z - right.Z
    //        );

    //    public static Vector3 operator /(Vector3 left, float right) =>
    //        new Vector3(
    //            left.X / right,
    //            left.Y / right,
    //            left.Z / right
    //        );
    //  }
}