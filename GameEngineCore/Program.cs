using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using SharpSDL;
using Thread = System.Threading.Thread;

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
    }

    internal struct Triangle
    {
        public Triangle(Vector3 a, Vector3 b, Vector3 c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Vector3 A;
        public Vector3 B;
        public Vector3 C;
    }

    internal struct Matrix4x4
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
    }

    internal class Mesh
    {
        public Mesh()
        {
            Triangles = new List<Triangle>();
        }

        public List<Triangle> Triangles { get; }
    }

    internal class Program
    {
        //private static int screenWidth = 160;
        //private static int screenHeight = 100;

        private static void Main(string[] args)
        {
            //var engine = new Demo3d();
            //engine.Run();

            var tetris = new Tetris();
            tetris.Run();
        }
    }
}