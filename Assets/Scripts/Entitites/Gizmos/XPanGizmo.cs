using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPanGizmo : SelectableGizmo
{
    private Vector3 entPosOnSelect;

    public override void OnGizmoDown()
    {
        base.OnGizmoDown();
        entPosOnSelect = GameManager.gameInstance.SelectedEntity.transform.position;
    }


    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();

        GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).x + mouseToCenterVector.x,
            entPosOnSelect.y,
            entPosOnSelect.z);

        GameManager.gizmoController.UpdateGizmos();

    }
}
