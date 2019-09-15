using System;
using System.Collections.Generic;

namespace GameEngineCore
{
    /// <summary>
    /// PROJECTION:
    ///
    ///           ->  Screen(cartisian)
    /// [x, y, z] -> [ (a * F * x) / z, (F*y) / z, z * q - (Znear*q))]
    ///     where a = (h/w)                 => aspect ratio
    ///           F = 1/tan(theta/2)        => field of view
    ///           q = Zfar / (Zfar-Znear)
    ///
    /// Projection Matrix
    /// [     x,     y,          z,   1] [ a*f    0     0    0 ]
    ///                                  [   0    f     0    0 ]
    ///                                  [   0    0     q    1 ]
    /// [ a*F*x,   F*y, Z*q - Zn*q,   Z] [   0    0 -Zn*q    0 ]
    ///
    ///  [ a*F*x,   F*y, Z*q - Zn*q,   Z] =>  [ a*F*x / Z,   F*y / Z, (Z*q - Zn*q) / Z,   Z]
    ///
    /// theta is the angle for the FOV
    ///
    /// Zfar - distance from player to the further view distance
    /// Znear - distance from player to the screen
    ///
    /// -Zfar * Znear / (Zfar - Znear)
    /// </summary>
    internal class Demo3d : ConsoleGameEngine
    {
        private Mesh _cube;
        private Matrix4x4 _projection;
        private Matrix4x4 _rotateX = new Matrix4x4();
        private Matrix4x4 _rotateZ = new Matrix4x4();
        private Vector3 _camera = new Vector3();

        private float theta;

        public Demo3d() : base(512, 480, 4, 4)
        {
        }

        protected override void OnInitialize()
        {
            _cube = Mesh.ReadFromFile("ship_concept.obj");
            //_cube = new Mesh(new List<Triangle>())
            //{
            //    Triangles =
            //    {
            //        // south
            //        new Triangle(new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)),
            //        new Triangle(new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0)),

            //        // east
            //        new Triangle(new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1)),
            //        new Triangle(new Vector3(1, 0, 0), new Vector3(1, 1, 1), new Vector3(1, 0, 1)),

            //        // north
            //        new Triangle(new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1)),
            //        new Triangle(new Vector3(1, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 0, 1)),

            //        // west
            //        new Triangle(new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(0, 1, 0)),
            //        new Triangle(new Vector3(0, 0, 1), new Vector3(0, 1, 0), new Vector3(0, 0, 0)),

            //        // top
            //        new Triangle(new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1)),
            //        new Triangle(new Vector3(0, 1, 0), new Vector3(1, 1, 1), new Vector3(1, 1, 0)),

            //        // bottom
            //        new Triangle(new Vector3(1, 0, 1), new Vector3(0, 0, 1), new Vector3(0, 0, 0)),
            //        new Triangle(new Vector3(1, 0, 1), new Vector3(0, 0, 0), new Vector3(1, 0, 0)),
            //    }
            //};

            // Projection matrix
            var near = 0.1f;
            var far = 1000.0f;
            var fov = 90f; // degrees
            var aspectRatio = (float)this.ScreenHeight / (float)this.ScreenWidth;

            float fovRad = 1f / (float)Math.Tan(fov * 0.5f / 180.0f * Math.PI);

            _projection = new Matrix4x4
            {
                M11 = aspectRatio * fovRad,
                M22 = fovRad,
                M33 = far / (far - near),
                M43 = (-far * near) / (far - near),
                M34 = 1.0f,
                M44 = 0.0f,
            };
        }

