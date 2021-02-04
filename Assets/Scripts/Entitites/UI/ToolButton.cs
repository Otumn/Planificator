using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolButton : Entity
{
    public ToolInformations infos;
    public GameObject subToolsParent;
    public Image iconImage;
    public Image backgroundImage;

    protected override void Start()
    {
        base.Start();
        UpdateInfos();
    }

    public void SelectTool(SubToolButton subToolButton)
    {
        GameManager.toolsManager.SelectTool(subToolButton.info);
        infos = subToolButton.info;
        UpdateInfos();
        ToggleParent();
        // make the button darker;
    }

    public void SelectTool()
    {
        GameManager.toolsManager.SelectTool(infos);
        // make the button darker;
    }

    public void ToggleParent()
    {
        subToolsParent.SetActive(!subToolsParent.activeSelf);
    }

    private void UpdateInfos()
    {
        iconImage.sprite = infos.icon;
    }
}
