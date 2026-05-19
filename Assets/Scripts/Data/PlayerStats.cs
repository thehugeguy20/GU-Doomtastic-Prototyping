using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    internal PlayerDataScriptableObject Base;
    internal GameObject prefab;

    internal Stat health;
    internal Stat defense;
    internal Stat speed;
    internal Stat agility;
    
    public PlayerStats(PlayerDataScriptableObject _base)
    {
        Base = _base;

        if (_base != null)
        {
            AddSOData();
        }
    }

    private void AddSOData()
    {
        prefab = Base.prefab;

        health = Base.health;
        defense = Base.defense;
        speed = Base.speed;
        agility = Base.agility;
    }
}
