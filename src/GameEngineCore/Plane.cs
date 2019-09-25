using System.Collections.Generic;
using System.Diagnostics;

namespace GameEngineCore
{
    /// <summary>
    /// A plane can be defined by a point on the plane and a Normal for that point
    /// </summary>
    internal struct Plane
    {
        public Vector3 Point;
        public Vector3 Normal;

        /// <summary>
        /// Return the point on the plane that the provided line passes through
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Vector3 Intersection(Line line)
        {
            var lineStart = line.Start;
            var lineEnd = line.End;

            return Intersection(lineStart, lineEnd);
        }

        public Vector3 Intersection(Vector3 lineStart, Vector3 lineEnd)
        {
            var normalizedNormal = Vector3.Normalize(Normal);
            var planeD = -Vector3.Dot(normalizedNormal, Point);
            var ad = Vector3.Dot(lineStart, normalizedNormal);
            var bd = Vector3.Dot(lineEnd, normalizedNormal);
            var t = (-planeD - ad) / (bd - ad);
            var lineStartToEnd = lineEnd - lineStart;
            var lineToIntersect = lineStartToEnd * t;
            var intersection = lineStart + lineToIntersect;
            return intersection;
        }

        public IEnumerable<Triangle> ClipAgainst(Triangle triangle, bool debug = false)
        {
            // make sure plane normal is normalized
            var planeNormal = Vector3.Normalize(Normal);
            var planePoint = Point;

            // return signed shortest distance from point to plane

            float dist(Vector3 p)
            {
                //var np = Vector3.Normalize(p);
                var dot = Vector3.Dot(planeNormal, planePoint);
                //var dot = planeNormal.Length();
                var planeNormalX = Vector3.Dot(planeNormal, p);

                return planeNormalX - dot;
            }

            // https://youtu.be/HXSuNxpCzdM?t=2723

            // create two arrays to classify points on either side of the plane
            // if distance is positive then point lies on the "inside" of the plane

            var insidePoints = new List<Vector3>();
            var outsidePoints = new List<Vector3>();

            void ClassifyPoint(Vector3 point)
            {
                var distance = dist(point);
                (distance >= 0 ? insidePoints : outsidePoints).Add(point);
            }

            ClassifyPoint(triangle.A);
            ClassifyPoint(triangle.B);
            ClassifyPoint(triangle.C);

            // Now break the triangle into smaller output triangles. There are four cases
            switch (insidePoints.Count)
            {
                case 0:
                    // all points lie outside of the plane so clip the whole triangle
                    yield break;

                case 1 when outsidePoints.Count == 2:
                    {
                        /**
                             *  Outside | Inside
                             *          |
                             *   A      |
                             *    *     |
                             *    | \   |
                             *    |  \  |
                             *    |   \ |
                             *    |    \|
                             *    |     * E
                             *    |     |\
                             *    |     | \
                             *    |     |  * B
                             *    |     | /
                             *    |     |/
                             *    |     * D
                             *    |    /|
                             *    |   / |
                             *    |  /  |
                             *    | /   |
                             *    |/    |
                             *    *     |
                             *   C
                             *
                             *
                             *   original triangle = ABC
                             *   new triangle = BDE
                             *
                             */

                        // return new triangle using the points that intersect the plane and the point inside the plane

                        var pointA = outsidePoints[0];
                        var pointB = insidePoints[0];
                        var pointC = outsidePoints[1];
                        var pointD = Intersection(pointB, pointC);
                        var pointE = Intersection(pointB, pointA);

                        yield return new Triangle
                        {
                            Color = debug ? Colors.Blue : triangle.Color,
                            // keep the inside point
                            A = pointB,

                            // but update the outside points to be the point at which the plane intersects
                            B = pointE,
                            C = pointD
                        };
                        break;
                    }
                case 2 when outsidePoints.Count == 1:
                    {
                        // in this case we have a quadrilateral inside of the plane
                        // we need to break it up into two triangles

                        /*
                             * Outside  |  Inside
                             *          |
                             *          |    * A
                             *          |   /|
                             *          |  / |
                             *          | /  |
                             *          |/   |
                             *        E *    |
                             *         /|    |
                             *        / |    |
                             *    C *   |    |
                             *       \  |    |
                             *        \ |    |
                             *         \|    |
                             *        D *    |
                             *          |\   |
                             *          | \  |
                             *          |  \ |
                             *          |   * B
                             *          |
                             *
                             * original triangle = ABC
                             *
                             *
                             * new triangle 1 = ABE
                             * new triangle 2 = BED
                             *
                             */

                        // the first triangle consists of the two inside points and a new point where the
                        // triangle intersects plane
                        var pointA = insidePoints[0];
                        var pointB = insidePoints[1];
                        var pointC = outsidePoints[0];

                        var pointE = Intersection(pointA, pointC); // intersection of AC with plane gives E
                        var pointD = Intersection(pointB, pointC); // intersection of BC with plane gives D

                        yield return new Triangle
                        {
                            Color = debug ? Colors.Green : triangle.Color,
                            A = pointA,
                            B = pointB,
                            C = pointE
                        };

                        yield return new Triangle
                        {
                            Color = debug ? Colors.Red : triangle.Color,
                            A = pointB,
                            B = pointE,
                            C = pointD
                        };

                        break;
                    }
                case 3:
                    // all points are inside the plane, no clipping required
                    yield return triangle;
                    break;

                default:
                    Debugger.Break();
                    yield break;
            }
        }
    }

    /// <summary>
    /// A line is defined by two points
    /// </summary>
    internal struct Line
    {
        public Vector3 Start;
        public Vector3 End;

        public Line(Vector3 start, Vector3 end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}