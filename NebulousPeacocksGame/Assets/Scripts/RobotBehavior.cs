using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Transform player; // R�f�rence au joueur
    public float speed = 5.0f; // Vitesse de d�placement du robot
    public float stoppingDistance = 2.0f; // Distance � laquelle le robot s'arr�te

    private AudioSource audioSource;

    void Start()
    {
        // Trouver le joueur par son tag
        player = GameObject.FindWithTag("Player").transform;

        // Ajouter un composant AudioSource au robot si ce n'est pas d�j� fait
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // V�rifier si la r�f�rence au joueur est assign�e
        if (player != null)
        {
            // Calculer la distance entre le robot et le joueur
            float distance = Vector3.Distance(transform.position, player.position);

            // Si la distance est sup�rieure � la distance d'arr�t, d�placer le robot vers le joueur
            if (distance > stoppingDistance)
            {
                // Calculer la direction vers le joueur
                Vector3 direction = (player.position - transform.position).normalized;

                // D�placer le robot vers le joueur
                transform.position += direction * speed * Time.deltaTime;

                // Optionnel : faire pivoter le robot pour qu'il fasse face au joueur
                transform.LookAt(player);
            }
        }
    }

    public void PlayRoboHelp(RoboHelp roboHelp)
    {
        if (roboHelp != null && roboHelp.audioClip != null)
        {
            audioSource.clip = roboHelp.audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("RoboHelp or audioClip is null.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dessiner une sph�re pour visualiser la distance d'arr�t dans l'�diteur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
