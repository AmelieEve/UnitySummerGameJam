using UnityEngine;
using UnityEngine.SceneManagement;

public class ChronolithInteraction : MonoBehaviour
{
    public string nextSceneName = "NextLevel"; // Nom de la scène vers laquelle téléporter le joueur
    public float interactionDistance = 3.0f; // Distance d'interaction avec le Chronolith

    public GameObject player = null;

    void Start()
    {

    }

    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.transform.position) < interactionDistance)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        // Charger la scène suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
