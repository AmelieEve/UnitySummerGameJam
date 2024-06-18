using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public bool requireGlyph;
    public bool requireSacredObject;

    [HideInInspector]
    public bool presentedToGlyph;
    public ThrowableRock sacredObject;

    public bool IsRitualCompleted()
    {
        bool completed = true;
        if (requireGlyph) completed = completed && presentedToGlyph;
        if (requireSacredObject) completed = completed && sacredObject.GetIsHeld();
        return completed;
    }
}
