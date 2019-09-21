using System;
using System.Collections.Generic;
using System.Numerics;
using SharpSDL;

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
        private Vector3 _camera = Vector3.Zero;
        private Vector3 _lookDirection = Vector3.UnitZ;
        private float _yaw = 0;

        private Vector3 OffsetOfView = new Vector3(1, 1, 0);

        private float theta;

        public Demo3d() : base(512, 480, 4, 4)
        {
        }

        protected override void OnInitialize()
        {
            //_cube = Mesh.ReadFromFile("ship_concept.obj");
            _cube = Mesh.ReadFromFile("axis.obj");

            // Projection matrix
            var near = 0.1f;
            var far = 1000.0f;
            var fov = 90f; // degrees
            var aspectRatio = (float)this.ScreenHeight / (float)this.ScreenWidth;

            float fovRad = 1f / (float)Math.Tan(fov * 0.5f / 180.0f * Math.PI);

            _projection = MatrixHelpers.CreateProjectionMatrix(fovRad, aspectRatio, near, far);
            // this doesn't work for some reason
            //_projection = Matrix4x4.CreatePerspectiveFieldOfView(fovRad, aspectRatio, near, far);
        }

        protected override bool OnUpdate(double elapsedSeconds)
        {
            ClearScreen(GetColor(Color.Cyan));

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_Q))
            {
                return false;
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_UP))
            {
                _camera.Y += (float)(8f * elapsedSeconds);
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_DOWN))
            {
                _camera.Y -= (float)(8f * elapsedSeconds);
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_LEFT))
            {
                _camera.X -= (float)(8f * elapsedSeconds);
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_RIGHT))
            {
                _camera.X += (float)(8f * elapsedSeconds);
            }

            // forward and back should move along the axis we are facing
            // velocity vector
            var forward = _lookDirection * (float)(8.0f * elapsedSeconds);

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_W))
            {
                _camera += forward;
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_S))
            {
                _camera -= forward;
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_A))
            {
                _yaw -= (float)(2.0f * elapsedSeconds);
            }

            if (IsKeyPressed(ScanCode.SDL_SCANCODE_D))
            {
                _yaw += (float)(2.0f * elapsedSeconds);
            }

            //theta += (float)(0.001f * elapsedMs);

            // Update Z rotation matrix
            _rotateZ = Matrix4x4.CreateRotationZ(theta * 0.5f);

            // Update X rotation matrix
            _rotateX = Matrix4x4.CreateRotationX(theta);

            var translation = Matrix4x4.CreateTranslation(0, 0, 5);

            // build world matrix
            var world = _rotateZ * _rotateX * translation;

            var up = Vector3.UnitY;
            var target = Vector3.UnitZ;

            _lookDirection = Vector3.Transform(target, Matrix4x4.CreateRotationY(_yaw));

            target = _camera + _lookDirection;

            //var view = Matrix4x4.CreateLookAt(_camera, target, up);
            var view = MatrixHelpers.CreateLookAt(_camera, target, up);

            var trianglesToDraw = new List<Triangle>();

            // Cull Triangles
            foreach (var triangle in _cube.Triangles)
            {
                var transformedTriangle = MultiplyMatrixVector(triangle, world);

                // calculate normal
                var line1 = transformedTriangle.B - transformedTriangle.A;
                var line2 = transformedTriangle.C - transformedTriangle.A;

                var normal = Vector3.Cross(line1, line2);
                var normalizedNormal = Vector3.Normalize(normal);

                // Get Vector from from A to the camera, and compare to normal
                //
                // We can use any point of the triangle because all points of
                // the triangle are in the same plane
                var cameraRay = transformedTriangle.A - _camera;

                // if dot is less than 0 then the vectors are either perpendicular or
                // facing in the other direction so therefore are not visible
                if (!(Vector3.Dot(normalizedNormal, cameraRay) < 0f)) continue;

                // Illumination
                var lightDirection = new Vector3(0, 1.0f, -1);
                var normalizedLightDirection = Vector3.Normalize(lightDirection);

                // how aligned are light direction and triangle surface normal?
                var dp = (float)Math.Max(0.1, Vector3.Dot(normalizedNormal, normalizedLightDirection));

                // Convert from World Space to View(camera) space
                var triangleViewed = MultiplyMatrixVector(transformedTriangle, view);

                // clip triangles in view space
                var nearPlane = new Plane
                {
                    Point = Vector3.UnitZ / 10,
                    Normal = Vector3.UnitZ,
                };

                //var clippedTriangles = nearPlane.ClipAgainst(triangleViewed);
                //foreach (var clippedTriangle in clippedTriangles)
                {
                    // project from 3d to 2d screen coordinates
                    // scale into view, divide by w to get into cartesian space 'W'
                      var triangleProjected = MultiplyMatrixVectorW(triangleViewed, _projection);
                    //var triangleProjected = MultiplyMatrixVectorW(clippedTriangle, _projection);

                    triangleProjected.Color = GetColor(dp);

                    triangleProjected.A += OffsetOfView;
                    triangleProjected.B += OffsetOfView;
                    triangleProjected.C += OffsetOfView;

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

            return base.OnUpdate(elapsedSeconds);
        }

        private static Triangle MultiplyMatrixVectorW(Triangle i, Matrix4x4 m)
        {
            var a = Vector4.Transform(i.A, m).NormalizeW();
            var b = Vector4.Transform(i.B, m).NormalizeW();
            var c = Vector4.Transform(i.C, m).NormalizeW();

            return new Triangle(a, b, c);
        }

        private static Triangle MultiplyMatrixVector(Triangle i, Matrix4x4 m)
        {
            var a = Vector3.Transform(i.A, m);
            var b = Vector3.Transform(i.B, m);
            var c = Vector3.Transform(i.C, m);

            return new Triangle(a, b, c);
        }
    }
}