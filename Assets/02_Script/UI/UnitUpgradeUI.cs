using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UnitUpgradeUI : MonoBehaviour
{

    [SerializeField] private TMP_Text lvText, attackText, defText, hpText, contText, nameText;

    private UnitDataController dataController;
    private PlayerData playerData;

    private void Awake()
    {
        
        playerData = FindObjectOfType<PlayerData>();

    }

    public void SetController(UnitDataController controller)
    {

        dataController = controller;
        dataController.OnValueChanged += HandleValueChanged;
        HandleValueChanged();

    }

    public void ReleaseControl()
    {

        dataController.OnValueChanged -= HandleValueChanged;
        dataController = null;

    }

    private void HandleValueChanged()
    {

        nameText.text = dataController.unitName;
        lvText.text = $"레벨 : {dataController.lv}";
        attackText.text = $"공격력 : {dataController.attackPower + dataController.extraAttack}";
        defText.text = $"방어력 : {dataController.defenceValue + dataController.extraDef}";
        hpText.text = $"체력 : {dataController.maxHP + dataController.extraHP}";
        contText.text = $"비용 {dataController.lvUpCost}";

    }

    public void DoUpgrade()
    {

        if(playerData.Money >= dataController.lvUpCost)
        {

            playerData.Money -= (int)dataController.lvUpCost;

            dataController.LvUp();

        }

    }

}
