using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player = null;
    public bool isOpenForbidden = false;
    public ForbiddenAction forbiddenAction = null;

    public RoboHelp roboHelp;

    private bool isPlayerNearby = false;

    void Start()
    {
        if (isOpenForbidden && forbiddenAction == null)
        {
            Debug.LogError("ForbiddenAction is not set in the inspector!");
        }
        if (player == null)
        {
            Debug.LogError("Player is not set in the inspector!");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player open the door");
            if (isOpenForbidden)
            {
                forbiddenAction.isActionTriggered = true;

                if (roboHelp.HelpCount % 3 == 0)
                {
                    RobotBehavior robotBehavior = GameObject.FindWithTag("RoBo").GetComponent<RobotBehavior>();
                    robotBehavior.PlayRoboHelp(roboHelp);
                } else
                {
                    roboHelp.IncrementHelpCount();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerNearby = false;
        }
    }
}
