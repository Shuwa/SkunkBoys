using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;

    public InventorySystem SecondaryInventorySystem => secondaryInventorySystem;
    public static UnityAction<InventorySystem> OnPlayerBackpackDisplayRequsted;

    protected override void Awake()
    {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    void Start()
    {

    }


    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame) OnPlayerBackpackDisplayRequsted?.Invoke(SecondaryInventorySystem); //KeyChangen
    }


    public bool AddToInventory(InventoryItemData data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }
        else if (secondaryInventorySystem.AddToInventory(data, amount))
        {
            return true;

        }
        return false;
    }
}
