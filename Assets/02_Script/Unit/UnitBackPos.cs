using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBackPos : MonoBehaviour
{
    private UnitAnimator animator;
    private Vector3 orgPos;

    private void Awake()
    {
        animator = GetComponentInChildren<UnitAnimator>();
        animator.OnDieAnimeEnd += BackOrgPosClose;

        orgPos = transform.position;
        WaveManager.instance.OnWaveEndEvent += BackOrgPos;
    }

    private void BackOrgPos()
    {
        transform.position = orgPos;
    }

    private void BackOrgPosClose()
    {
        WaveManager.instance.OnWaveEndEvent -= BackOrgPos;
    }
}
