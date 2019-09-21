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
}