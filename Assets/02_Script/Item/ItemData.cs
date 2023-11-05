using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public struct ItemData
{

    public ItemData(Sprite itemSprite, ItemType type, string itemName, float defense, float attack, float hp, int upgradeCost)
    {

        this.itemSprite = itemSprite;
        this.type = type;
        this.itemName = itemName;
        this.defense = defense;
        this.attack = attack;
        this.hp = hp;
        this.upgradeCost = upgradeCost;
        lv = 1;

        guid = Guid.NewGuid();

    }

    public Sprite itemSprite { get; private set; }
    public ItemType type { get; private set; }
    public string itemName { get; private set; }
    public float defense { get; private set; }
    public float attack { get; private set; }
    public float hp { get; private set; }
    public int lv { get; private set; }
    public int upgradeCost { get; private set; }
    public Guid guid { get; private set; }

    public void DoUpgrade()
    {

        lv++;

        hp += lv * 5;
        attack += lv * 2;
        upgradeCost += lv * 3;
        defense += lv * 1.5f;

    }

}
