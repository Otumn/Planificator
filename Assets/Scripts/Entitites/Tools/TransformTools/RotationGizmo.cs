using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGizmo : SelectableGizmo
{

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, -GameManager.gameInstance.SelectedEntity.transform.rotation.eulerAngles.y));
    }

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        float rot = 0f;
        rot = -entRotOnSelect.y + Quaternion.FromToRotation((mousePosOnSelection - GameManager.mainCamera.WorldToScreenPoint(entPosOnSelect)), (Input.mousePosition - GameManager.mainCamera.WorldToScreenPoint(entPosOnSelect))).eulerAngles.z;
        if(GameManager.sceneParameters.Snapping)
        {
            rot = GameManager.sceneParameters.GetSnappedRotation(rot);
        }
        GameManager.gameInstance.SelectedEntity.transform.rotation = Quaternion.Euler(new Vector3(0, -rot, 0));
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, rot));
    }
}
