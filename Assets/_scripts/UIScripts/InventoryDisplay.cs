using System.Collections.Generic;
using UnityEngine;

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


        if (clickedSlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            /// If player holding shift -> Split the Stack


            mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssignedInventorySlot);
            clickedSlot.ClearSlot();
            Debug.Log("MouseITEM DEBUG1 ");
            return;

        }


        if (clickedSlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            Debug.Log("MouseITEM DEBUG2 ");///
            clickedSlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedSlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();

        }





        if (clickedSlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            bool isSameItem = clickedSlot.AssignedInventorySlot.ItemData == mouseInventoryItem.AssignedInventorySlot.ItemData;

            if (isSameItem && clickedSlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))

                
            {
                Debug.Log("MouseITEM DEBUG3 ");
                clickedSlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedSlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
            }
            else if (isSameItem &&
                !clickedSlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1) SwapSlots(clickedSlot); // Stack is full swap
                else // Slot not max, take what need from mouse .
                {
                    Debug.Log("MouseITEM DEBUG4 ");
                    int remainingOnMOuse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInStack;
                    clickedSlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedSlot.UpdateUISlot();

                    var newItem = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemData, remainingOnMOuse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);

                }
            }
            
            else if (!isSameItem)
            {
                Debug.Log("MouseITEM DEBUG6 ");
                SwapSlots(clickedSlot);
            }
        }

    }




    private void SwapSlots(InventorySlot_UI clickedSlot)
    {
        var clonedSlot = new InventorySlots(mouseInventoryItem.AssignedInventorySlot.ItemData, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssignedInventorySlot);

        clickedSlot.ClearSlot();
        clickedSlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedSlot.UpdateUISlot();
        Debug.Log("MouseITEM DEBUG7 ");
    }
}

