using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YScaleGizmo : SelectableGizmo
{
    protected override void OnEnable()
    {
        base.OnEnable();
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, -GameManager.gameInstance.SelectedEntity.transform.rotation.eulerAngles.y));
    }

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();
        float dist = Vector3.Distance(mousePosOnSelection, Input.mousePosition) * 0.01f * ((Input.mousePosition - mousePosOnSelection).normalized.y);
        GameManager.gameInstance.SelectedEntity.transform.localScale = new Vector3(
            entScaleOnSelect.x,
            entScaleOnSelect.y,
            entScaleOnSelect.z + dist);
        Debug.Log(dist);
    }
}
