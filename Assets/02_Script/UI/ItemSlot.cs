using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private Image spriteImage;

    private ItemData? currentItem;

    public event Action OnSlotClickEvent;
    public event Action OnSlotEnterEvent;
    public event Action OnSlotExitEvent;

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

    public void OnPointerDown(PointerEventData eventData)
    {

        OnSlotClickEvent?.Invoke();

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        OnSlotEnterEvent?.Invoke();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        OnSlotExitEvent?.Invoke();

    }
}
