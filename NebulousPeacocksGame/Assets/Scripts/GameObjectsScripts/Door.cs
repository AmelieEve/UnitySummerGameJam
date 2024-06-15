using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpenForbidden = false;
    public ForbiddenAction forbiddenAction = null;

    private bool isPlayerNearby = false;
    private bool isOpen = false;

    void Start()
    {
        if (isOpenForbidden && forbiddenAction == null)
        {
            Debug.LogError("ForbiddenAction is not set in the inspector!");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = true;
            if (isOpenForbidden)
            {
                forbiddenAction.isActionTriggered = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
