using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tool infos", menuName = "Planner/ToolInfos")]
public class ToolInformations : ScriptableObject
{
    public string toolName = "Name";
    public string toolDescription;
    public Sprite icon;
}
