using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameInstance gameInstance = new GameInstance();

}

public class GameInstance
{
    private List<Entity> entities = new List<Entity>();
    private SelectableElement selectedEntity;

    #region entity management
    public void addEntity(Entity entity)
    {
        Entities.Add(entity);
    }

    public void removeEntity(Entity entity)
    {
        Entities.Remove(entity);
    }
    #endregion

    #region entity events

    public void CallOnEntitySelected(SelectableElement sEntity)
    {
        selectedEntity = sEntity;
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnEntitySelected(sEntity);
        }
    }

    public void CallOnEntityUnSelected(SelectableElement unsEntity)
    {
        selectedEntity = null;
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnEntityUnSelected(unsEntity);
        }
    }

    #endregion

    public SelectableElement SelectedEntity { get => selectedEntity; set => selectedEntity = value; }
    public List<Entity> Entities { get => entities; set => entities = value; }
}
