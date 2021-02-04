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

    public void SelectTool(ToolInformations info)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == info.name)
            {
                currentTool = transform.GetChild(i).GetComponent<Tool>();
                GameManager.gameInstance.CallOnToolSelected(transform.GetChild(i).GetComponent<Tool>());
                return;
            }
        }
    }

    public Tool CurrentTool { get => currentTool; set => currentTool = value; }
}
