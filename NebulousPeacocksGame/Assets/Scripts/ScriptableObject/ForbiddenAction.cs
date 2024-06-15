using UnityEngine;

[CreateAssetMenu(fileName = "ForbiddenAction", menuName = "ScriptableObjects/ForbiddenAction", order = 1)]
public class ForbiddenAction : ScriptableObject
{
    public string actionName;
    public string description;
    public bool isActionTriggered;
}
