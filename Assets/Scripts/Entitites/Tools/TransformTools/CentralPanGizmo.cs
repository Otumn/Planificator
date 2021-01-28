using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralPanGizmo : SelectableGizmo
{


    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();

        GameManager.gameInstance.SelectedEntity.transform.position = new Vector3(
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).x + mouseToCenterVector.x,
            entPosOnSelect.y,
            GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition).z + mouseToCenterVector.z);

        GameManager.gizmoController.UpdateGizmos();

    }
}
