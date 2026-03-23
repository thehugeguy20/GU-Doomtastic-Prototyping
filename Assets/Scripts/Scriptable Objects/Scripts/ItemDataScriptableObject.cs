using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject, System.ICloneable
{
    public GameObject prefab;
    public RuntimeAnimatorController animController;
    public RuntimeAnimatorController mirroredAnimController;

    // base stats: 
    // {get; private set;} = never changes 
    // normal public = can potentially change
    public float damage;
    public float attackRange;
    public float KnockbackStrength = 1;
    public Attributes.Modifier damageType = Attributes.Modifier.Normal;

    // idk what to do about these but they should NEVER change
    public bool isTwoHanded;
    public AnimationCurve ChargeMultiplier;

    // optional values - all here are set to null or my own strange version of null - only truly exist on items when values are set to something
    public float durability = float.NaN;
    public float charge = float.NaN;

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
