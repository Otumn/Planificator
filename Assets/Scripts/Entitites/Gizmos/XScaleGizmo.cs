using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XScaleGizmo : SelectableGizmo
{
    

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        float dist = Vector3.Distance(mousePosOnSelection, Input.mousePosition) * 0.01f * ((Input.mousePosition - mousePosOnSelection).normalized.x);
        GameManager.gameInstance.SelectedEntity.transform.localScale = new Vector3(
            entScaleOnSelect.x + dist,
            entScaleOnSelect.y,
            entScaleOnSelect.z);
        Debug.Log(dist);
    }
}
