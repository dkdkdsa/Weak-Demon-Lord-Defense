using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUI : MonoBehaviour
{

    [SerializeField] private ItemSlot head, body, pants, weapon;
    [SerializeField] private Transform root;

    private UnitDataController dataController;
    private PlayerInventory inventoty;

    private void Awake()
    {
        
        var compo = root.GetComponentsInChildren<ItemSlot>();

        foreach (var item in compo)
        {

            item.OnSlotClickEvent += HandleReleaseItem;

        }

    }

    public void SetControl(UnitDataController unitDataController)
    {

        dataController = unitDataController;

        for(int i = 0; i < 4; i++)
        {

            var t = (ItemType)i;

            SetSlotSprite(dataController.GetItem(t), t);

        }

    }

    public void EquipItem(ItemData item)
    {

        if (dataController == null) return;

        if (dataController.EquipItem(item))
        {

            inventoty.RemoveItem(item);
            SetSlotSprite(item, item.type);

        }

    }

    private void HandleReleaseItem(ItemData? item)
    {

        if(item != null && dataController != null)
        {

            SetSlotSprite(null, item.Value.type);
            inventoty.AddItem(item.Value);
            dataController.ReleaseItem(item.Value.type);

        }

    }


    public void SetSlotSprite(ItemData? item, ItemType type)
    {


        switch (type)
        {

            case ItemType.Body:
                body.SettingItem(item);
                break;
            case ItemType.Head:
                head.SettingItem(item);
                break;
            case ItemType.Pants:
                pants.SettingItem(item);
                break;
            case ItemType.Weapon:
                weapon.SettingItem(item);
                break;

        }

    }

}
