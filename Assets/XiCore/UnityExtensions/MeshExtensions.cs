/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

using UnityEngine;


namespace XiCore.Extensions
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