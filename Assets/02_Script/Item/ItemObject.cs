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

        
        var randVec = Random.insideUnitSphere;
        randVec.y = 0;
        GetComponent<Rigidbody>().velocity = (Vector3.up + randVec) * 5;

        StartCoroutine(Del());

    }

    private void OnMouseDown()
    {
        
        FindObjectOfType<PlayerInventory>().AddItem(so);
        SoundManager.Instance.PlaySound("ItemClick");
        Destroy(gameObject);

    }

    private IEnumerator Del()
    {

        yield return new WaitForSeconds(15f);
        Destroy(gameObject);


    }

}
