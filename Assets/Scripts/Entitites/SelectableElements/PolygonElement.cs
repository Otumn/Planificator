using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonElement : SelectableElement
{
    public MeshFilter filter;
    public MeshCollider coll;
    public Material mat;

    private PolygonElementType polygonType = PolygonElementType.Full;
    private Vector3[] worldPoints;
    private Vector2[] v2Points;

    public void CreateMesh()
    {
        switch(polygonType)
        {
            case PolygonElementType.Full:

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

                break;

            case PolygonElementType.Walls:
                break;
        }
    }
    
    public void SwitchPolygonType(PolygonElementType type)
    {
        polygonType = type;
        CreateMesh();
    }

    public void UpdateMeshPoints(Vector3[] points)
    {
        worldPoints = points;
        CreateMesh();
    }

    public PolygonElementType PolygonType { get => polygonType; set => polygonType = value; }

}

public enum PolygonElementType
{
    Full,
    Walls
};
