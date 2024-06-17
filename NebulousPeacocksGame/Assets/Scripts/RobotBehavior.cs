using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    private Transform player; // Référence au joueur
    public float speed = 5.0f; // Vitesse de déplacement du robot
    public float stoppingDistance = 2.0f; // Distance à laquelle le robot s'arrête

    private AudioSource audioSource;

    void Start()
    {
        // Trouver le joueur par son tag
        player = GameObject.FindWithTag("Player").transform;

        // Ajouter un composant AudioSource au robot si ce n'est pas déjà fait
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Vérifier si la référence au joueur est assignée
        if (player != null)
        {
            // Calculer la distance entre le robot et le joueur
            float distance = Vector3.Distance(transform.position, player.position);

            // Si la distance est supérieure à la distance d'arrêt, déplacer le robot vers le joueur
            if (distance > stoppingDistance)
            {
                // Calculer la direction vers le joueur
                Vector3 direction = (player.position - transform.position).normalized;

                // Déplacer le robot vers le joueur
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
        // Dessiner une sphère pour visualiser la distance d'arrêt dans l'éditeur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
