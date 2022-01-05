using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTool : Tool
{
    public GizmoType currentType;
    public GameObject panGO;
    public GameObject rotateGO;
    public GameObject scaleGO;

    private int typeIndex = 1;
    private bool isMovingGizmo = false;
    private SelectableGizmo gizmo;

    public override void ToolLeftClickDownAction()
    {
        base.ToolLeftClickDownAction();
        if (isCursorOverUI()) return;
        SelectionControls();
        if (!isMovingGizmo)
        {
            RaycastHit hit = ClicRaycast();
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<SelectableGizmo>() != null)
                {
                    gizmo = hit.collider.gameObject.GetComponent<SelectableGizmo>();
                    gizmo.OnGizmoDown();
                    isMovingGizmo = true;
                }
            }
        }
    }

    public override void ToolLeftClickHeldAction()
    {
        base.ToolLeftClickHeldAction();
        if (isMovingGizmo)
        {
            gizmo.OnGizmoMoved();
        }
    }

    public override void ToolLeftClickUpAction()
    {
        base.ToolLeftClickUpAction();
        if (isMovingGizmo)
        {
            gizmo.OnGizmoUp();
            gizmo = null;
            isMovingGizmo = false;
        }
    }

    public override void ToolSpaceBarAction()
    {
        base.ToolSpaceBarAction();
        SwitchType();
    }

    public override void ToolSupprAction()
    {
        base.ToolSupprAction();
        DeleteSelected();
    }

    private void SelectionControls()
    {
        RaycastHit hit = ClicRaycast();
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<SelectableElement>() != null && hit.collider.gameObject.GetComponent<SelectableElement>() != SelectedEntity)
            {
                SelectableElement clickedEnt = hit.collider.gameObject.GetComponent<SelectableElement>();
                if (GameManager.layerManager.CurrentLayer.iDIndex != clickedEnt.GetHighestParent().savedLayerID) return;
                if (SelectedEntity != null && clickedEnt != SelectedEntity)
                {
                    SelectedEntity.UnSelect();
                }
                clickedEnt.Select();
            }
        }
        else
        {
            if (SelectedEntity != null)
            {
                SelectedEntity.UnSelect();
            }
        }
    }

    public override void OnEntitySelected(SelectableElement selectedEntity)
    {
        base.OnEntitySelected(selectedEntity);
        SwitchType(GizmoType.Panning);
    }

    public override void OnEntityUnSelected(SelectableElement unselectedEntity)
    {
        base.OnEntityUnSelected(unselectedEntity);
        if (GameManager.gameInstance.SelectedEntity == null) SwitchType(GizmoType.None);
    }

    public void SwitchType()
    {
        typeIndex++;
        if (typeIndex > 3) typeIndex = 1;
        currentType = (GizmoType)typeIndex;
        UpdateGizmos();
    }

    public void SwitchType(GizmoType type)
    {
        currentType = type;
        UpdateGizmos();
    }

    public void UpdateGizmos()
    {
        switch (currentType)
        {
            case GizmoType.None:
                panGO.SetActive(false);
                rotateGO.SetActive(false);
                scaleGO.SetActive(false);
                return;

            case GizmoType.Panning:
                panGO.SetActive(true);
                rotateGO.SetActive(false);
                scaleGO.SetActive(false);
                break;

            case GizmoType.Rotating:
                panGO.SetActive(false);
                rotateGO.SetActive(true);
                scaleGO.SetActive(false);
                break;

            case GizmoType.Scaling:
                panGO.SetActive(false);
                rotateGO.SetActive(false);
                scaleGO.SetActive(true);
                break;
        }
        transform.position = new Vector3(GameManager.gameInstance.SelectedEntity.transform.position.x, 5f, GameManager.gameInstance.SelectedEntity.transform.position.z);
    }

    public void DeleteSelected()
    {
        if(GameManager.gameInstance.SelectedEntity != null)
        {
            SelectableElement buffer = GameManager.gameInstance.SelectedEntity;
            buffer.UnSelect();
            Destroy(buffer.gameObject);
        }
    }
}

public enum GizmoType
{
    None,
    Panning,
    Rotating,
    Scaling
};
