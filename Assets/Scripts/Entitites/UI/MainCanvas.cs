using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCanvas : Entity
{
    public TMP_InputField moveSnapField;
    public TMP_InputField rotSnapField;

    public override void OnManagersInitialized()
    {
        base.OnManagersInitialized();
        moveSnapField.text = GameManager.sceneParameters.MoveSnap.ToString();
        rotSnapField.text = GameManager.sceneParameters.RotateSnap.ToString();
    }

    public void SetNewMoveSnapValue(string inputString)
    {
        float snap = float.Parse(inputString);
        GameManager.sceneParameters.SetNewMoveSnap(snap);
    }

    public void SetNewRotSnapValue(string inputString)
    {
        float snap = float.Parse(inputString);
        GameManager.sceneParameters.SetNewRotSnap(snap);
    }
}
