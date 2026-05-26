using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public enum ModifierType
{
    Flat,
    Additive
}

// contains the type of the modifier and a value (additive, 7f)
public struct Modifier
{
    public ModifierType type {get; private set;}
    public readonly float value;

    public Modifier(ModifierType _type, float _value)
    {
        type = _type;
        value = _value;
    }
}

// a list of flat modifiers (+7 sword damage, +3 fire damage, +2 strength)
public class FlatModifiers
{
    public List<Modifier> list = new();

    // add all flat modifiers together and then add that number onto our base value
    public float CalculateTotal(float baseValue)
    {
        float sumOfFlats = 0f;

        foreach (Modifier mod in list)
        {
            sumOfFlats += mod.value;
        }

        return baseValue + sumOfFlats;
    }
}

// a list of additive modifiers (+70% sword damage, +30% fire damage, +2% strength)
public class AdditiveModifiers
{
    public List<Modifier> list = new();

    // add all additive modifiers together and then multiply our base value by that number (aka +30% strength and +20% stength = +50% strength)
    public float CalculateTotal(float baseValue)
    {
        float sumOfAdditives = 1f;

        foreach (Modifier mod in list)
        {
            sumOfAdditives += mod.value;
        }

        return baseValue * sumOfAdditives;
    }
}

// a class to represent a "stat". a stat is something with a value that can be increased or decreased permenantly, and is associated with an object
// such as: a strength stat on the player character, a health stat on an enemy, a luck stat for a slot machine
[Serializable]
public class Stat
{
    private bool toggleable = true;

    [HideIf("toggleable", false)]
    public bool isEnabled = true;

    public float baseValue = 1;
    public MiniStat min;
    public MiniStat max;
    public FlatModifiers flats = new();
    public AdditiveModifiers additives = new();

    // the sum of the base stat + it's modifiers
    public float total => baseValue;

    // this is where things like damage from enemies or temporary changes to the total are stored
    public float changes;

    // so then the value = (the sum of the base stat + it's modifiers) + it's changes
    public float value => (total + changes);

    public void ChangeStat(float newChange)
    {
        changes += newChange;
    }

    public Stat(bool _toggleable, MiniStat _min, MiniStat _max)
    {
        toggleable = _toggleable;
        min = _min;
        max = _max;
    }

    public Stat(bool _toggleable, float minBaseVal, float maxBaseVal, float weight, MiniStat _min, MiniStat _max)
    {
        toggleable = _toggleable;
        baseValue = UnityEngine.Random.Range(minBaseVal, maxBaseVal) * weight;
        min = _min;
        max = _max;
    }
}

[Serializable] 
public class MiniStat
{
    private bool toggleable = true;

    [HideIf("toggleable", false)]
    public bool isEnabled = true;

    public float baseValue = 1;
    public FlatModifiers flats = new();
    public AdditiveModifiers additives = new();

    public float min;
    public float max;

    public float value => baseValue;

    public MiniStat(bool _toggleable, float _baseVal, float _min, float _max)
    {
        toggleable = _toggleable;
        baseValue = _baseVal;
        min = _min;
        max = _max;
    }
}

// a prefix is a modifier for the weapon (cold, fire, poison) that allows you to deal more or different damage
public enum Prefix
{
    Null,
    Toxic,
    Shredding,
    Cold
}

// a suffix is a modifier for the weapon that effects the way your weapon works (powerful = more knockback, healing = heal on hit)
public enum Suffix
{
    Null,
    Powerful,
    Disorienting,
    Lovestruck,
    Soft,
    Healing,
    Terrifying
}


// this is the base for an affix (a suffix is a type of affix. a prefix is also a type of affix.) 
public struct Affix
{
    public enum AffixType 
    {
        Prefix, 
        Suffix
    }

    public AffixType type;
    public int value;

    // constructors for creating either a prefix or a suffix
    public Affix(Prefix prefix)
    {
        type = AffixType.Prefix;
        value = (int)prefix;
    }

    public Affix(Suffix suffix)
    {
        type = AffixType.Suffix;
        value = (int)suffix;
    }
}

// this is an effect, which pairs an affix (cold, disorientating), with a stat that holds the affix's values (base value, modifiers, etc), alongside a name
public abstract class Effect
{
    public abstract Affix affix { get; }
    public abstract string affixName { get; }

    public Stat amount;

    private readonly float TEMPDIFFICULTY = 1;

    protected virtual float Generate(float difficulty)
    {
        return float.NaN;
    }

