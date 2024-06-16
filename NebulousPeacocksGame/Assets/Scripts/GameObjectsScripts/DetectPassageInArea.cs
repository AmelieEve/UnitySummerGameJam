using UnityEngine;

public class DetectPassageInArea : MonoBehaviour
{
    public ForbiddenAction forbiddenAction;
    public RitualManager ritualManager;
    public bool requiredRitual;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (requiredRitual && !ritualManager.IsRitualCompleted())
            {
                forbiddenAction.isActionTriggered = true;
            }
            else if (!requiredRitual)
            {
                forbiddenAction.isActionTriggered = true;
            }
        }
    }
}
