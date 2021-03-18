using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralPanGizmo : SelectableGizmo
{
    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        Vector3 mousePos = GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (GameManager.sceneParameters.Snapping)
        {
            Vector3 snappedPos = GameManager.sceneParameters.GetSnappedPosition(new Vector3(mousePos.x + mouseToCenterVector.x, 0, mousePos.z + mouseToCenterVector.z), SnapType.Rounded);
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            snappedPos.x,
            entPosOnSelect.y,
            snappedPos.z);
        }
        else
        {
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).x + mouseToCenterVector.x,
            entPosOnSelect.y,
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).z + mouseToCenterVector.z);
        }
        GameManager.toolsManager.transformTool.UpdateGizmos();
    }
}
