using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitDie : MonoBehaviour
{

    private UnitAnimator animator;

    private void Awake()
    {

        animator = GetComponentInChildren<UnitAnimator>();
        animator.OnDieAnimeEnd += HandleDie;

    }

    private void HandleDie()
    {

        WaveManager.instance.TurretCnt--;

    }

}
