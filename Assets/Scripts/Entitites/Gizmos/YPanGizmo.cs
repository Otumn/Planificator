using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPanGizmo : SelectableGizmo
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
            entPosOnSelect.x,
            entPosOnSelect.y,
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).z + mouseToCenterVector.z);

        GameManager.gizmoController.UpdateGizmos();

    }
}
