
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlot;

    private Button button;

    public InventorySlots AssignedInventorySlot => assignedInventorySlot;


    private void Awake()
    {
        ClearSlot();

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }


    public void Init(InventorySlots slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);

    }

    public void UpdateUISlot(InventorySlots slot)
    {
        if (slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1) itemCount.text = slot.StackSize.ToString();
            else itemCount.text = "";
        }
        else
        {
            ClearSlot();
        }


    }

    public void UpdateUISlot()
    {
        if (assignedInventorySlot != null) UpdateUISlot(AssignedInventorySlot);
    }

    public void OnUISlotClick()
    {
        //Access display Class
    }


}
