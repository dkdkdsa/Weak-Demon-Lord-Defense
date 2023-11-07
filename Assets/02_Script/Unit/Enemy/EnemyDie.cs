using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    [SerializeField] private EnemyDropTableSO so;
    [SerializeField] private int rewardMoney;

    private PlayerData playerData;
    private UnitAnimator animator;

    private void Awake()
    {
     
        playerData = FindObjectOfType<PlayerData>();
        animator = GetComponentInChildren<UnitAnimator>();
        animator.OnDieAnimeEnd += HandleDie;

    }

    private void HandleDie()
    {

        if(Random.value > 0.7f)
        {

            var val = Random.Range(0, so.dropItems.Count);

            Instantiate(so.dropItems[val], transform.position, Quaternion.identity);

        }

        playerData.Money += rewardMoney;
        WaveManager.instance.spawnList.Remove(gameObject);

    }
}
