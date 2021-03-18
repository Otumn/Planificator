using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPanGizmo : SelectableGizmo
{

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        Vector3 mousePos = GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (GameManager.sceneParameters.Snapping)
        {
            Vector3 snappedPos = GameManager.sceneParameters.GetSnappedPosition(new Vector3(mousePos.x + mouseToCenterVector.x, 0, 0), SnapType.Rounded);
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            snappedPos.x,
            entPosOnSelect.y,
            entPosOnSelect.z);
        }
        else
        {
            GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            mousePos.x + mouseToCenterVector.x,
            entPosOnSelect.y,
            entPosOnSelect.z);
        }
        GameManager.toolsManager.transformTool.UpdateGizmos();

    }
}
