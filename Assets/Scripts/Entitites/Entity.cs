using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Monobehaviour callbacks

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void OnEnable()
    {
        GameManager.gameInstance.addEntity(this);
    }

    protected virtual void OnDisable()
    {
        GameManager.gameInstance.removeEntity(this);
    }

    #endregion

    #region Entity callbacks

    public virtual void OnManagersInitialized()
    {

    }

    public virtual void OnEntitySelected(SelectableElement selectedEntity)
    {

    }

    public virtual void OnEntityUnSelected(SelectableElement unselectedEntity)
    {

    }

    #endregion
}
