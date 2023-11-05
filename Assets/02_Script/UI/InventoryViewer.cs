using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewer : MonoBehaviour
{

    [SerializeField] private Transform slotRoot;
    [SerializeField] private ItemSlot slotPrefab;

    private PlayerInventory inventory;
    private EquipUI equipUI;
    private ItemUpgradeUI upgradeUI;

    private void Awake()
    {
        
        inventory = FindObjectOfType<PlayerInventory>();
        inventory.InventoryChangeEvent += HandleInventoryChanged;

    }

    private void HandleInventoryChanged()
    {

        int cnt = slotRoot.childCount;

        for (int i = 0; i < cnt; i++)
        {

            Destroy(slotRoot.GetChild(i).gameObject);

        }

        foreach(var item in inventory.inventory)
        {

            var slot = Instantiate(slotPrefab, slotRoot);
            slot.SettingItem(item);
            slot.OnSlotClickEvent += HandleSlotClick;

        }

    }

    public void SetEquip(EquipUI equip)
    {

        equipUI = equip;

    }

    public void SetItemUpgrade(ItemUpgradeUI upgrade)
    {

        upgradeUI = upgrade;

    }

    private void HandleSlotClick(ItemData? item)
    {

        if(equipUI != null)
        {

            equipUI.EquipItem(item.Value);
            return;

        }
        else if(upgradeUI != null)
        {

            upgradeUI.SetSlot(item.Value);
            inventory.RemoveItem(item.Value);
            return;

        }

    }

}
