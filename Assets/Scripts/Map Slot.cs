using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovering;
    public GameObject pairedLevel;
    private int itemAmount;

    public int slotPos;

    public LevelManager levelManager;

    public List<MapSlot> adjacentSlots;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

}
