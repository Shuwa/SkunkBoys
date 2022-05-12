using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlots> slotDictionary;
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlots> SlotDictionary => slotDictionary;

   



    protected virtual void Start()
    {

    }
    public abstract void AssignSlot(InventorySystem invToDisplay);


    protected virtual void UpdateSlot(InventorySlots updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot)   // Slot Value - the "under the hood" inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot);  // Slot key - UI reprensation of the value 
            }
        }
    }
    public void SlotClicked(InventorySlot_UI clickedSlot)
    {
        Debug.Log("Slot clicked");

    }
}

