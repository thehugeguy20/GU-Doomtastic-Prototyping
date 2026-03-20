using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KnockbackConfigScriptableObject", menuName = "Scriptable Objects/KnockbackConfigScriptableObject")]
public class KnockbackConfigScriptableObject : ScriptableObject
{
    public float KnockbackStrength = 1;

    public AnimationCurve ChargeMultiplier;

    public Vector3 GetKnockbackStrength(Vector3 direction, float charge)
    {
        return KnockbackStrength * ChargeMultiplier.Evaluate(charge) * direction;
    }
    
}
