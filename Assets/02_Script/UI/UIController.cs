using Cinemachine;
using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] private Transform inventory, unitUpgrade, itemUpgrade, equip, hpPanel, deckPanel;

    private CinemachineVirtualCamera cvcam;
    private InventoryViewer inventoryViewer;
    private EquipUI equipUI;
    private UnitUpgradeUI unitUpgradeUI;
    private ItemUpgradeUI itemUpgradeUI;

    public bool isControling { get; private set; }

    private void Awake()
    {

        cvcam = FindObjectOfType<CinemachineVirtualCamera>();
        equipUI = FindObjectOfType<EquipUI>();
        inventoryViewer = FindObjectOfType<InventoryViewer>();
        unitUpgradeUI = FindObjectOfType<UnitUpgradeUI>();
        itemUpgradeUI = FindObjectOfType<ItemUpgradeUI>();

    }

    private void Start()
    {

        SetHpPanel(true);
        SetDeckPanel(true);
        WaveManager.instance.OnWaveStartEvent += HandleWaveStart;
        WaveManager.instance.OnWaveEndEvent += HandleWaveEnd;

    }

    private void SetInventroyPanel(bool open)
    {

        if (open)
        {

            inventory.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            inventory.DOLocalMoveY(1100, 0.3f).SetEase(Ease.OutQuad);

        }

    }

    private void SetUnitUgradePanel(bool open)
    {

        if (open)
        {

            unitUpgrade.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            unitUpgrade.DOLocalMoveY(1100, 0.3f).SetEase(Ease.OutQuad);

        }

    }

    private void SetItemUpgradePanel(bool open)
    {

        if (open)
        {

            itemUpgrade.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            itemUpgrade.DOLocalMoveY(1100, 0.3f).SetEase(Ease.OutQuad);

        }

    }

    private void SetEquipPanel(bool open)
    {

        if (open)
        {

            equip.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            equip.DOLocalMoveY(1100, 0.3f).SetEase(Ease.OutQuad);

        }

    }

    private void SetHpPanel(bool open)
    {

        if (open)
        {

            hpPanel.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            hpPanel.DOLocalMoveY(1100, 0.3f).SetEase(Ease.OutQuad);
                
        }

    }
    private void SetDeckPanel(bool open)
    {

        if (open)
        {

            deckPanel.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutQuad);

        }
        else
        {

            deckPanel.DOLocalMoveY(-1100, 0.3f).SetEase(Ease.OutQuad);

        }

    }

    private void HandleWaveStart()
    {

        SetHpPanel(false);
        SetDeckPanel(false);

    }

    private void HandleWaveEnd()
    {

        SetHpPanel(true);
        SetDeckPanel(true);

    }

    public void StartItemUpgradeControl()
    {

        if (isControling) return;
        isControling = true;

        SetHpPanel(false);
        SetInventroyPanel(true);
        SetItemUpgradePanel(true);

        inventoryViewer.SetItemUpgrade(itemUpgradeUI);

    }

    public void EndItemUpgradeControl()
    {

        if(!isControling) return;
        isControling = false;

        SetHpPanel(true);
        SetInventroyPanel(false);
        SetItemUpgradePanel(false);

        inventoryViewer.SetItemUpgrade(null);

    }

    public void StartControlUnit(Transform unitTrm)
    {

        if (isControling) return;

        cvcam.Follow = unitTrm;
        isControling = true;

        var control = unitTrm.GetComponent<UnitDataController>();

        equipUI.SetControl(control);
        unitUpgradeUI.SetController(control);
        inventoryViewer.SetEquip(equipUI);

        SetHpPanel(false);
        SetInventroyPanel(true);
        SetUnitUgradePanel(true);
        SetEquipPanel(true);

        StartCoroutine(SetCamera(60, 15));

    }

    public void EndUnitControll()
    {

        if(!isControling) return;

        cvcam.Follow = null;
        isControling = false;

        equipUI.SetControl(null);
        inventoryViewer.SetEquip(null);
        unitUpgradeUI.ReleaseControl();

        SetHpPanel(true);
        SetInventroyPanel(false);
        SetUnitUgradePanel(false);
        SetEquipPanel(false);

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
