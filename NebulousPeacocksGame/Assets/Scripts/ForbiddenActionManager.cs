using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Kino;

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
            StartCoroutine(HandleForbiddenAction());
            forbiddenAction.isActionTriggered = false;
        }
    }

    private IEnumerator HandleForbiddenAction()
    {
        // Get player
        GameObject gameObject = GameObject.FindWithTag("Player");

        Debug.Log($"Forbidden action triggered: {forbiddenAction.actionName} : {forbiddenAction.description}");
        
        // Disable player movement
        gameObject.GetComponentInChildren<PlayerController>().enabled = false;

        // Add glich effect here
        gameObject.GetComponentInChildren<DigitalGlitch>().intensity = 0.5f;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Add scene transition logic here
        SceneManager.LoadScene(failedActionSceneName);
    }
}
