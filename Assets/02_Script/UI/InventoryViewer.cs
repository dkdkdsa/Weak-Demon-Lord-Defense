using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewer : MonoBehaviour
{

    [SerializeField] private Transform slotRoot;
    [SerializeField] private ItemSlot slotPrefab;

    private PlayerInventory inventory;

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

    private void HandleSlotClick(ItemData? item)
    {



    }

}
