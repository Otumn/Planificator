using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableGizmo : Entity
{
    protected Vector3 mousePosOnSelection;
    protected Vector3 mouseToCenterVector;
    protected Vector3 entPosOnSelect;
    protected Vector3 entScaleOnSelect;
    protected Vector3 entRotOnSelect;

    public virtual void OnGizmoDown()
    {
        mousePosOnSelection = Input.mousePosition;
        mouseToCenterVector = GameManager.gameInstance.SelectedEntity.transform.position - GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseToCenterVector.y = 0;
        entPosOnSelect = GameManager.gameInstance.SelectedEntity.transform.position;
        entScaleOnSelect = GameManager.gameInstance.SelectedEntity.transform.localScale;
        entRotOnSelect = GameManager.gameInstance.SelectedEntity.transform.rotation.eulerAngles;
    }

    public virtual void OnGizmoMoved()
    {

    }

    public virtual void OnGizmoUp()
    {

    }
}
