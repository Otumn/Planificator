using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubToolButton : Entity
{
    public ToolInformations info;
    public Image iconImage;
    public Image backgroundImage;

    protected override void Start()
    {
        base.Start();
        iconImage.sprite = info.icon;
    }

}
