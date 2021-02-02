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

    protected override void Update()
    {
        base.Update();
        ControlsManagement();
    }

    private void ControlsManagement()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SwitchType();
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

}

public enum GizmoType
{
    None,
    Panning,
    Rotating,
    Scaling
};
