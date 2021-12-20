using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerTool : Tool
{
    protected virtual void ValidateObject()
    {
        if (!GameManager.layerManager.HasCurrentLayer()) return;
    }
}
