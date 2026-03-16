using System;
using UnityEngine;

[Serializable]
public class Attributes
{
    public enum Ai
    {
        normal, clumsy, skittish, angry
    }

    public enum Physical
    {
        normal, large, small, huge, tiny
    }

    public enum Modifier
    {
        normal, poison, fire, ice
    }


    public Ai ai;
    public Physical physical;
    public Modifier modifier;
    public Attribute attribute;

    public Attributes(Ai _ai, Physical _physical, Modifier _modifier)
    {
        this.ai = _ai;
        this.physical = _physical;
        this.modifier = _modifier;
    }

}
