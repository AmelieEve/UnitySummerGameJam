using UnityEngine;

public class RitualManager : MonoBehaviour
{
    [HideInInspector]
    public bool presentedToGlyph;
    public ThrowableRock sacredObject;

    public bool IsRitualCompleted()
    {
        return (presentedToGlyph && sacredObject.GetIsHeld());
    }
}
