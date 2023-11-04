using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataController : MonoBehaviour
{

    [field: Header("°ª")]
    [field: SerializeField] public float attackPower { get; protected set; }
    [field: SerializeField] public float defenceValue { get; protected set; }
    [field: SerializeField] public float attackTime { get; protected set; }
    [field: SerializeField] public float skillCoolDown { get; protected set; }
    [field: SerializeField] public LayerMask layer { get; protected set; }

    [field: Space]
    [field: Header("AI")]
    [field: SerializeField] public float attackRange { get; protected set; }
    [field: SerializeField] public float skillRange { get; protected set; }

    public float extraAttack { get; protected set; }
    public float extraDef { get; protected set; }

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
