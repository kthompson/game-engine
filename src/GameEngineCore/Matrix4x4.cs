using System;

namespace GameEngineCore
{
    public struct Matrix4x4
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        public Matrix4x4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public static readonly Matrix4x4 Identity = new Matrix4x4
        {
            M11 = 1,
            M22 = 1,
            M33 = 1,
            M44 = 1,
        };

        public static Matrix4x4 CreatePerspectiveFieldOfView(float fieldOfViewRadians, float aspectRatio, float near,
            float far)
        {
            return new Matrix4x4
            {
                M11 = aspectRatio * fieldOfViewRadians,
                M22 = fieldOfViewRadians,
                M33 = far / (far - near),
                M43 = (-far * near) / (far - near),
                M34 = 1.0f,
                M44 = 0.0f,
            };
        }

        public static Matrix4x4 CreateRotationX(float degreesInRadians) =>
            new Matrix4x4
            {
                M11 = 1,
                M22 = MathF.Cos(degreesInRadians),
                M23 = MathF.Sin(degreesInRadians),
                M32 = -MathF.Sin(degreesInRadians),
                M33 = MathF.Cos(degreesInRadians),
                M44 = 1
            };

        public static Matrix4x4 CreateRotationZ(float degreesInRadians) =>
            new Matrix4x4
            {
                M11 = MathF.Cos(degreesInRadians),
                M12 = MathF.Sin(degreesInRadians),
                M21 = -MathF.Sin(degreesInRadians),
                M22 = MathF.Cos(degreesInRadians),
                M33 = 1,
                M44 = 1,
            };

        public static Matrix4x4 CreateRotationY(float fAngleRad) =>
            new Matrix4x4
            {
                M11 = MathF.Cos(fAngleRad),
                M13 = MathF.Sin(fAngleRad),
                M31 = -MathF.Sin(fAngleRad),
                M22 = 1.0f,
                M33 = MathF.Cos(fAngleRad),
                M44 = 1.0f,
            };

        public static Matrix4x4 CreateTranslation(float x, float y, float z) =>
            new Matrix4x4
            {
                M11 = 1.0f,
                M22 = 1.0f,
                M33 = 1.0f,
                M44 = 1.0f,
                M41 = x,
                M42 = y,
                M43 = z
            };

        public static Matrix4x4 operator *(Matrix4x4 value1, Matrix4x4 value2)
        {
            Matrix4x4 m;

            // First row
            m.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;
            m.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;
            m.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;
            m.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;

            // Second row
            m.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;
            m.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;
            m.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;
            m.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;

            // Third row
            m.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;
            m.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;
            m.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;
            m.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;

            // Fourth row
            m.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;
            m.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;
            m.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;
            m.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;

            return m;
        }

        public static Matrix4x4 CreateLookAt(Vector3 pos, Vector3 target, Vector3 up)
        {
            // Calculate new forward direction
            var newForward = Vector3.Normalize(target - pos);

            // Calculate new Up direction
            var a = newForward * Vector3.Dot(up, newForward);
            var newUp = Vector3.Normalize(up - a);

            // New Right direction is easy, its just cross product
            var newRight = Vector3.Cross(newUp, newForward);

            // Construct Dimensioning and Translation Matrix
            return new Matrix4x4
            {
                M11 = newRight.X,
                M12 = newUp.X,
                M13 = newForward.X,
                M14 = 0.0f,
                M21 = newRight.Y,
                M22 = newUp.Y,
                M23 = newForward.Y,
                M24 = 0.0f,
                M31 = newRight.Z,
                M32 = newUp.Z,
                M33 = newForward.Z,
                M34 = 0.0f,
                M41 = -(pos.X * newRight.X + pos.Y * newUp.X + pos.Z * newForward.X),
                M42 = -(pos.X * newRight.Y + pos.Y * newUp.Y + pos.Z * newForward.Y),
                M43 = -(pos.X * newRight.Z + pos.Y * newUp.Z + pos.Z * newForward.Z),
                M44 = 1.0f,
            };
        }
    }
}