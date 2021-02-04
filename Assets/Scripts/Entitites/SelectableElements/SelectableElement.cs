using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableElement : Entity
{
    public MeshRenderer renderer;

    public void Select()
    {
        renderer.material.SetFloat("SelectionValue", 1f);
        GameManager.gameInstance.CallOnEntitySelected(this);
        Debug.Log(gameObject.name);
    }

    public void UnSelect()
    {
        renderer.material.SetFloat("SelectionValue", 0f);
        GameManager.gameInstance.CallOnEntityUnSelected(this);
    }
}
