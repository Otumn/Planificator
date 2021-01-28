using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XScaleGizmo : SelectableGizmo
{
    public GizmoCurves curves;

    protected override void OnEnable()
    {
        base.OnEnable();
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, 90 - SelectedEntity.transform.rotation.eulerAngles.y));
    }

    public override void OnGizmoMoved()
    {
        base.OnGizmoMoved();

        float dist = Vector3.Distance(mousePosOnSelection, Input.mousePosition);
        Vector3 dirVector = (Input.mousePosition - mousePosOnSelection);
        dirVector.z = dirVector.y;
        dirVector.y = 0;
        dirVector = dirVector.normalized;
        float secondValue = Vector3.Dot(-transform.up, dirVector) * dist * 0.01f;

        GameManager.gameInstance.SelectedEntity.transform.localScale = new Vector3(
            entScaleOnSelect.x + secondValue,
            entScaleOnSelect.y,
            entScaleOnSelect.z);
    }
}
