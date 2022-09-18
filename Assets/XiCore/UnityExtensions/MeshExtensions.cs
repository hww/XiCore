// =============================================================================
// MIT License
// 
// Copyright (c) 2018 Valeriya Pudova (hww.github.io)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// =============================================================================

using UnityEngine;


namespace XiUnityTools
{
    public static class MeshExtensions
    {
        public static void RotateMesh(this Mesh mesh, float angle, Vector3 axis)
        {
            mesh.RotateMesh(Quaternion.AngleAxis(angle, axis));
        }

        public static void RotateMesh(this Mesh mesh, float x, float y, float z)
        {
            mesh.RotateMesh(Quaternion.Euler(x, y, z));
        }

        public static void RotateMesh(this Mesh mesh, Quaternion rotation)
        {
            var vertices = mesh.vertices;
            for (var i = 0; i < vertices.Length; i++)
                vertices[i] = rotation * vertices[i];
            mesh.vertices = vertices;
            
            var normals = mesh.normals;
            for (var i = 0; i < normals.Length; i++)
                normals[i] = rotation * normals[i];
            mesh.normals = normals;
        }
        
        public static void TranslateMesh(this Mesh mesh, float x, float y, float z)
        {
            mesh.TranslateMesh(new Vector3(x, y, z));
        }

        public static void TranslateMesh(this Mesh mesh, Vector3 offset)
        {
            var vertices = mesh.vertices;
            for (var i = 0; i < vertices.Length; i++)
                vertices[i] = offset + vertices[i];
            mesh.vertices = vertices;
        }
        
        public static void RotateMesh(this Mesh mesh, float angle, Vector3 axis, Vector3 center)
        {
            mesh.RotateMesh(Quaternion.AngleAxis(angle, axis), center);
        }

        public static void RotateMesh(this Mesh mesh, float x, float y, float z, Vector3 center)
        {
            mesh.RotateMesh(Quaternion.Euler(x, y, z), center);
        }

        
        public static void RotateMesh(this Mesh mesh, Quaternion rotation, Vector3 center)
        {
            var vertices = mesh.vertices;
            for (var i = 0; i < vertices.Length; i++)
                vertices[i] = rotation * (vertices[i] - center) + center;
            mesh.vertices = vertices;
            
            var normals = mesh.normals;
            for (var i = 0; i < normals.Length; i++)
                normals[i] = rotation * normals[i];
            mesh.normals = normals;
        }
    }
}