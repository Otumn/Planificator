using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : Entity
{
    #region Tools
    [Header("Tools")]
    public TransformTool transformTool;

    #endregion

    public void SelectTool(ToolInformations info)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == info.name)
            {
                GameManager.gameInstance.CallOnToolSelected(transform.GetChild(i).GetComponent<Tool>());
                return;
            }
        }
    }
}
