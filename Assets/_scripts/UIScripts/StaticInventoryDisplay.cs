//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using System.Collections;


//public class StaticInventoryDisplay : InventoryDisplay
//{
//    //[SerializeField] private InventoryHolder inventoryHolder;
//    [SerializeField] private InventorySlot_UI[] slots;
    




//    protected override void Start()

//    {
//        base.Start();



//        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
//   }




//    void DisplayInventory(InventorySystem invToDisplay)
//    {
//        inventorySystem = invToDisplay;
//        if (inventorySystem != null)
//            inventorySystem.OnInventorySlotsChanged += UpdateSlot;
       

//        AssignSlot(inventorySystem);

//    }
 

//    public override void AssignSlot(InventorySystem invToDisplay)
//    {
//        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlots>();

//        if (slots.Length != InventorySystem.InventorySize) Debug.Log($"Inventory slots out of sync on {this.gameObject}");

//        for (int i = 0; i < inventorySystem.InventorySize; i++)
//        {
//            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
//            slots[i].Init(inventorySystem.InventorySlots[i]);
//        }

//    }


































