using UnityEngine;
using UnityEngine.SceneManagement;

public class ForbiddenActionManager : MonoBehaviour
{
    public ForbiddenAction forbiddenAction;
    public string failedActionSceneName = "FailedActionScene";

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
        SceneManager.LoadScene(failedActionSceneName);
    }
}
