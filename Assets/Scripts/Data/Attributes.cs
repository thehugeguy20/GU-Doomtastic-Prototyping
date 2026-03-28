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

    public enum Effect
    {
        Normal, Toxic, Cold, Shredding, Strong, Blinding
    }
}
