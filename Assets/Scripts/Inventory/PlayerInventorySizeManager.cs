using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerInventoryUIManager : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject playerCharacter;
    public GameObject slotPrefab;
    public List<Slot> inventorySlots;

    public GameObject inventorySlotObject;

    public EquipSlot rightHandEquipSlot;
    public EquipSlot leftHandEquipSlot;

    public Slot rightHand;
    public Slot leftHand;

    public List<Slot> allSlots;

    public UnityEngine.UI.Image dragIcon;

    private Slot draggedSlot;
    private bool isDragging;


    void Awake()
    {
        if (playerInventory == null)
        {
            playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        }

        if (rightHandEquipSlot == null)
        {
            rightHandEquipSlot = GameObject.Find("Right Hand").GetComponentInChildren<EquipSlot>();
        }

        if (leftHand == null)
        {
            leftHandEquipSlot = GameObject.Find("Left Hand").GetComponentInChildren<EquipSlot>();
        }
    }

    void Start()
    {
        Debug.Log("inv size = " + playerInventory.inventorySize);
        for(int i = 0; i < playerInventory.inventorySize; i++)
        {
            Debug.Log("creating itemsz");
            GameObject newSlot = Instantiate(slotPrefab, inventorySlotObject.transform.position, inventorySlotObject.transform.rotation, inventorySlotObject.transform);

            newSlot.tag = "inventorySlot";

            newSlot.GetComponent<Slot>().slotPos = i;

            inventorySlots.Add(newSlot.GetComponent<Slot>());
        }

        allSlots.Add(leftHand);
        allSlots.Add(rightHand);
        allSlots.AddRange(inventorySlots);

        dragIcon.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateSlotData();
        StartDrag();
        UpdateDraggedItemPosition();
        EndDrag();
    }

    void UpdateSlotData()
    {

        if (playerInventory.items.Count() > 0 && inventorySlots.Count() > 0)
        {
            for(int i = 0; i < playerInventory.items.Count(); i++)
            {
                Slot uiSlot = inventorySlots[i];

                Item inventoryItem = playerInventory.items[i];
                uiSlot.GetComponent<UnityEngine.UI.Image>().sprite = inventoryItem.icon;
                uiSlot.pairedItem = inventoryItem;

            }        
        }


        if (!rightHandEquipSlot.isEmpty)
        {
            Item rightHandItem = rightHandEquipSlot.currentItem;
            rightHand.pairedItem = rightHandEquipSlot.currentItem;
            rightHand.GetComponent<UnityEngine.UI.Image>().sprite = rightHandItem.icon;
            rightHand.GetComponent<UnityEngine.UI.Image>().color = new Color (1, 1, 1, 1f);
            //Debug.Log("assigned right hand icon");
        }
        else
        {
            rightHand.pairedItem = new Item(null);
            rightHand.GetComponent<UnityEngine.UI.Image>().color = new Color (1, 1, 1, 0f);
        }

        if (!leftHandEquipSlot.isEmpty)
        {
            Item leftHandItem = leftHandEquipSlot.currentItem;
            leftHand.pairedItem = leftHandEquipSlot.currentItem;
            leftHand.GetComponent<UnityEngine.UI.Image>().sprite = leftHandItem.icon;
            leftHand.GetComponent<UnityEngine.UI.Image>().color = new Color (1, 1, 1, 1f);
            //Debug.Log("assigned left hand icon");
        }
        else
        {
            leftHand.pairedItem = new Item(null);
            leftHand.GetComponent<UnityEngine.UI.Image>().color = new Color (1, 1, 1, 0f);
        }
    }

    private void StartDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Slot hovered = GetHoveredSlot();

            if (hovered != null && hovered.pairedItem.Base != null)
            {
                dragIcon.gameObject.SetActive(true);
                draggedSlot = hovered;
                isDragging = true;
                dragIcon.sprite = hovered.pairedItem.icon;
                dragIcon.color = new Color(1, 1, 1, 0.5f);
                dragIcon.enabled = true;
            }
        }
    }

    private void EndDrag()
    {
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            dragIcon.gameObject.SetActive(false);
            Slot hovered = GetHoveredSlot();

            if (hovered != null)
            {
                HandleDrop(draggedSlot, hovered);

                dragIcon.enabled = false;
                draggedSlot = null;
                isDragging = false;
            }
            else
            {
                DropOnGround(draggedSlot);
                draggedSlot = null;
                dragIcon.enabled = false;
                isDragging = false;
            }

        }
    }

    private void HandleDrop(Slot from, Slot to)
    {
        Debug.Log("dropping");

        if (from == to)
        {
            Debug.Log("from = to");
            return;
        }

        if (to.pairedItem.Base != null)
        {
            Debug.Log("to.pairedItem.Base != null");
            Item tempToItem = to.pairedItem;
            Item tempFromItem = from.pairedItem;

            playerInventory.items[to.slotPos] = tempFromItem;
            playerInventory.items[from.slotPos] = tempToItem;
            return;
        }

        Debug.Log("to is empty");
        playerInventory.items[to.slotPos] = from.pairedItem;
        //playerInventory.RemoveAt(from.slotPos);
        playerInventory.items[from.slotPos] = new Item(null);
    }

    private void DropOnGround(Slot slot)
    {
        Item tempItem = slot.pairedItem;

        playerInventory.items[slot.slotPos] = new Item(null);

        GameObject droppedObj = Instantiate
        (
            tempItem.prefab, 
            new Vector3
            (
                playerCharacter.transform.position.x,
                2.07f,
                playerCharacter.transform.position.z
            ), 
            playerCharacter.transform.rotation
        );

        droppedObj.GetComponent<ItemCore>().item = tempItem;
    }

    private void UpdateDraggedItemPosition()
    {
        if(isDragging)
        {
            dragIcon.transform.position = Input.mousePosition;
        }
    }

    private Slot GetHoveredSlot()
    {
        foreach(Slot slot in allSlots)
        {
            if (slot.hovering)
            {
                return slot;
            }
        }

        return null;
    }
}
