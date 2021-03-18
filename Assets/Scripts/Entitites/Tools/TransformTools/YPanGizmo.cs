using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPanGizmo : SelectableGizmo
{

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        Vector3 mousePos = GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (GameManager.sceneParameters.Snapping)
        {
            Vector3 snappedPos = GameManager.sceneParameters.GetSnappedPosition(new Vector3(0, 0, mousePos.z + mouseToCenterVector.z), SnapType.Rounded);
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            entPosOnSelect.x,
            entPosOnSelect.y,
            snappedPos.z);
        }
        else
        {
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            entPosOnSelect.x,
            entPosOnSelect.y,
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).z + mouseToCenterVector.z);
        }
        GameManager.toolsManager.transformTool.UpdateGizmos();
    }
}
