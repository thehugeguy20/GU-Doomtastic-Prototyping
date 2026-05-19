using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Diagnostics;

[Serializable]
public class Item
{
    // base title = Sword
    private string baseName;
    // title = Cold Powerful Sword || Cold Sword || Powerful Sword || Sword
    public string title;
    public Sprite icon;

    [OnValueChanged("AddItemDataSO")]
    internal ItemDataScriptableObject Base;

    internal GameObject prefab;

    internal Stat attackRange;
    internal Stat knockbackStrength;
    internal Stat damage;

    // isTwoHanded is here so that you can't pick up anything with your left hand whilst holding a two handed item
    internal bool isTwoHanded {get; private set;}

    // how much the knockback increases as you hold your weapon (or item!) back (and charge it)
    internal AnimationCurve chargeMultiplier {get; private set;}

    // used to generate the prefix and suffix. see Stats.cs
    private WeaponStatGenerator statGen = new();

    internal Effect prefix;
    internal Effect suffix;

    public bool cleared;

    //OPTIONAL VALUES
    [HideIf("durability", null)]
    public Stat durability;
    [HideIf("charge", float.NaN)]
    public float charge;
    [HideIf("effect.affliction", Attributes.Effect.Normal)]
    public Effect effect;
    


    // this constructor is primarily so that a null _base can be passed, as whether or not Base is null is how we determine if an Item object is empty or not
    public Item(ItemDataScriptableObject _base)
    {
        this.Base = _base;

        prefix = statGen.GeneratePrefix();
        suffix = statGen.GenerateSuffix();

        if (_base != null)
        {
            AddSOData();
            title = $"{prefix.affixName}{suffix.affixName}{baseName}";
            //UnityEngine.Debug.Log(title);
        }
    }

    public Vector3 GetKnockbackStrength(Vector3 direction, float charge)
    {
        return knockbackStrength.total * chargeMultiplier.Evaluate(charge) * direction;
    } 

    // copies all base stats over from the ItemDataScriptableObject counterpart for whatever item's being created
    private void AddSOData()
    {
        attackRange = Base.attackRange;
        knockbackStrength = Base.KnockbackStrength;
        damage = Base.damage;
        isTwoHanded = Base.isTwoHanded;
        chargeMultiplier = Base.ChargeMultiplier;
        durability = Base.durability;
        isTwoHanded = Base.isTwoHanded;
        baseName = Base.baseName;
        prefab = Base.prefab;
        icon = Base.icon;
    }
}