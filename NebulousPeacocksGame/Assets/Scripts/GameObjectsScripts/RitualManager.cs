using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualManager : MonoBehaviour
{
    public ForbiddenAction forbiddenAction;

    private bool purified;
    private bool holdSacredObject;

    public bool isRitualCompleted()
    {
        return (purified && holdSacredObject);
    }

    void Update()
    {

    }
}
