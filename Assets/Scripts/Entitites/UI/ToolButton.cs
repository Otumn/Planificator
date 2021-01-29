using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolButton : Entity
{
    public GameObject subToolsParent;
    public Image img;

    private SubToolButton currentSubTool;

    public void SelectTool(SubToolButton subToolButton)
    {
        currentSubTool = subToolButton;
        img = currentSubTool.buttonImage;
    }

    public void ToggleParent()
    {
        subToolsParent.SetActive(!subToolsParent.activeSelf);
    }
}
