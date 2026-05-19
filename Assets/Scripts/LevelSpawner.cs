using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> allLevels;

    public MapSlot currentLevel;

    public List<MapSlot> allSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCurrentLevel()
    {
        Destroy(currentLevel.pairedLevel);
        currentLevel = null;
    }

    public MapSlot GetHoveredMapSlot()
    {
        foreach(MapSlot mapSlot in allSlots)
        {
            if (mapSlot.hovering)
            {
                return mapSlot;
            }
        }
        return null;
    }

    public void SelectLevel()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MapSlot hovered = GetHoveredMapSlot();

            if (currentLevel.adjacentSlots.Contains(hovered))
            {
                
            }
        }
    }
}
