using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemObject : MonoBehaviour
{

    [SerializeField] private ItemSO so;

    private void Awake()
    {

        FAED.InvokeDelayRealTime(() =>
        {

            try
            {

                if (gameObject == null) return;

                Destroy(gameObject);

            }
            catch(System.Exception ex)
            {

                Debug.Log("ㅏㅎ하하하ㅏ하하에러가 뭘할수있는데ㅏ하하하핳");

            }



        }, 15);
        var randVec = Random.insideUnitSphere;
        randVec.y = 0;
        GetComponent<Rigidbody>().velocity = (Vector3.up + randVec) * 5;

    }

    private void OnMouseDown()
    {
        
        FindObjectOfType<PlayerInventory>().AddItem(so);
        Destroy(gameObject);

    }

}
