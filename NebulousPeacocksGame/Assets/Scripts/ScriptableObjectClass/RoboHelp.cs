using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RoboHelp", menuName = "ScriptableObjects/RoboHelp", order = 1)]
public class RoboHelp : ScriptableObject
{
    public string helpText; // Le texte d'aide que le robot doit afficher
    public AudioClip audioClip; // Le fichier audio que le robot doit jouer
    public int helpCount = 0; // Le nombre de fois que l'aide a été demandée

    public int HelpCount
    {
        get { return helpCount; }
    }

    public void IncrementHelpCount()
    {
        helpCount++;
    }


}
