using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    [SerializeField] private ItemSO so;

    private void Awake()
    {

        FAED.InvokeDelayRealTime(() => Destroy(gameObject), 5f);

    }

    private void OnMouseDown()
    {
        
        FindObjectOfType<PlayerInventory>().AddItem(so);

    }

}
