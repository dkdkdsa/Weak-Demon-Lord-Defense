using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{

    [SerializeField] private Sprite weaponSprite;
    [SerializeField] public ItemType type;
    [SerializeField] private float defense;
    [SerializeField] private float attack;
    [SerializeField] private float hp;
    [SerializeField] private string itemName;
    [SerializeField] private int upgradeCost;

    public ItemData CreateItemData()
    {

        return new ItemData(weaponSprite, type, itemName, defense, attack, hp, upgradeCost);

    }

}
