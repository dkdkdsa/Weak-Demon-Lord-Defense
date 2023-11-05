using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeckManager : MonoBehaviour
{

    [SerializeField] private GameObject setPosGreen;
    [SerializeField] private Grid grid;

    private Vector3 setPos;
    private GameObject currentPrefab;
    public bool settingStart { get; private set; }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            ReleaseSetting();

        }

        if (settingStart)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Ground")))
            {

                var pos = grid.WorldToCell(hit.point);
                setPos= pos;
                setPosGreen.transform.position = pos;

            }

        }

    }

    public void StartSetting(GameObject prefab)
    {


        setPosGreen.SetActive(true);
        currentPrefab = prefab;
        settingStart = true;

    }

    public void ReleaseSetting()
    {

        if (settingStart == false) return;

        setPosGreen.SetActive(false);
        Instantiate(currentPrefab, setPos, Quaternion.identity);
        settingStart = false;
        currentPrefab = null;

    }

}
