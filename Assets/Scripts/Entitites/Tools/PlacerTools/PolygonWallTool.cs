using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonWallTool : PlacerTool
{
    public GameObject polyRoomElement;
    public List<Vector3> worldPoints;

    public override void ToolLeftClickDownAction()
    {
        base.ToolLeftClickDownAction();
        AddPoint();
    }

    public override void ToolEscAction()
    {
        base.ToolEscAction();
        worldPoints.Clear();
        GameManager.geoDrawer.CleanAllDrawings();
    }

    public override void ToolSpaceBarAction()
    {
        base.ToolSpaceBarAction();
        ValidateObject();
    }

    private void AddPoint()
    {
        if (isCursorOverUI()) return;
        if (!GameManager.layerManager.HasCurrentLayer()) return;
        Vector3 point = GameManager.sceneParameters.GetSnappedPosition(GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition), SnapType.Rounded);
        point.y = GameManager.layerManager.GetCurrentLayerYValue(); // TODO : put this depending on the current layer next y, when the layers will be done.
        worldPoints.Add(point);
        GameManager.geoDrawer.DrawPoint(point, Color.red, 0.25f);
        if (worldPoints.Count >= 2)
        {
            GameManager.geoDrawer.DrawLine(worldPoints[worldPoints.Count - 2], worldPoints[worldPoints.Count - 1], Color.red, 0.125f);
        }
    }

    protected override void ValidateObject()
    {
        base.ValidateObject();
        if (worldPoints.Count < 2) return;

        GameObject poly = GameObject.Instantiate(polyRoomElement);
        poly.transform.position = worldPoints[0];

        PolyRoomElement room = poly.GetComponent<PolyRoomElement>();
        room.CreateRoom(worldPoints.ToArray());

        GameManager.layerManager.PlaceObjectInCurrentLayer(room);

        worldPoints.Clear();
        GameManager.geoDrawer.CleanAllDrawings();

    }
}
