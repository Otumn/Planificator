using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableElement : Entity
{
    public MeshRenderer renderer;
    public SelectableElement parentElement;

    public virtual void Select()
    {
        if (parentElement != null)
        {
            parentElement.Select();
            return;
        }
        DisplaySelectionFeedback();
        GameManager.gameInstance.CallOnEntitySelected(this);
    }

    public  virtual void UnSelect()
    {
        HideSelectionFeedback();
        GameManager.gameInstance.CallOnEntityUnSelected(this);
    }

    public virtual void DisplaySelectionFeedback()
    {
        renderer.material.SetFloat("SelectionValue", 1f);
    }

    public virtual void HideSelectionFeedback()
    {
        renderer.material.SetFloat("SelectionValue", 0f);
    }
}
