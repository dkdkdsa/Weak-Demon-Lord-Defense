using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckStrSlot : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private Image icon;

    private Transform deckRoot, cardRoot;
    private bool isDeck = false;

    public string key;

    public void Setting(string key, Sprite sprite, Transform deckRoot, Transform cardRoot)
    {

        icon.sprite = sprite;
        this.key = key;
        this.deckRoot = deckRoot;
        this.cardRoot = cardRoot;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (isDeck)
        {

            isDeck = false;
            transform.SetParent(cardRoot);

        }
        else
        {

            if (deckRoot.childCount >= 5) return;

            isDeck = true;
            transform.SetParent(deckRoot);

        }

    }

}
