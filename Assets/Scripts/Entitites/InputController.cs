using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Entity
{
    protected override void Update()
    {
        base.Update();
        CurrentToolControl();
    }
    private void CurrentToolControl()
    {
        if (CurrentTool != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CurrentTool.ToolLeftClickDownAction();
            }
            if (Input.GetMouseButton(0))
            {
                CurrentTool.ToolLeftClickHeldAction();
            }
            if (Input.GetMouseButtonUp(0))
            {
                CurrentTool.ToolLeftClickUpAction();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentTool.ToolSpaceBarAction();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                CurrentTool.ToolEscAction();
            }
        }
    }


    private Tool CurrentTool { get => GameManager.toolsManager.CurrentTool; set => GameManager.toolsManager.CurrentTool = value; }
}
