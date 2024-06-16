using UnityEngine;

public class PresentToGlyph : MonoBehaviour
{
    public RitualManager ritualManager;
    public Canvas pressE;

    private bool isPlayerNearby;
    private Light pointLight;

    private void Start()
    {
        pointLight = GetComponent<Light>();
        pressE.enabled = false;
        pointLight.enabled = false;
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        { 
            pointLight.enabled = true;
            pressE.enabled = false;
            ritualManager.presentedToGlyph = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ritualManager.presentedToGlyph)
        {
            isPlayerNearby = true;
            pressE.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = false;
            pressE.enabled = false;
        }
    }
}
