using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboLaught : MonoBehaviour
{
    private RobotBehavior RobotBehavior;

    public RoboHelp roboHelp;

    // Start is called before the first frame update
    void Start()
    {
        RobotBehavior = GameObject.FindWithTag("RoBo").GetComponent<RobotBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RobotBehavior.PlayRoboHelp(roboHelp);
        }
    }
    
}