        protected override bool OnUpdate(double elapsedMs)
        {
            ClearScreen(GetColor(Color.Cyan));

            theta += (float)(0.001f * elapsedMs);

            // Update Z rotation matrix
            _rotateZ.M11 = (float)Math.Cos(theta);
            _rotateZ.M12 = (float)Math.Sin(theta);
            _rotateZ.M21 = -(float)Math.Sin(theta);
            _rotateZ.M22 = (float)Math.Cos(theta);
            _rotateZ.M33 = 1;
            _rotateZ.M44 = 1;

            // Update X rotation matrix
            _rotateX.M11 = 1;
            _rotateX.M22 = (float)Math.Cos(theta * 0.5f);
            _rotateX.M23 = (float)Math.Sin(theta * 0.5f);
            _rotateX.M32 = -(float)Math.Sin(theta * 0.5f);
            _rotateX.M33 = (float)Math.Cos(theta * 0.5f);
            _rotateX.M44 = 1;

            var trianglesToDraw = new List<Triangle>();

            // Cull Triangles
            foreach (var triangle in _cube.Triangles)
            {
                // rotate in Z axis
                var rotatedZ = MultiplyMatrixVector(triangle, _rotateZ);

                // rotate in X axis
                var rotatedZX = MultiplyMatrixVector(rotatedZ, _rotateX);

                // move triangle back
                var translatedTriangle = rotatedZX;
                translatedTriangle.A.Z += 5.0f;
                translatedTriangle.B.Z += 5.0f;
                translatedTriangle.C.Z += 5.0f;

                // calculate normal

                var line1 = translatedTriangle.B - translatedTriangle.A;
                var line2 = translatedTriangle.C - translatedTriangle.A;

                var normal = Vector3.Cross(line1, line2).Normalize();

                // Get Vector from from A to the camera, and compare to normal
                //
                // We can use any point of the triangle because all points of
                // the triangle are in the same plane
                var dot = Vector3.Dot(normal, translatedTriangle.A - _camera);

                // if dot is less than 0 then the vectors are either perpendicular or
                // facing in the other direction so therefore are not visible
                if (dot < 0f)
                {
                    // project from 3d to 2d screen coordinates
                    var triangleProjected = MultiplyMatrixVector(translatedTriangle, _projection);

                    // Illumination
                    var lightDirection = new Vector3(0, 0, -1)  // toward user
                            .Normalize()
                        ;

                    var dp = Vector3.Dot(normal, lightDirection);
                    triangleProjected.Color = GetColor(dp);

                    // scale into view
                    triangleProjected.A.X += 1.0f;
                    triangleProjected.A.Y += 1.0f;

                    triangleProjected.B.X += 1.0f;
                    triangleProjected.B.Y += 1.0f;

                    triangleProjected.C.X += 1.0f;
                    triangleProjected.C.Y += 1.0f;

                    triangleProjected.A.X *= 0.5f * ScreenWidth;
                    triangleProjected.A.Y *= 0.5f * ScreenHeight;
                    triangleProjected.B.X *= 0.5f * ScreenWidth;
                    triangleProjected.B.Y *= 0.5f * ScreenHeight;
                    triangleProjected.C.X *= 0.5f * ScreenWidth;
                    triangleProjected.C.Y *= 0.5f * ScreenHeight;

                    trianglesToDraw.Add(triangleProjected);
                }
            }

            // sort triangles from back to front
            trianglesToDraw.Sort((t1, t2) =>
            {
                var z1 = (t1.A.Z + t1.B.Z + t1.C.Z) / 3;
                var z2 = (t2.A.Z + t2.B.Z + t2.C.Z) / 3;

                return z1 > z2 ? -1 : z2 > z1 ? 1 : 0;
            });

            foreach (var triangle in trianglesToDraw)
            {
                FillTriangle(
                    (int)triangle.A.X, (int)triangle.A.Y,
                    (int)triangle.B.X, (int)triangle.B.Y,
                    (int)triangle.C.X, (int)triangle.C.Y,
                    triangle.Color
                );
                DrawTriangle(
                    (int)triangle.A.X, (int)triangle.A.Y,
                    (int)triangle.B.X, (int)triangle.B.Y,
                    (int)triangle.C.X, (int)triangle.C.Y,
                    color: GetColor(Color.Black)
                );
            }

            return base.OnUpdate(elapsedMs);
        }

        private Triangle MultiplyMatrixVector(Triangle i, Matrix4x4 m)
        {
            var a = MultiplyMatrixVector(i.A, m);
            var b = MultiplyMatrixVector(i.B, m);
            var c = MultiplyMatrixVector(i.C, m);

            return new Triangle(a, b, c);
        }

        private Vector3 MultiplyMatrixVector(Vector3 i, Matrix4x4 m)
        {
            var x = i.X * m.M11 + i.Y * m.M21 + i.Z * m.M31 + m.M41;
            var y = i.X * m.M12 + i.Y * m.M22 + i.Z * m.M32 + m.M42;
            var z = i.X * m.M13 + i.Y * m.M23 + i.Z * m.M33 + m.M43;
            var w = i.X * m.M14 + i.Y * m.M24 + i.Z * m.M34 + m.M44;
            if (w != 0f)
            {
                x /= w;
                y /= w;
                z /= w;
            }

            return new Vector3(x, y, z);
        }
    }
}