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
    public static MainCanvas mainUI;
    public static GeoDrawing geoDrawer;
    public static LayerManager layerManager;


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
        mainUI = GameObject.Find("MainCanvas").GetComponent<MainCanvas>();
        bgManager = GameObject.FindObjectOfType<BackgroundManager>();
        geoDrawer = GameObject.FindObjectOfType<GeoDrawing>();
        layerManager = GameObject.FindObjectOfType<LayerManager>();
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

    #region Tools events

    public void CallOnToolSelected(Tool tool)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnToolSelected(tool);
        }
    }

    public void CallOnMoveSnapSet(float newSnap)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnMoveSnapSet(newSnap);
        }
    }

    public void CallOnRotSnapSet(float newSnap)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnRotSnapSet(newSnap);
        }
    }

    public void CallOnSnapSet(bool snap)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].OnSnapSet(snap);
        }
    }

    #endregion

    #endregion

    public SelectableElement SelectedEntity { get => selectedEntity; set => selectedEntity = value; }
    public List<Entity> Entities { get => entities; set => entities = value; }
}
