using System;
using UnityEngine;
using Sirenix.OdinInspector;

[Serializable]
public class Item
{
    private string baseName;
    public string title;

    [OnValueChanged("AddItemDataSO")]
    internal ItemDataScriptableObject Base;
    internal GameObject prefab;

    internal Stat attackRange;
    internal Stat knockbackStrength;
    internal Stat damage;

    internal bool isTwoHanded {get; private set;}
    internal AnimationCurve chargeMultiplier {get; private set;}

    private WeaponStatGenerator statGen = new();

    internal Effect prefix;
    internal Effect suffix;

    //OPTIONAL VALUES
    [HideIf("durability", null)]
    public Stat durability;
    [HideIf("charge", float.NaN)]
    public float charge;
    [HideIf("effect.affliction", Attributes.Effect.Normal)]
    public Effect effect;

    public Item(ItemDataScriptableObject _base)
    {
        this.Base = _base;

        prefix = statGen.GeneratePrefix();
        suffix = statGen.GenerateSuffix();

        if (_base != null)
        {
            AddSOData();
        }

        title = $"{prefix.affixName} {suffix.affixName} {baseName}";

    }

    public Vector3 GetKnockbackStrength(Vector3 direction, float charge)
    {
        return knockbackStrength.total * chargeMultiplier.Evaluate(charge) * direction;
    } 

    private void AddSOData()
    {
        attackRange = Base.attackRange;
        knockbackStrength = Base.KnockbackStrength;
        damage = Base.damage;
        isTwoHanded = Base.isTwoHanded;
        chargeMultiplier = Base.ChargeMultiplier;
        durability = Base.durability;
        isTwoHanded = Base.isTwoHanded;
        baseName = Base.name;
        prefab = Base.prefab;
    }
}