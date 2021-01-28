using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameInstance gameInstance = new GameInstance();
    public static TransformTool gizmoController;
    public static SceneParameters sceneParameters;
    public static CameraController camController;
    public static Camera mainCamera;
    private void Start()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        gizmoController = GameObject.FindObjectOfType<TransformTool>();
        sceneParameters = GameObject.FindObjectOfType<SceneParameters>();
        camController = GameObject.FindObjectOfType<CameraController>();
        mainCamera = camController.cam;
        gameInstance.CallOnManagersInitialized();
    }

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

    public void CallOnManagersInitialized()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnManagersInitialized();
        }
    }

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
