using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> allEnemies;

    void Start()
    {
        GameObject spider = Instantiate(allEnemies[Random.Range(0, allEnemies.Count)]);
        spider.transform.position = this.transform.position;
    }
}
