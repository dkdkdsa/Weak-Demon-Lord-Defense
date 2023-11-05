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
    [field: SerializeField] public float lvUpValue { get; protected set; }
    [field: SerializeField] public float lvUpCost { get; protected set; }
    [field: SerializeField] public string unitName { get; protected set; }

    [field: Space]
    [field: Header("AI")]
    [field: SerializeField] public float range { get; protected set; }
    [field: SerializeField] public float attackAbleRange { get; protected set; }

    protected UnitAnimator animator;
    protected HPBar hpBar;
    protected Dictionary<ItemType, ItemData?> itemContainer = new();
    protected SpriteRenderer head, body, pants1, pants2, weapon;


    public event Action OnValueChanged;

    public int lv { get; protected set; } = 1;
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
        head = transform.Find("Visual/UnitRoot/Root/BodySet/P_Body/HeadSet/P_Head/P_Helmet/11_Helmet1").GetComponent<SpriteRenderer>();
        body = transform.Find("Visual/UnitRoot/Root/BodySet/P_Body/Body/P_ArmorBody/BodyArmor").GetComponent<SpriteRenderer>();
        pants1 = transform.Find("Visual/UnitRoot/Root/P_LFoot/P_LCloth/_2L_Cloth").GetComponent<SpriteRenderer>();
        pants2 = transform.Find("Visual/UnitRoot/Root/P_RFoot/P_RCloth/_11R_Cloth").GetComponent<SpriteRenderer>();
        weapon = transform.Find("Visual/UnitRoot/Root/BodySet/P_Body/ArmSet/ArmL/P_LArm/P_Weapon/L_Weapon").GetComponent<SpriteRenderer>();

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

        currentHP = maxHP + extraHP;

        OnValueChanged?.Invoke();

    }

    private void SettingItemSpriet(Sprite sprite, ItemType type)
    {

        switch (type)
        {

            case ItemType.Body:
                body.sprite = sprite;
                break;
            case ItemType.Head:
                head.sprite = sprite;
                break;
            case ItemType.Pants:
                pants1.sprite = sprite;
                pants2.sprite = sprite;
                break;
            case ItemType.Weapon:
                weapon.sprite = sprite;
                break;

        }

    }

    public bool EquipItem(ItemData item)
    {

        if (itemContainer.ContainsKey(item.type)) return false;

        itemContainer.Add(item.type, item);
        SettingValue(item.type);
        SettingItemSpriet(item.itemSprite, item.type);

        return true;

    }

    public bool ReleaseItem(ItemType type)
    {

        if (!itemContainer.ContainsKey(type)) return false;

        SettingItemSpriet(null, type);
        SettingValue(type, true);
        itemContainer.Remove(type);

        return true;

    }

    public ItemData? GetItem(ItemType type)
    {

        if (itemContainer.ContainsKey(type))
        {

            return itemContainer[type];

        }

        return null;

    }

    public void LvUp()
    {

        lv++;

        extraHP += lvUpValue;
        extraAttack += lvUpValue / 5;
        extraDef += lvUpValue / 10;
        lvUpCost += lvUpValue * 2;

        currentHP = maxHP + extraHP;

        OnValueChanged?.Invoke();

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
