using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab;
    protected override void Start()
    {
        base.Start();
    }

    public void RefreshDynamicInventory(InventorySystem invtoDisplay)
    {
        ClearSlots();
        inventorySystem = invtoDisplay;
        if (inventorySystem != null) inventorySystem.OnInventorySlotsChanged += UpdateSlot;
        AssignSlot(invtoDisplay);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        ClearSlots();

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlots>();

        if (invToDisplay == null) return;

        for (int i = 0; i < invToDisplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.Init(invToDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    private void ClearSlots()
    {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }

        if (slotDictionary != null) slotDictionary.Clear();
    }

    private void OnDisable()
    {
        if (inventorySystem != null) inventorySystem.OnInventorySlotsChanged -= UpdateSlot;
    }
}



