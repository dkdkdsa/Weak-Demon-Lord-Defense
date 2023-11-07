using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataTableShow : MonoBehaviour
{

    [SerializeField] private TMP_Text attackText, defText, hpText, nameText;
    [SerializeField] private Image spriteSlot;

    public static DataTableShow Instance;

    private void Awake()
    {

        Instance = this;

    }

    public void SetText(ItemData item)
    {

        attackText.text = $"공격력 : {item.attack}";
        defText.text = $"방어력 : {item.defense}";
        nameText.text = $"이름 : {item.itemName}";
        spriteSlot.sprite = item.itemSprite;
        hpText.text = $"체력 : {item.hp}";

    }

}

