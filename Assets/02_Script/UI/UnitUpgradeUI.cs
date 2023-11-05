using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitUpgradeUI : MonoBehaviour
{

    [SerializeField] private TMP_Text lvText, attackText, defText, hpText, contText;

    private UnitDataController dataController;

    public void SetController(UnitDataController controller)
    {

        dataController = controller;
        dataController.OnValueChanged += HandleValueChanged;
        HandleValueChanged();

    }

    private void HandleValueChanged()
    {

        lvText.text = $"레벨 : {dataController.lv}";
        attackText.text = $"공격력 : {dataController.attackPower + dataController.extraAttack}";
        defText.text = $"방어력 : {dataController.defenceValue + dataController.extraDef}";
        hpText.text = $"체력 : {dataController.maxHP + dataController.extraHP}";
        contText.text = $"비용 {dataController.lvUpCost}";

    }

    public void DoUpgrade()
    {



    }

}
