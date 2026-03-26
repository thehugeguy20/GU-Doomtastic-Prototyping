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

public class FlatModifiers
{
    public List<Modifier> flatAdditions = new();

    public float CalculateTotal(float baseValue)
    {
        float sumOfFlats = 0f;

        foreach (Modifier mod in flatAdditions)
        {
            sumOfFlats += mod.value;
        }

        return baseValue + sumOfFlats;
    }
}

public class AdditiveModifiers
{
    public List<Modifier> additiveAdditions = new();

    public float CalculateTotal(float baseValue)
    {
        float sumOfAdditives = 1f;

        foreach (Modifier mod in additiveAdditions)
        {
            sumOfAdditives += mod.value;
        }

        return baseValue * sumOfAdditives;
    }
}

[Serializable]
public class Stat
{
    private bool toggleable = true;

    [HideIf("toggleable", false)]
    public bool isEnabled = true;

    public float baseValue = 1;
    public FlatModifiers flats = new();
    public AdditiveModifiers additives = new();

    public float total =>  additives.CalculateTotal(flats.CalculateTotal(baseValue));
    
    public Stat(bool _toggleable)
    {
        toggleable = _toggleable;
    }
}

public abstract class Effect
{
    public abstract AffixKey affix { get; }
    public abstract string affixName { get; }

    public Stat amount;

    private readonly float TEMPDIFFICULTY = 1;

    protected virtual float Generate(float difficulty)
    {
        return float.NaN;
    }

    public Effect()
    {
        amount = new Stat(_toggleable:true)
        {
            baseValue = Generate(TEMPDIFFICULTY)
        };
    }
}

public class Cold : Effect
{
    public override AffixKey affix { get => new(Prefix.Cold); }
    public override string affixName { get => "Cold";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Toxic : Effect
{
    public override AffixKey affix { get => new(Prefix.Toxic); }
    public override string affixName { get => "Toxic";}
    
    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Shredding : Effect
{
    public override AffixKey affix { get => new(Prefix.Shredding); }
    public override string affixName { get => "Shredding";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Powerful : Effect
{
    public override AffixKey affix { get => new(Suffix.Powerful); }
    public override string affixName { get => "Powerful";}

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
    public override AffixKey affix { get => new(Suffix.Disorienting); }
    public override string affixName { get => "Disorienting";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Lovestruck : Effect
{
    public override AffixKey affix { get => new(Suffix.Lovestruck); }
    public override string affixName { get => "Lovestruck";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Soft : Effect
{
    public override AffixKey affix { get => new(Suffix.Soft); }
    public override string affixName { get => "Soft";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(-1f, -3f);
    }
}

public class Healing : Effect
{
    public override AffixKey affix { get => new(Suffix.Healing); }
    public override string affixName { get => "Healing";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1f, 4f);
    }
}

public class Terrifying : Effect
{
    public override AffixKey affix { get => new(Suffix.Terrifying); }
    public override string affixName { get => "Terrifying";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public enum Prefix
{
    Toxic,
    Shredding,
    Cold
}

public enum Suffix
{
    Powerful,
    Disorienting,
    Lovestruck,
    Soft,
    Healing,
    Terrifying
}


public struct AffixKey
{
    public enum AffixType 
    {
        Prefix, 
        Suffix
    }

    public AffixType type;
    public int value;

    public AffixKey(Prefix prefix)
    {
        type = AffixType.Prefix;
        value = (int)prefix;
    }

    public AffixKey(Suffix suffix)
    {
        type = AffixType.Suffix;
        value = (int)suffix;
    }

}

public class WeaponStatGenerator
{
    public readonly Dictionary<AffixKey, System.Func<Effect>> affixEffectPairs = new()
    {
        { new AffixKey(Prefix.Toxic), () => new Toxic() },
        { new AffixKey(Prefix.Shredding), () => new Shredding() },
        { new AffixKey(Prefix.Cold), () => new Cold() },

        { new AffixKey(Suffix.Powerful), () => new Powerful() },
        { new AffixKey(Suffix.Disorienting), () => new Disorienting() },
        { new AffixKey(Suffix.Lovestruck), () => new Lovestruck() },
        { new AffixKey(Suffix.Soft), () => new Soft() },
        { new AffixKey(Suffix.Healing), () => new Healing() },
        { new AffixKey(Suffix.Terrifying), () => new Terrifying() }

    };

    public Effect GeneratePrefix()
    {
        int i = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Prefix)).Length);

        return affixEffectPairs[new AffixKey((Prefix)i)]();
    }

    public Effect GenerateSuffix()
    {
        int i = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Suffix)).Length);

        return affixEffectPairs[new AffixKey((Suffix)i)]();
    }
}

