using DG.Tweening;
using FD.Dev;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class EnemySpawnData
{

    public UnitDataController enemy;
    public int spawnCount;

}

[Serializable]
public class WaveData
{

    [Header("����")]
    public List<EnemySpawnData> enemys;

    [Space]
    [Space]
    public float spawnDelay;

}

public class WaveManager : MonoBehaviour
{

    [SerializeField] private List<WaveData> waves = new();
    [SerializeField] private List<Transform> summonPos = new();
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private Slider barTrm;
    [SerializeField] private float barHP = 50;
    [SerializeField] private int[] waveRewardMoney;

    private int turretCnt;
    private float time;

    public event Action OnWaveFailureEvent;
    public event Action OnWaveDieEvent;
    public event Action OnWaveStartEvent;
    public event Action OnWaveEndEvent;
    public event Action OnWaveCompleteEvent;

    public int TurretCnt
    {

        get { return turretCnt; }
        set
        {

            turretCnt = value;
            if (turretCnt == 0)
            {

                StopAllCoroutines();

                if (currentWave - 1 == -1) currentWave = waves.Count - 1;
                else currentWave--;
                addWave--;
                waveText.text = $"WAVE {addWave}";
                barHP -= 10;
                barTrm.value = barHP;

                if (barHP <= 0)
                {

                    OnWaveDieEvent?.Invoke();

                    if(AuthManager.instance.userData.userName != null)
                    {

                        if(AuthManager.instance.userData.maxWave < addWave)
                        {

                            AuthManager.instance.userData.maxWave = addWave;
                            AuthManager.instance.userData.time = (int)time;
                            AuthManager.instance.Setting();

                        }

                    }

                    SceneManager.LoadScene("Gameover");
                    return;

                }

                FAED.InvokeDelay(() =>
                {

                    OnWaveEndEvent?.Invoke();
                    barTrm.transform.DOShakePosition(0.2f, 0.3f);


                    foreach (var item in spawnList)
                    {

                        Destroy(item.gameObject);

                    }

                    spawnList.Clear();

                }, 0.3f);

                totalCount = 0;

                SoundManager.Instance.PlaySound("WaveLose");

                OnWaveFailureEvent?.Invoke();

            }

        }

    }

    [HideInInspector] public bool isWaving;
    private int currentWave = 0;
    private int addWave = 1;
    private int enemyAddValue = 1;
    private int spawnAddValue = 1;
    private int totalCount;

    [HideInInspector] public List<GameObject> spawnList = new List<GameObject>();
    public static WaveManager instance;

    private PlayerData playerData;

    private void Awake()
    {

        instance = this;
        playerData = FindObjectOfType<PlayerData>();

        waveText.text = $"WAVE {addWave}";
        OnWaveEndEvent += WaveEndBool;

    }

    private void Update()
    {

        time += Time.deltaTime;

    }

    public void StartWave()
    {

        var wave = waves[currentWave++];

        isWaving = true;
        addWave++;
        waveText.text = $"WAVE {addWave}";

        OnWaveStartEvent?.Invoke();
        StartCoroutine(EnemySummonCo(wave));
        TurretCnt = turretCnt;

    }

    public void EndWave()
    {

        if (currentWave == waves.Count)
        {

            enemyAddValue++;
            spawnAddValue++;

            currentWave = 0;

        }

        OnWaveEndEvent?.Invoke();
        OnWaveCompleteEvent?.Invoke();
        playerData.Money += RewardMoney();

    }

    private int RewardMoney()
    {
        if (currentWave >= waveRewardMoney.Length)
        {
            int c = (currentWave - waveRewardMoney.Length / 10) + 1;
            return waveRewardMoney[waveRewardMoney.Length - 1] * c;
        }

        return waveRewardMoney[currentWave];
    }

    private IEnumerator EnemySummonCo(WaveData data)
    {

        data.enemys.ForEach(x => totalCount += x.spawnCount * spawnAddValue);

        foreach (var pref in data.enemys)
        {

            StartCoroutine(SummonCo(pref, data.spawnDelay));

        }

        yield return new WaitUntil(() =>
        {

            return totalCount == 0;

        });

        totalCount = 0;

        yield return new WaitUntil(() =>
        {

            return spawnList.Count == 0;

        });

        EndWave();

    }

    void WaveEndBool()
        => isWaving = false;

    private IEnumerator SummonCo(EnemySpawnData data, float delay)
    {

        for (int i = 0; i < data.spawnCount * spawnAddValue; i++)
        {

            int r = Random.Range(0, summonPos.Count);

            Transform trm = summonPos[r];

            var pos = trm.position + (Random.insideUnitSphere * 2);
            pos.y = 0;

            var obj = Instantiate(data.enemy, pos, Quaternion.identity);

            for(int j = 0; j < enemyAddValue; j++)
            {

                obj.LvUp();

            }

            spawnList.Add(obj.gameObject);

            totalCount--;
            yield return new WaitForSeconds(delay);

        }

    }

}
