using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckSlot : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private Image iconSprite;
    [SerializeField] private GameObject debugPrefab;
    [SerializeField] private int dabugCost = -1;
    [SerializeField] private TMP_Text costText;

    private GameObject currentPrefab;
    private PlayDeckManager deckManager;
    private PlayerData playerData;
    private int currentCost;

    private void Awake()
    {
        
        if(dabugCost != -1)
        {

            currentCost = dabugCost;
            costText.text = currentCost.ToString();

        }

        if(debugPrefab != null)
        {

            currentPrefab = debugPrefab;

        }

        deckManager = FindObjectOfType<PlayDeckManager>();
        playerData = FindObjectOfType<PlayerData>();

    }

    public void Setting(Sprite sprite, int cost, GameObject prefab)
    {

        iconSprite.sprite = sprite;
        currentCost = cost;
        costText.text = cost.ToString();
        currentPrefab = prefab;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (deckManager.settingStart) return;
        if (playerData.Money < currentCost) return;

        playerData.Money -= currentCost;
        deckManager.StartSetting(currentPrefab);

    }

}
