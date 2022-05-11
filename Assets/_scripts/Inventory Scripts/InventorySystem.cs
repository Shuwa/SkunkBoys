using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlots> inventorySlots;

    public List<InventorySlots> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;
    public UnityAction<InventorySlots> OnInventorySlotsChanged;


    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlots>();
        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());
        }

    }


    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlots> invSlot)) //Checkt ob Item Existiert im Inventar
        {
            foreach (var slot in invSlot)                   // Check freie Items und stackt sie auf einen neuen Slot ggf
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotsChanged?.Invoke(slot);
                    return true;
                }
            }


        }

        if (HasFreeSlot(out InventorySlots freeSlot))   // Nimm den ersten freien InventarSlot
        {
            freeSlot.UpdateInventorySlots(itemToAdd, amountToAdd);
            OnInventorySlotsChanged?.Invoke(freeSlot);
            return true;
        }

        return false;

    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlots> invSlot)
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList(); // Checkt vorhanden InventorySlots, erstellt eine Liste vom Inventar
        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlots freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
