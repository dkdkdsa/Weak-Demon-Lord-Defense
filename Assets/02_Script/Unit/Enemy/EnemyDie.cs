using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    private UnitAnimator animator;

    private void Awake()
    {
        
        animator = GetComponentInChildren<UnitAnimator>();
        animator.OnDieAnimeEnd += HandleDie;

    }

    private void HandleDie()
    {

        WaveManager.instance.spawnList.Remove(gameObject);

    }
}
