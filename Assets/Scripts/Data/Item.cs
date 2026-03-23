using System;
using UnityEngine;
using Sirenix.OdinInspector;

[Serializable]
public class Item
{
    public string name;

    [OnValueChanged("AddItemDataSO")]
    public ItemDataScriptableObject base_;

    public Attributes.Modifier damageType;

    [HideIf("durability", float.NaN)]
    public float durability;
    [HideIf("charge", float.NaN)]
    public float charge;

    public Item(ItemDataScriptableObject base_)
    {
        this.base_ = base_;

        if (base_ != null)
        {
            AddItemDataSO();
        }
    }

    private void AddItemDataSO()
    {
        durability = base_.durability;
        charge = base_.charge;
        damageType = base_.damageType;
    }
}