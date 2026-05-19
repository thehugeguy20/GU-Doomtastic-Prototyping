using System.Collections.Generic;
using KinematicCharacterController;
using Unity.VisualScripting;
using UnityEngine;

public class REALLevelManagerREAL : MonoBehaviour
{
    public List<GameObject> allLevels;

    public GameObject currentLevel;

    public void ChangeLevel()
    {
        GameObject.Destroy(currentLevel);

        currentLevel = GameObject.Instantiate(allLevels[Random.Range(0,allLevels.Count)]);

        Debug.Log("spawn point global transform " + currentLevel.GetComponentInChildren<SpawnPoint>().transform);

        //GameObject.Find("Player").transform.position = currentLevel.GetComponentInChildren<SpawnPoint>().transform.position;

        GameObject player = GameObject.Find("Player");

        player.GetComponentInChildren<KinematicCharacterMotor>().SetPositionAndRotation(GameObject.Find("Spawn Point").transform.position, GameObject.Find("Spawn Point").transform.rotation, true);
    }
}
