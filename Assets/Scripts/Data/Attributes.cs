using System;
using UnityEngine;

[Serializable]
public class Attributes
{
    public enum Ai
    {
        Null, Normal, Clumsy, Skittish, Angry
    }

    public enum Physical
    {
        Null, Normal, Large, Small, Huge, Tiny
    }

    public enum Modifier
    {
        Null, Normal, Poison, Fire, Ice
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
