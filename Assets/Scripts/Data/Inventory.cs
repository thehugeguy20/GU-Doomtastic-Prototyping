using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public int inventorySize = 10;

    [SerializeField] private Item[] _items;

    public Item[] items
    {
        // fucked up getter/setter. using the .Base prefab to check slots are empty and what aren't, and then to set certain slots as empty by making .Base null.
        get
        {
            if (_items == null || _items.Length == 0)
            {
                // create a new list with given inventory size
                _items = new Item[inventorySize];
                for (int i = 0; i < _items.Length; i++)
                {
                    //make a new item and set it's Base (an ItemDataScriptableObject) to null. this represents an empty slot.
                    _items[i] = new Item(_base:null);
                }
            }
            else
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    // check each Item within this array and if it's .Base is null, make absolutely sure that the class is correctly configured to represent an "empty slot"
                    if ( (_items[i] == null || _items[i].Base == null ) && _items[i].cleared != true )
                    {
                        _items[i] = new Item(null);
                        _items[i].cleared = true;
                    }
                }
            }
            return _items;
        }
    }
    
    public bool Add(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].Base == null)
            {
                items[i] = item;
                return true;
            }
        }
        Debug.Log("inv full");
        return false;
    }

    public Item Remove(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = new Item(null);
                return item;
            }
        }
        Debug.Log("cant find item");
        return null;
    }

    public Item RemoveAt(int index)
    {
        if (index < 0 || index >= items.Length)
        {
            Debug.Log("inventory does not contain slot" + index);
            return null;
        }

        Item item = items[index];
        items[index] = null;
        return item;
    }

    public Item GetLast()
    {
        for (int i = items.Length - 1; i >= 0; i--)
        {
            if (items[i].Base != null)
            {
                return items[i];
            }
        }
        
        return null;
    }

    public bool IsFull()
    {
        foreach(Item item in items)
        {
            if (item.Base == null)
            {
                return false;
            }
        }
        return true;

    }
}
