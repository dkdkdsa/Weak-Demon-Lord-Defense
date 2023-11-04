using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{

    protected UnitDataController dataController;
    protected Transform visualTrm;

    protected virtual void Awake()
    {

        dataController = GetComponent<UnitDataController>();
        visualTrm = transform.Find("Visual");

    }

}
