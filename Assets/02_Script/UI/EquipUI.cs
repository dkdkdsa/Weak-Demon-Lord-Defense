using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUI : MonoBehaviour
{

    [SerializeField] private ItemSlot head, body, pants, weapon;
    [SerializeField] private Transform root;

    private UnitDataController dataController;
    private PlayerInventory inventoty;

    public void SetControl(UnitDataController unitDataController)
    {

        dataController = unitDataController;

    }

    public void EquipItem(ItemData item)
    {

        if (dataController == null) return;

        if (dataController.EquipItem(item))
        {



        }

    }

    private bool IsSlotFull(ItemType type)
    {



    }

    public void SetSlotSprite()
    {



    }

}
