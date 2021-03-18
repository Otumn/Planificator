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
        moveSnapField.text = GameManager.sceneParameters.moveSnap.ToString();
        rotSnapField.text = GameManager.sceneParameters.rotateSnap.ToString();
    }
}
