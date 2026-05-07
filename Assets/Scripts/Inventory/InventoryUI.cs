using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory;


    void Awake()
    {
        if (playerInventory == null)
        {
            playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
