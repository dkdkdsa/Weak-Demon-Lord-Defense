using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSkill : MonoBehaviour
{

    [SerializeField] private float range;
    [SerializeField] private float castDelay;

    public void Casting(float damage, LayerMask targetLayer)
    {

        var arr = Physics.OverlapSphere(transform.position, range, targetLayer);

        FAED.InvokeDelay(() =>
        {

            foreach (var item in arr)
            {

                if(item == null) continue;
                item.GetComponent<UnitDataController>().TakeDamage(damage);

            }

        }, castDelay);

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        var old = Gizmos.color;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);

    }

#endif

}
