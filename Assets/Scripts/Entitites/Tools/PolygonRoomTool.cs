using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonRoomTool : Tool
{
    public Material testMaterial;
    public List<Vector3> worldPoints;

    protected override void Update()
    {
        base.Update();
        for (int i = 0; i < worldPoints.Count - 1; i++)
        {
            if (worldPoints.Count - 1 <= i + 1)
            {
                Debug.DrawLine(worldPoints[0], worldPoints[worldPoints.Count-1], Color.red);
            }
            Debug.DrawLine(worldPoints[i], worldPoints[i + 1], Color.red);
        }
    }

    public override void ToolLeftClickDownAction()
    {
        base.ToolLeftClickDownAction();
        AddPoint();
    }

    public override void ToolEscAction()
    {
        base.ToolEscAction();
        worldPoints.Clear();
    }

    public override void ToolSpaceBarAction()
    {
        base.ToolSpaceBarAction();
        ValidateMesh();
    }

    private void AddPoint()
    {
        Vector3 point = GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        point.y = 0; // make this on top of everything? 
        worldPoints.Add(point);
    }

    private void ValidateMesh()
    {
        if (worldPoints.Count < 3) return;

        Vector2[] v2Points = new Vector2[worldPoints.Count];
        for (int i = 0; i < v2Points.Length; i++)
        {
            v2Points[i] = new Vector2(worldPoints[i].x, worldPoints[i].z);
        }
        Triangulator tr = new Triangulator(v2Points);
        int[] indices = tr.Triangulate();

        Mesh mesh = new Mesh();
        mesh.vertices = worldPoints.ToArray();
        mesh.uv = v2Points;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GameObject test = new GameObject("Test", typeof(MeshFilter), typeof(MeshRenderer));
        test.GetComponent<MeshFilter>().mesh = mesh;
        test.GetComponent<MeshRenderer>().material = testMaterial;
        test.transform.position = Vector3.zero;

        worldPoints.Clear();
    }
}
