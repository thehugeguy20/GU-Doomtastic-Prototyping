using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject, System.ICloneable
{
    public float damage;
    public float attackRange;
    public Attributes.Modifier damageType;

    public float KnockbackStrength = 1;

    public AnimationCurve ChargeMultiplier;

    public Vector3 GetKnockbackStrength(Vector3 direction, float charge)
    {
        return KnockbackStrength * ChargeMultiplier.Evaluate(charge) * direction;
    }

    public object Clone()
    {
        ItemDataScriptableObject clone = CreateInstance<ItemDataScriptableObject>();

        Utilities.CopyValues(Base:this, Copy:clone);

        return clone;
    }
}
