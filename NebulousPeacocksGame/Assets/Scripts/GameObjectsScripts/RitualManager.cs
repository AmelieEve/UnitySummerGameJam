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
        return ((requireGlyph && presentedToGlyph) || (requireSacredObject && sacredObject.GetIsHeld()));
    }
}
