using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : Entity
{
    #region Tools
    private Tool currentTool;
    [Header("Tools")]
    public TransformTool transformTool;
    public WallPlacerTool wallPlacerTool;
    #endregion

    public override void OnManagersInitialized()
    {
        base.OnManagersInitialized();
        SetCurrentTool(transformTool);
    }

    public void SelectTool(ToolInformations info)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == info.name)
            {
                SetCurrentTool(transform.GetChild(i).GetComponent<Tool>());
                return;
            }
        }
    }

    private void SetCurrentTool(Tool newTool)
    {
        if (currentTool != null) currentTool.OnToolDeselected();
        currentTool = newTool;
        currentTool.OnToolSelected();
        GameManager.gameInstance.CallOnToolSelected(currentTool);
    }

    public Tool CurrentTool { get => currentTool; set => currentTool = value; }
}
