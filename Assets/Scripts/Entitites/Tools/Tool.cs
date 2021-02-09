using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tool : Entity
{
    public ToolInformations infos;

    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;
    private PointerEventData pointerEventData;

    protected override void Start()
    {
        base.Start();
        gameObject.name = infos.name;
    }

    #region Inputs

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

    public virtual void ToolEscAction()
    {

    }

    #endregion

    protected bool isCursorOverUI()
    {
        pointerEventData = new PointerEventData(GameEventSystem);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        MainRaycaster.Raycast(pointerEventData, results);
        return (results.Count > 0);
    }

    protected RaycastHit ClicRaycast()
    {
        Ray ray = GameManager.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    protected SelectableElement SelectedEntity { get => GameManager.gameInstance.SelectedEntity; set => GameManager.gameInstance.SelectedEntity = value; }
    protected EventSystem GameEventSystem { get => GameManager.gameEventSystem; }
    protected GraphicRaycaster MainRaycaster { get => GameManager.mainRaycaster; }
}
