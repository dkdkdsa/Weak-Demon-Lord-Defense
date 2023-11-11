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
    [SerializeField] private TMP_Text text;

    private ItemData? currentItem;

    public event Action<ItemData?> OnSlotClickEvent;
    public event Action<ItemData?> OnSlotEnterEvent;
    public event Action<ItemData?> OnSlotExitEvent;

    public void SettingItem(ItemData? item)
    {

        currentItem = item;

        if(currentItem == null)
        {

            spriteImage.color = new Color(0, 0, 0, 0);
            text.text = string.Empty;

        }
        else
        {

            spriteImage.color = Color.white;
            spriteImage.sprite = currentItem.Value.itemSprite;
            text.text = currentItem.Value.lv.ToString();

        }

    }

    public ItemData? GetItem()
    {

        return currentItem;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        DataTableShow.Instance.transform.position = new Vector3(3000, 3000);
        OnSlotClickEvent?.Invoke(currentItem);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        DataTableShow.Instance.transform.position = new Vector3(3000, 3000);
        OnSlotEnterEvent?.Invoke(currentItem);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if(currentItem != null)
        {
            
            DataTableShow.Instance.transform.position = eventData.position + new Vector2(0, 100);
            DataTableShow.Instance.SetText(currentItem.Value);

        }

        OnSlotExitEvent?.Invoke(currentItem);

    }
}
