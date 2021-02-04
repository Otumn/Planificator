using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Entity
{
    public ToolInformations infos;

    protected override void Start()
    {
        base.Start();
        gameObject.name = infos.name;
    }

    public virtual void ToolLeftClickDownAction()
    {

    }
    
    public virtual void ToolLeftClickHeldAction()
    {

    }

    public virtual void ToolLeftClickUpAction()
    {

    }

    public virtual void ToolSpaceBarAction()
    {

    }

    protected RaycastHit ClicRaycast()
    {
        Ray ray = GameManager.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    protected SelectableElement SelectedEntity { get => GameManager.gameInstance.SelectedEntity; set => GameManager.gameInstance.SelectedEntity = value; }
}
