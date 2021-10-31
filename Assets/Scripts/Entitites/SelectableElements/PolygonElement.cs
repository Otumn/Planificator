using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonElement : SelectableElement
{
    public MeshFilter filter;
    public MeshCollider coll;
    public Material mat;

    private Vector3[] worldPoints;
    private Vector2[] v2Points;

    public void CreateMesh()
    {
        v2Points = new Vector2[worldPoints.Length];
        for (int i = 0; i < v2Points.Length; i++)
        {
            v2Points[i] = new Vector2(worldPoints[i].x, worldPoints[i].z);
        }
        Triangulator tr = new Triangulator(v2Points);
        int[] indices = tr.Triangulate();

        Mesh mesh = new Mesh();
        mesh.vertices = worldPoints;
        mesh.uv = v2Points;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        filter.mesh = mesh;
        coll.sharedMesh = mesh;
        renderer.material = mat;
    }
    

    public void UpdateMeshPoints(Vector3[] points)
    {
        worldPoints = points;
        CreateMesh();
    }

}
