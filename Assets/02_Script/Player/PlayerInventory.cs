using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public List<ItemSO> debugingItem;
    public event Action InventoryChangeEvent;

    public List<ItemData> inventory { get; private set; } = new();

    private void Start()
    {

        foreach (var item in debugingItem)
        {

            AddItem(item);

        }

    }

    public void AddItem(ItemSO item)
    {

        inventory.Add(item.CreateItemData());

        InventoryChangeEvent?.Invoke();

    }

    public void AddItem(ItemData item)
    {

        inventory.Add(item);

        InventoryChangeEvent?.Invoke();

    }

    public void RemoveItem(in ItemData itemData)
    {

        inventory.Remove(itemData);

        InventoryChangeEvent?.Invoke();

    }

}