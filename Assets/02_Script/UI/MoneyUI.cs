using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        playerData.OnValueChanged += MoneyUIText;
    }

    private void MoneyUIText()
    {
        moneyText.text = $"Money : {playerData.Money}";
    }
}
