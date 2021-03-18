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
        SelectableElement ent = SelectedEntity;

        mousePosOnSelection = Input.mousePosition;
        mouseToCenterVector = ent.transform.position - GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseToCenterVector.y = 0;

        entPosOnSelect = ent.transform.position;
        entScaleOnSelect = ent.transform.localScale;
        entRotOnSelect = ent.transform.rotation.eulerAngles;
    }

    public virtual void OnGizmoMoved()
    {

    }

    public virtual void OnGizmoUp()
    {

    }

    protected SelectableElement SelectedEntity { get => GameManager.gameInstance.SelectedEntity; set => GameManager.gameInstance.SelectedEntity = value; }

}
