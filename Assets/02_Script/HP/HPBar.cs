using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{

    [SerializeField] private Transform barRootTrm;

    private UnitDataController dataController;

    private void Start()
    {
        
        dataController = transform.root.GetComponent<UnitDataController>();
        dataController.OnValueChanged += HandleValueChanged;

    }

    private void OnDestroy()
    {
        
        if(dataController != null)
        {

            dataController.OnValueChanged -= HandleValueChanged;

        }

    }

    private void HandleValueChanged()
    {


        float value = dataController.currentHP / dataController.maxHP;

        if (value < 0 ) value = 0;

        barRootTrm.localScale = new Vector3(value, 1, 1);

    }

}
