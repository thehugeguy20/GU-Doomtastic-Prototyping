using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] internal EquipSlot rightHand;
    [SerializeField] internal EquipSlot leftHand;
    [SerializeField] private PlayerInit playerInit;

    public void EquipRightHand(Item item)
    {
        Item lastEquippedItem = rightHand.Unequip(dropItem:true);

        if (lastEquippedItem != null)
        {
            inventory.Add(lastEquippedItem);

            if (lastEquippedItem.base_.isTwoHanded == true)
            {
                leftHand.IsEnabled(true);
            }
        }

        if (item.base_.isTwoHanded == true)
        {
            leftHand.IsEnabled(false);
        }

        inventory.Remove(item);
        rightHand.Equip(item);
        playerInit.InjectDependents();
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
        playerInit.InjectDependents();
    }

    public void UnequipRightHand()
    {
        Item lastEquippedItem = rightHand.Unequip(dropItem:true);

        if (lastEquippedItem == null)
        {
            return;
        }

        if (lastEquippedItem.base_.isTwoHanded == true)
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
