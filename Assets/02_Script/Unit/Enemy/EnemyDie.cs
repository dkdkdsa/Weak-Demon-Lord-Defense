using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    [SerializeField] private EnemyDropTableSO so;

    private UnitAnimator animator;

    private void Awake()
    {
        
        animator = GetComponentInChildren<UnitAnimator>();
        animator.OnDieAnimeEnd += HandleDie;

    }

    private void HandleDie()
    {

        if(Random.value > 0.3f)
        {

            var val = Random.Range(0, so.dropItems.Count);

            Instantiate(so.dropItems[val], transform.position, Quaternion.identity);

        }

        WaveManager.instance.spawnList.Remove(gameObject);

    }
}
