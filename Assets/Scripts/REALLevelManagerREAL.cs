using System.Collections.Generic;
using KinematicCharacterController;
using Unity.VisualScripting;
using UnityEngine;

public class REALLevelManagerREAL : MonoBehaviour
{
    public List<GameObject> allLevels;

    public GameObject currentLevel;

    public GameObject spawnPoint;

    public int aliveEnemies;

    public int completedLevels;

    [SerializeField] private GameObject winPanel;

    public void Start()
    {
        aliveEnemies = currentLevel.GetComponent<LevelCore>().spawnerAmt;
    }

    public void ChangeLevel()
    {
        bool hasUniqueLevel = false;

        while (hasUniqueLevel == false)
        {
            int randIndex = Random.Range(0, allLevels.Count);

            if (allLevels[randIndex].name != currentLevel.name)
            {
                Destroy(currentLevel);
                currentLevel = Instantiate(allLevels[randIndex]);
                hasUniqueLevel = true;
            }
        }
        
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        GameObject.Find("Player").GetComponentInChildren<KinematicCharacterMotor>().SetPositionAndRotation(GameObject.Find("Spawn Point").transform.position, GameObject.Find("Spawn Point").transform.rotation);

        aliveEnemies = currentLevel.GetComponent<LevelCore>().spawnerAmt;

        completedLevels += 1;
    }

    public void Update()
    {
        if (completedLevels >= 10)
        {
            winPanel.SetActive(true);
            GameObject.Find("Time Scale Manager").GetComponent<TimeScaleManager>().StopTime();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeLevel();
        }
    }

}