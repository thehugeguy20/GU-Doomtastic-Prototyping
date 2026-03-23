using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int inventorySize = 10;


    [SerializeField] private Item[] _items;

    public Item[] items
    {
        get
        {
            if (_items == null || _items.Length == 0)
            {
                _items = new Item[inventorySize];
                for (int i = 0; i < _items.Length; i++)
                {
                    _items[i] = new Item(null);
                }
            }
            else
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    if (_items[i] == null)
                    {
                        _items[i] = new Item(null);
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
            if (items[i].base_ == null)
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
            if (items[i].base_ != null)
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
            if (item.base_ == null)
            {
                return false;
            }
        }
        return true;

    }
}
