using UnityEngine;
using UnityEngine.SceneManagement;

public class ChronolithInteraction : MonoBehaviour
{
    public string nextSceneName = "NextLevel"; // Nom de la sc�ne vers laquelle t�l�porter le joueur
    public float interactionDistance = 3.0f; // Distance d'interaction avec le Chronolith

    private GameObject player; // R�f�rence au joueur
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < interactionDistance)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        // Charger la sc�ne suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
