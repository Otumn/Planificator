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
}
