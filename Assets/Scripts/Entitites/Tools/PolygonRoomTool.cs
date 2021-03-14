using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonRoomTool : Tool
{
    public GameObject polygonElement;
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
        if (isCursorOverUI()) return;
        Vector3 point = GameManager.sceneParameters.GetSnappedPosition(GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition), SnapType.Rounded);
        point.y = 0; // make this on top of everything? 
        worldPoints.Add(point);
    }

    private void ValidateMesh()
    {
        if (worldPoints.Count < 3) return;

        GameObject poly = GameObject.Instantiate(polygonElement);
        poly.transform.position = worldPoints[0];
        for (int i = 1; i < worldPoints.Count; i++)
        {
            worldPoints[i] -= worldPoints[0];
        }
        worldPoints[0] = Vector3.zero;

        PolygonElement polyElement = poly.GetComponent<PolygonElement>();
        polyElement.UpdateMeshPoints(worldPoints.ToArray());

        worldPoints.Clear();
    }
}
