using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlot_UI[] slots;
    




    protected override void Start()
    {
        base.Start();
        StartCheck();

        //if (inventoryHolder != null) 
        //{
        //    inventorySystem = inventoryHolder.InventorySystem;
        //    inventorySystem.OnInventorySlotsChanged += UpdateSlot;

        //}
        //else Debug.LogWarning($"No inventory assigned to{this.gameObject}");

        //AssignSlot(inventorySystem);
    }

    public void RefreshSlots()
  { 
    
         if (inventoryHolder != null) 
        {
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotsChanged += UpdateSlot;

        }
        else Debug.LogWarning($"No inventory assigned to{this.gameObject}");

        AssignSlot(inventorySystem);
}


IEnumerator StartCheck()
    {
        yield return new WaitForSeconds(5.00f);

        RefreshSlots();
    }


    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlots>();

        if (slots.Length != InventorySystem.InventorySize) Debug.Log($"Inventory slots out of sync on {this.gameObject}");

        for (int i = 0; i < inventorySystem.InventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }

    }





}
        
        






   









