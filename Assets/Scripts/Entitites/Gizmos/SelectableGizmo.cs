using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableGizmo : MonoBehaviour
{
    protected Vector3 mousePosOnSelection;
    protected Vector3 mouseToCenterVector;

    public virtual void OnGizmoDown()
    {
        mousePosOnSelection = Input.mousePosition;
        mouseToCenterVector = GameManager.gameInstance.SelectedEntity.transform.position - GameManager.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseToCenterVector.y = 0;
    }

    public virtual void OnGizmoMoved()
    {

    }

    public virtual void OnGizmoUp()
    {

    }
}
