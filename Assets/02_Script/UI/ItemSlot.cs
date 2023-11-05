using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{

    [SerializeField] private Image spriteImage;

    private ItemData? currentItem;

    public void SettingItem(ItemData? item)
    {

        currentItem = item;

        if(currentItem == null)
        {

            spriteImage.color = new Color(0, 0, 0, 0);

        }
        else
        {

            spriteImage.color = Color.white;
            spriteImage.sprite = currentItem.Value.itemSprite;

        }

    }

    public ItemData? GetItem()
    {

        return currentItem;

    }

}
