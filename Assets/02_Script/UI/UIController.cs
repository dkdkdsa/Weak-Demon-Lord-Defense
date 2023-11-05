using Cinemachine;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    private CinemachineVirtualCamera cvcam;
    private EquipUI equipUI;

    public bool isControling { get; private set; }

    private void Awake()
    {

        cvcam = FindObjectOfType<CinemachineVirtualCamera>();
        equipUI = FindObjectOfType<EquipUI>();

    }


    public void StartControlUnit(Transform unitTrm)
    {

        if (isControling) return;

        cvcam.Follow = unitTrm;
        isControling = true;
        equipUI.SetControl(unitTrm.GetComponent<UnitDataController>());

        StartCoroutine(SetCamera(60, 15));

    }

    public void EndUnitControll()
    {

        if(!isControling) return;

        cvcam.Follow = null;
        isControling = false;

        StartCoroutine(SetCamera(15, 60));

    }

    private IEnumerator SetCamera(float start, float end)
    {

        float per = 0;
        while (per < 1)
        {

            per += Time.deltaTime * 3;

            cvcam.m_Lens.FieldOfView = Mathf.Lerp(start, end, FAED.Easing(FAED_Easing.OutQuad, per));

            yield return null;

        }

    }

}
