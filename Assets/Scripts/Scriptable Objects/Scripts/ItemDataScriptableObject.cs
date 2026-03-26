using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public GameObject prefab;

    public string baseName;

    // base stats: 
    // {get; private set;} = never changes 
    // normal public = can potentially change
    public Stat damage = new(_toggleable:false);
    public Stat attackRange = new(_toggleable:false);
    public Stat KnockbackStrength = new(_toggleable:false);

    // idk what to do about these but they should NEVER change
    public bool isTwoHanded;
    public AnimationCurve ChargeMultiplier;

    // optional values - all here are set to null or my own strange version of null - only truly exist on items when values are set to something
    public Stat durability = null;
}
