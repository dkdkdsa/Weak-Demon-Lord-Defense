using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataController : MonoBehaviour
{

    [Header("°ª")]
    [SerializeField] private float attackPower;
    [SerializeField] private float defenceValue;
    [SerializeField] private float attackTime;
    [SerializeField] private float skillCoolDown;
    [SerializeField] private LayerMask layer;
    [Header("AI")]
    [SerializeField] private float attackRange;
    [SerializeField] private float skillRange;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        var old = Gizmos.color;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, skillRange);

        Gizmos.color = old;

    }

#endif

}
