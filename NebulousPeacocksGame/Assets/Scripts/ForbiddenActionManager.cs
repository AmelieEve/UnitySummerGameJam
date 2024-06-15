using UnityEngine;

public class ForbiddenActionManager : MonoBehaviour
{
    public ForbiddenAction forbiddenAction;

    void Start()
    {
        if (forbiddenAction == null)
        {
            Debug.LogError("ForbiddenAction is not set in the inspector!");
        } else
        {
            forbiddenAction.isActionTriggered = false;
        }
    }

    void Update()
    {
        if (forbiddenAction != null && forbiddenAction.isActionTriggered)
        {
            HandleForbiddenAction();
        }
    }

    private void HandleForbiddenAction()
    {
        Debug.Log($"Forbidden action triggered: {forbiddenAction.actionName} : {forbiddenAction.description}");
        
        // Add scene transition logic here
    }
}
