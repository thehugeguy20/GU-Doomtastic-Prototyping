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
    internal Stat damage;

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

        health = new Stat
        (
            _toggleable:false,
            minBaseVal:Base.baseHP.x,
            maxBaseVal:Base.baseHP.y,
            TEMPDIFFICULTY,
            Base.minHP,
            Base.maxHP

        );

        defense = new Stat
        (
            _toggleable:false,
            minBaseVal:Base.baseHP.x,
            maxBaseVal:Base.baseHP.y,
            TEMPDIFFICULTY,
            Base.minDEF,
            Base.maxDEF

        );

        speed = new Stat
        (
            _toggleable:false,
            minBaseVal:Base.baseHP.x,
            maxBaseVal:Base.baseHP.y,
            TEMPDIFFICULTY,
            Base.minSPD,
            Base.maxSPD
        );

        damage = Base.damage;
    }
}