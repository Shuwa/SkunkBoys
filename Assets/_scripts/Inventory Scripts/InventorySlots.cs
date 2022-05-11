using UnityEngine;

[System.Serializable]
public class InventorySlots
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;
    // <><><><><>
    /// InventorySlotslogic ItemData
    // <><><><><>
    // Items löschen, zum StackAdden, MaxStacksize checken usw
    // <><><><><><><>
    public InventorySlots(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlots()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlots(InventoryItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.MaxStackSize) return true;
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

}
