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
    public List<Modifier> list = new();

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

public class AdditiveModifiers
{
    public List<Modifier> list = new();

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

[Serializable]
public class Stat
{
    private bool toggleable = true;

    [HideIf("toggleable", false)]
    public bool isEnabled = true;

    public float baseValue = 1;
    public FlatModifiers flats = new();
    public AdditiveModifiers additives = new();

    public float total => additives.CalculateTotal(flats.CalculateTotal(baseValue));

    public float changes;

    public float value => total + changes;


    public Stat(bool _toggleable)
    {
        toggleable = _toggleable;
    }

    public Stat(bool _toggleable, float min, float max, float weight)
    {
        toggleable = _toggleable;
        baseValue = UnityEngine.Random.Range(min, max) * weight;
    }
}

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
        amount = new Stat(_toggleable:true)
        {
            baseValue = Generate(TEMPDIFFICULTY)
        };
    }
}

public class Cold : Effect
{
    public override Affix affix { get => new(Prefix.Cold); }
    public override string affixName { get => "Cold";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Toxic : Effect
{
    public override Affix affix { get => new(Prefix.Toxic); }
    public override string affixName { get => "Toxic";}
    
    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Shredding : Effect
{
    public override Affix affix { get => new(Prefix.Shredding); }
    public override string affixName { get => "Shredding";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(2f, 7f) * difficulty;
    }
}

public class Powerful : Effect
{
    public override Affix affix { get => new(Suffix.Powerful); }
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
    public override Affix affix { get => new(Suffix.Disorienting); }
    public override string affixName { get => "Disorienting";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Lovestruck : Effect
{
    public override Affix affix { get => new(Suffix.Lovestruck); }
    public override string affixName { get => "Lovestruck";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1.5f, 3f);
    }
}

public class Soft : Effect
{
    public override Affix affix { get => new(Suffix.Soft); }
    public override string affixName { get => "Soft";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(-1f, -3f);
    }
}

public class Healing : Effect
{
    public override Affix affix { get => new(Suffix.Healing); }
    public override string affixName { get => "Healing";}

    protected override float Generate(float difficulty)
    {
        return UnityEngine.Random.Range(1f, 4f);
    }
}

public class Terrifying : Effect
{
    public override Affix affix { get => new(Suffix.Terrifying); }
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


public struct Affix
{
    public enum AffixType 
    {
        Prefix, 
        Suffix
    }

    public AffixType type;
    public int value;

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

public class WeaponStatGenerator
{
    public readonly Dictionary<Affix, System.Func<Effect>> affixEffectPairs = new()
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
        int i = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Prefix)).Length);

        return affixEffectPairs[new Affix((Prefix)i)]();
    }

    public Effect GenerateSuffix()
    {
        int i = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Suffix)).Length);

        return affixEffectPairs[new Affix((Suffix)i)]();
    }
}

