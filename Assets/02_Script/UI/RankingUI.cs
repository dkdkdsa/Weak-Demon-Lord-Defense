using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RankingUI : MonoBehaviour
{

    [SerializeField] private TMP_Text t1, t2, t3;

    private async void Start()
    {

        var arr = await AuthManager.instance.GetAllValue();

        if (arr == null) return;

        var sarr = arr.OrderByDescending(x => int.Parse(x["maxWave"].ToString()));

        int cnt = 0;

        foreach(var itme in sarr)
        {


            if (cnt == 0) t1.text = $"{itme["userName"]} : {itme["maxWave"]}";
            if (cnt == 1) t2.text = $"{itme["userName"]} : {itme["maxWave"]}";
            if (cnt == 2) t3.text = $"{itme["userName"]} : {itme["maxWave"]}";

            cnt++;

            if (cnt == 3) break;

        }



    }

}
