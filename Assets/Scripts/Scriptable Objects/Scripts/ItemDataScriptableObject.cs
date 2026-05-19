using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public string baseName;

    // base stats: 
    // {get; private set;} = never changes 
    // normal public = can potentially change
    public Stat damage = new Stat
    (
        _toggleable:false,
        _min: new MiniStat(
                _toggleable:false,
                _baseVal: 0f,
                _min: 0f,
                _max: 0f
            ),
        _max: new MiniStat(
                _toggleable:false,
                _baseVal: 20f,
                _min: 20f,
                _max: 30f
            )
    );

    public Stat attackRange = new Stat
    (
        _toggleable:false,
        _min: new MiniStat(
                _toggleable:false,
                _baseVal: 1f,
                _min: 1f,
                _max: 2f
            ),
        _max: new MiniStat(
                _toggleable:false,
                _baseVal: 6f,
                _min: 6f,
                _max: 6f
            )
    );

    public Stat KnockbackStrength = new Stat
    (
        _toggleable:false,
        _min: new MiniStat(
                _toggleable:false,
                _baseVal: 1f,
                _min: 1f,
                _max: 2f
            ),
        _max: new MiniStat(
                _toggleable:false,
                _baseVal: 6f,
                _min: 6f,
                _max: 6f
            )
    );

    // idk what to do about these but they should NEVER change
    public bool isTwoHanded;
    public AnimationCurve ChargeMultiplier;
    public Sprite icon;

    // optional values - all here are set to null or my own strange version of null - only truly exist on items when values are set to something
    public Stat durability = null;
}
