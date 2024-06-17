using UnityEngine;

[CreateAssetMenu(fileName = "RoboHelp", menuName = "ScriptableObjects/RoboHelp", order = 1)]
public class RoboHelp : ScriptableObject
{
    public string helpText; // Le texte d'aide que le robot doit afficher
    public AudioClip audioClip; // Le fichier audio que le robot doit jouer
    private int helpCount = 0; // Le nombre de fois que l'aide a été demandée
}
