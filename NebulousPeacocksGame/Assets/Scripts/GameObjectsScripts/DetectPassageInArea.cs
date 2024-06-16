using UnityEngine;

public class DetectPassageInArea : MonoBehaviour
{
    public RitualManager ritualManager;
    public ForbiddenActionManager forbiddenActionManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ritualManager.isRitualCompleted())
        {
            forbiddenActionManager.forbiddenAction.isActionTriggered = true;
        }
    }
}
