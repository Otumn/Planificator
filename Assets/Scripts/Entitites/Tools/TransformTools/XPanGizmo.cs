using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPanGizmo : SelectableGizmo
{

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
