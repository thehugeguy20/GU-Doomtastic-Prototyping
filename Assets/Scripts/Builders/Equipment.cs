using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] internal EquipSlot rightHand;
    [SerializeField] internal EquipSlot leftHand;

    public void EquipRightHand(Item item)
    {
        Item lastEquippedItem = rightHand.Unequip(dropItem:true);

        if (lastEquippedItem != null)
        {
            inventory.Add(lastEquippedItem);

            if (lastEquippedItem.isTwoHanded == true)
            {
                leftHand.IsEnabled(true);
            }
        }

        if (item.isTwoHanded == true)
        {
            leftHand.IsEnabled(false);
        }

        inventory.Remove(item);
        rightHand.Equip(item);
    }

    public void EquipLeftHand(Item item)
    {
        Item lastEquippedItem = leftHand.Unequip(dropItem:true);

        if (lastEquippedItem != null)
        {
            inventory.Add(lastEquippedItem);
        }

        inventory.Remove(item);
        leftHand.Equip(item);
    }

    public void UnequipRightHand()
    {
        Item lastEquippedItem = rightHand.Unequip(dropItem:true);

        if (lastEquippedItem == null)
        {
            return;
        }

        if (lastEquippedItem.isTwoHanded == true)
        {
            leftHand.IsEnabled(true);
        }

        inventory.Add(lastEquippedItem);
    }

    public void UnequipLeftHand()
    {
        Item lastEquippedItem = leftHand.Unequip(dropItem:true);

        if (lastEquippedItem != null)
        {
            inventory.Add(lastEquippedItem);
        }

        leftHand.IsEnabled(true);
    }

    public void DropRightHand()
    {
        rightHand.Unequip(dropItem:true);
    }

    public void DropLeftHand()
    {
        leftHand.Unequip(dropItem:true);
    }

    public void SwapHands()
    {
        Item rightItem = rightHand.currentItem;
        Item leftItem = leftHand.currentItem;

        rightHand.Unequip(dropItem:false);
        rightHand.Equip(leftItem);

        leftHand.Unequip(dropItem:false);
        leftHand.Equip(rightItem);
    }
}
