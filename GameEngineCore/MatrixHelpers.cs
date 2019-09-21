using System.Numerics;

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
            return new Matrix4x4()
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