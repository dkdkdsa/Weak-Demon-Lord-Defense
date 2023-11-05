using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewer : MonoBehaviour
{

    [SerializeField] private Transform slotRoot;

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


            Destroy(slotRoot.GetChild(0).gameObject);

        }

    }

}
