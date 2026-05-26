using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    internal PlayerDataScriptableObject Base;
    internal GameObject prefab;

    [SerializeField] internal float health;
    internal Stat defense;
    internal Stat speed;
    internal Stat agility;

    [SerializeField] private GameObject deathPanel;
    
    public PlayerStats(PlayerDataScriptableObject _base)
    {
        Base = _base;

        if (_base != null)
        {
            AddSOData();
        }
    }

    private void Start()
    {
        health = 10f;
    }

    private void AddSOData()
    {
        prefab = Base.prefab;

        defense = Base.defense;
        speed = Base.speed;
        agility = Base.agility;
    }

    void Update()
    {
        if (health <= 0f)
        {
            deathPanel.SetActive(true);
            GameObject.Find("Time Scale Manager").GetComponent<TimeScaleManager>().StopTime();
        }
    }
}
