using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class RankingUI : MonoBehaviour
{

    [SerializeField] private TMP_Text t1, t2, t3;

    private void Start()
    {

        Refrech();

    }

    public async void Refrech()
    {

        var arr = await AuthManager.instance.GetAllValue();

        if (arr == null) return;

        try
        {

            var sarr = arr.OrderByDescending(x =>
            {

                if(x["maxWave"] != null && x["time"] != null)
                {

                    return int.Parse(x["maxWave"].ToString());

                }
                else
                {

                    return -1;

                }

            });
            

            int cnt = 0;

            foreach (var itme in sarr)
            {

                int t = (int.Parse(itme["time"].ToString()) % 3600);

                if (cnt == 0) t1.text = $"1위 {itme["userName"]} : {itme["maxWave"]} 걸린시간" +
                        $" {t / 60}:{t % 60}";
                if (cnt == 1) t2.text = $"2위 {itme["userName"]} : {itme["maxWave"]} 걸린시간" +
                        $" {t / 60}:{t % 60}";
                if (cnt == 2) t3.text = $"3위 {itme["userName"]} : {itme["maxWave"]} 걸린시간" +
                        $" {t / 60}:{t % 60}";

                cnt++;

                if (cnt == 3) break;

            }

        }
        catch(System.Exception ex)
        {

            foreach(var item in arr)
            {

                Debug.Log(ex.ToString());
                Debug.Log(item["maxWave"]);

            }

            t1.text = "서버에 데이터 동기화중";
            t2.text = "잠시후 다시 시도해주세요";
            t3.text = "";

        }



    }

}
