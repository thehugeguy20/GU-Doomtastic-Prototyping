using System.Collections.Generic;
using UnityEngine;

public class LevelCore : MonoBehaviour
{
    public List<GameObject> enemySpawners;

    public int spawnerAmt;

    void Start()
    {
        this.name = "Level";
    }
    
}
