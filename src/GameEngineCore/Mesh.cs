using System;
using System.Collections.Generic;
using System.IO;

namespace GameEngineCore
{
    internal class Mesh
    {
        public Mesh()
            : this(new List<Triangle>())
        {
        }

        public Mesh(List<Triangle> triangles)
        {
            Triangles = triangles;
        }

        public List<Triangle> Triangles { get; }

        public static Mesh ReadFromFile(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                var vertices = new List<Vector3>();
                var faces = new List<Triangle>();
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;

                    if (line.Length == 0)
                        continue;

                    var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (parts[0])
                    {
                        case "v": // vertices
                            vertices.Add(new Vector3(
                                float.Parse(parts[1]),
                                float.Parse(parts[2]),
                                float.Parse(parts[3])
                            ));
                            break;

                        case "f": // triangles
                            var v0 = int.Parse(parts[1]) - 1;
                            var v1 = int.Parse(parts[2]) - 1;
                            var v2 = int.Parse(parts[3]) - 1;
                            faces.Add(new Triangle(vertices[v0], vertices[v1], vertices[v2]));
                            break;
                    }
                }

                return new Mesh(faces);
            }
        }
    }
}