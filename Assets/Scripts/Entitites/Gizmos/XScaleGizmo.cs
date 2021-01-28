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
        float dist = Vector3.Distance(transform.position, GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition));
        float oldValue = Vector3.Distance(mousePosOnSelection, Input.mousePosition) * 0.01f * ((Input.mousePosition - mousePosOnSelection).normalized.x);
        float secondValue = Vector3.Dot(-transform.up * dist, (GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position));
        GameManager.gameInstance.SelectedEntity.transform.localScale = new Vector3(
            entScaleOnSelect.x + oldValue,
            entScaleOnSelect.y,
            entScaleOnSelect.z);
        Debug.Log(dist);
    }
}
