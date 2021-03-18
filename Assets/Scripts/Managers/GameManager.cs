using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameInstance gameInstance = new GameInstance();
    public static SceneParameters sceneParameters;
    public static CameraController camController;
    public static ToolsManager toolsManager;
    public static Camera mainCamera;
    public static BackgroundManager bgManager;
    public static GraphicRaycaster mainRaycaster;
    public static EventSystem gameEventSystem;


    private void Start()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        sceneParameters = GameObject.FindObjectOfType<SceneParameters>();
        camController = GameObject.FindObjectOfType<CameraController>();
        toolsManager = GameObject.FindObjectOfType<ToolsManager>();
        mainCamera = camController.cam;
        gameEventSystem = GameObject.FindObjectOfType<EventSystem>();
        mainRaycaster = GameObject.Find("MainCanvas").GetComponent<GraphicRaycaster>();
        bgManager = GameObject.FindObjectOfType<BackgroundManager>();
        gameInstance.CallOnManagersInitialized();
    }

}

public class GameInstance
{
    private Tool currentTool;
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
    
    public void CallOnToolSelected(Tool tool)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnToolSelected(tool);
        }
    }

    public void CallOnNewMoveSnapSet(float newSnap)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnNewMoveSnapSet(newSnap);
        }
    }

    public void CallOnNewRotSnapSet(float newSnap)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnNewRotSnapSet(newSnap);
        }
    }

    #endregion

    public SelectableElement SelectedEntity { get => selectedEntity; set => selectedEntity = value; }
    public List<Entity> Entities { get => entities; set => entities = value; }
}
