using System;
using System.Collections.Generic;
using UnityEngine;




public class Stats : MonoBehaviour
{

    [Serializable]
    public class Stat
    {
        public bool isEnabled;
        public float data;
    }

    public class Health
    {
        public bool isEnabled;
        public float data;
    }

    private class Armour
    {
        public bool isEnabled;
        public float data;
    }

    private class Mana
    {
        public bool isEnabled;
        public float data;
    }

    private class Speed
    {
        public bool isEnabled;
        public float data;
    }

    // Experimental
    private class Luck
    {
        public bool isEnabled;
        public float data;
    }




    public Dictionary <string, dynamic> stats = new();



    // [SerializeField] private Stat health;
    // [SerializeField] private Stat speed;

    // private Dictionary<string, Stat> floatStats;

    // void Awake()
    // {
    //     floatStats[health.ToString()] = health;
    //     floatStats[speed.ToString()] = speed;
    // }

    // public void TryChangeFloatStat(string statName, float statChange)
    // {
    //     if (floatStats.TryGetValue(statName, out Stat stat))
    //     {
    //         Stat changingStat = floatStats[statName];

    //         changingStat.data += statChange;

    //         floatStats[statName] = changingStat;
    //     }
    // }

    // public void TryEnableStat(string statName)
    // {
    //     if (floatStats.TryGetValue(statName, out Stat stat))
    //     {
    //         Stat changingStat = floatStats[statName];

    //         changingStat.isEnabled = true;
    //     }
    // }

    // public void TryDisableStat(string statName)
    // {
    //     if (floatStats.TryGetValue(statName, out Stat stat))
    //     {
    //         Stat changingStat = floatStats[statName];

    //         changingStat.isEnabled = false;
    //     }
    // }

    //this is stupid
}
