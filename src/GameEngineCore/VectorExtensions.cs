using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace GameEngineCore
{
    public static class VectorExtensions
    {
        public static Vector3 NormalizeW(this Vector4 vector4) =>
            new Vector3(vector4.X / vector4.W, vector4.Y / vector4.W, vector4.Z / vector4.W);
    }
}