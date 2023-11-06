using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(UnitDataController))]
[RequireComponent(typeof(UnitController))]
[RequireComponent(typeof(FeedBackPlayer))]
public class UnitBase : MonoBehaviour
{

    protected UnitDataController dataController;
    protected Transform visualTrm;
    protected NavMeshAgent agent;

    protected virtual void Awake()
    {

        dataController = GetComponent<UnitDataController>();
        visualTrm = transform.Find("Visual");

    }

}
