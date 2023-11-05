using System;
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
    [field: SerializeField] public HPBar hPBarPrefab { get; protected set; }

    [field: Space]
    [field: Header("AI")]
    [field: SerializeField] public float range { get; protected set; }
    [field: SerializeField] public float attackAbleRange { get; protected set; }

    protected UnitAnimator animator;
    protected HPBar hpBar;
    protected Dictionary<ItemType, ItemData?> itemContainer = new();


    public event Action OnValueChanged;

    public float currentHP { get; protected set; }
    public float extraAttack { get; protected set; }
    public float extraDef { get; protected set; }
    public float extraHP { get; protected set; }
    public bool attackAble { get; set; } = true;
    public bool skillAble { get; set; } = true;

    protected virtual void Awake()
    {

        currentHP = maxHP;
        animator = transform.Find("Visual/UnitRoot").GetComponent<UnitAnimator>();
        skill = Instantiate(skill);
        hpBar = Instantiate(hPBarPrefab, transform.position + new Vector3(0, 2, 0.3f), Quaternion.Euler(45, 0, 0), transform);

    }

    public virtual void TakeDamage(float damage)
    {

        damage -= defenceValue + extraDef;

        damage = Mathf.Clamp(damage, 0f, maxHP + extraHP);

        if (damage == 0)
        {

            //DoSom

        }

        currentHP -= damage;

        if(currentHP <= 0)
        {

            animator.SetDie();

        }

        OnValueChanged?.Invoke();

    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            TakeDamage(10);

        }

    }

    private void SettingValue(ItemType type, bool remove = false)
    {

        var item = itemContainer[type];

        if (!remove)
        {

            extraAttack += item.Value.attack;
            extraDef += item.Value.defense;
            extraHP += item.Value.hp;

        }
        else
        {

            extraAttack -= item.Value.attack;
            extraDef -= item.Value.defense;
            extraHP -= item.Value.hp;

        }

    }

    public bool EquipItem(ItemData item)
    {

        if (itemContainer.ContainsKey(item.type)) return false;

        itemContainer.Add(item.type, item);
        SettingValue(item.type);

        return true;

    }

    public bool ReleaseItem(ItemType type)
    {

        if (!itemContainer.ContainsKey(type)) return false;

        SettingValue(type, true);
        itemContainer.Remove(type);

        return true;

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
