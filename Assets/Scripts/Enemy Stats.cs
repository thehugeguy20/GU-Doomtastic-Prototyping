using System;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    internal EnemyDataScriptableObject Base;
    internal GameObject prefab;

    internal Stat health;
    internal Stat defense;
    internal Stat speed;

    private readonly float TEMPDIFFICULTY = 1;

    public EnemyStats(EnemyDataScriptableObject _base)
    {
        this.Base = _base;

        if (_base != null)
        {
            AddSOData();
        }

    }

    private void AddSOData()
    {
        prefab = Base.prefab;

        health = new Stat(_toggleable:false, min:Base.minMaxHP.x, max:Base.minMaxHP.y, TEMPDIFFICULTY);
        defense = new Stat(_toggleable:false, min:Base.minMaxDEF.x, max:Base.minMaxDEF.y, TEMPDIFFICULTY);
        speed = new Stat(_toggleable:false, min:Base.minMaxSPD.x, max:Base.minMaxSPD.y, TEMPDIFFICULTY);
    }
}