    public Effect()
    {
        amount = new Stat
        (
            _toggleable:true,
            _min: new MiniStat
            (
                _toggleable: true,
                _baseVal: 0f,
                _min: 0f,
                _max: 0f
            ),
            _max: new MiniStat
            (
                _toggleable: true,
                _baseVal: 10f,
                _min: 10f,
                _max: 20f
            )
        )
        {
            baseValue = Generate(TEMPDIFFICULTY)
        };
    }
}

public class EmptyPrefix : Effect
{
    public override Affix affix { get => new(Prefix.Null); }
    public override string affixName { get => "";}

    protected override float Generate(float difficulty)
    {
        return 0f;
    }
}

public class EmptySuffix : Effect
{
    public override Affix affix { get => new(Suffix.Null); }
    public override string affixName { get => "";}

    protected override float Generate(float difficulty)
    {
        return 0f;
    }
}

public class Cold : Effect
{
    public override Affix affix { get => new(Prefix.Cold); }
    public override string affixName { get => "Cold ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Toxic : Effect
{
    public override Affix affix { get => new(Prefix.Toxic); }
    public override string affixName { get => "Toxic ";}
    
    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Shredding : Effect
{
    public override Affix affix { get => new(Prefix.Shredding); }
    public override string affixName { get => "Shredding ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Powerful : Effect
{
    public override Affix affix { get => new(Suffix.Powerful); }
    public override string affixName { get => "Powerful ";}

    protected override float Generate(float difficulty)
    {
        if (difficulty > 4)
        {
            return UnityEngine.Random.Range(2f, 4f);
        }
        else return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Disorienting : Effect
{
    public override Affix affix { get => new(Suffix.Disorienting); }
    public override string affixName { get => "Disorienting ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Lovestruck : Effect
{
    public override Affix affix { get => new(Suffix.Lovestruck); }
    public override string affixName { get => "Lovestruck ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Soft : Effect
{
    public override Affix affix { get => new(Suffix.Soft); }
    public override string affixName { get => "Soft ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(-1f, -3f);
    }
}

public class Healing : Effect
{
    public override Affix affix { get => new(Suffix.Healing); }
    public override string affixName { get => "Healing ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1f, 4f);
    }
}

public class Terrifying : Effect
{
    public override Affix affix { get => new(Suffix.Terrifying); }
    public override string affixName { get => "Terrifying ";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

// this holds 2 methods: GeneratePrefix() and GenerateSuffix(). these will generally be used in tandem to give weapons a chance to have a prefix and suffix (with suffixes being more common)
public class WeaponStatGenerator
{
    // dictionary which pairs each affix with a function that returns said affix's class. this is just a nice way to get each class through a lookup
    public Dictionary<Affix, System.Func<Effect>> affixEffectPairs = new()
    {
        { new Affix(Prefix.Toxic), () => new Toxic() },
        { new Affix(Prefix.Shredding), () => new Shredding() },
        { new Affix(Prefix.Cold), () => new Cold() },

        { new Affix(Suffix.Powerful), () => new Powerful() },
        { new Affix(Suffix.Disorienting), () => new Disorienting() },
        { new Affix(Suffix.Lovestruck), () => new Lovestruck() },
        { new Affix(Suffix.Soft), () => new Soft() },
        { new Affix(Suffix.Healing), () => new Healing() },
        { new Affix(Suffix.Terrifying), () => new Terrifying() }

    };

    public Effect GeneratePrefix()
    {
        if (UnityEngine.Random.Range(0, 10) != 0)
        {
            return new EmptyPrefix();
        }
        else
        {
            int i = UnityEngine.Random.Range(1, Enum.GetNames(typeof(Prefix)).Length);

            return affixEffectPairs[new Affix((Prefix)i)]();
        }
    }

    public Effect GenerateSuffix()
    {
        if (UnityEngine.Random.Range(0, 6) != 0)
        {
            return new EmptySuffix();
        }
        else
        {
            // Enum.GetNames().Length is getting a list of all the suffixes, and then getting the length of that list, and then getting a random num between 1 and the length
            // the reason it's 1 is because the first suffix & preffix in each respective enum is Null, which is to represent no affix at all.
            int i = UnityEngine.Random.Range(1, Enum.GetNames(typeof(Suffix)).Length);

            // then, since enums are effectively just dressed up integers, you can use i find which suffix is actually represented by the integer you generated, and grab that class via the dictionary
            return affixEffectPairs[new Affix((Suffix)i)]();
        }
    }
}

