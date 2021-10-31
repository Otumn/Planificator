using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Entity
{
    protected override void Update()
    {
        base.Update();
        CurrentToolControl();
        ShortcutControls();
    }
    private void CurrentToolControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolLeftClickDownAction();
        }
        if (Input.GetMouseButton(0))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolLeftClickHeldAction();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolLeftClickUpAction();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolSpaceBarAction();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolSupprAction();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentTool == null) return;
            CurrentTool.ToolEscAction();
        }
    }

    private void ShortcutControls()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.mainUI.SetNewSnapping(!GameManager.sceneParameters.Snapping);
        }
    }


    private Tool CurrentTool { get => GameManager.toolsManager.CurrentTool; set => GameManager.toolsManager.CurrentTool = value; }
}
