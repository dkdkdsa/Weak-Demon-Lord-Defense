using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataController : MonoBehaviour
{

    [field: Header("°ª")]
    [field: SerializeField] public float moveSpeed { get; protected set; }
    [field: SerializeField] public float attackPower { get; protected set; }
    [field: SerializeField] public float defenceValue { get; protected set; }
    [field: SerializeField] public float attackTime { get; protected set; }
    [field: SerializeField] public float skillCoolDown { get; protected set; }
    [field: SerializeField] public float maxHP { get; protected set; }
    [field: SerializeField] public SkillRoot skill { get; protected set; }
    [field: SerializeField] public LayerMask targetLayer { get; protected set; }

    [field: Space]
    [field: Header("AI")]
    [field: SerializeField] public float range { get; protected set; }
    [field: SerializeField] public float attackAbleRange { get; protected set; }

    protected float currentHP;

    public float extraAttack { get; protected set; }
    public float extraDef { get; protected set; }
    public bool attackAble { get; set; } = true;
    public bool skillAble { get; set; } = true;

    private void Awake()
    {

        currentHP = maxHP;

    }

    public virtual void TakeDamage(float damage)
    {

        currentHP -= damage;

        if(currentHP <= 0)
        {

            //Die

        }

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        var old = Gizmos.color;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackAbleRange);

        Gizmos.color = old;

    }

#endif

}
