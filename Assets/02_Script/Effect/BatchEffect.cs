using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchEffect : MonoBehaviour
{
    public IEnumerator EffectPush(float time)
    {
        yield return new WaitForSeconds(time);
        //나중에 풀링으로 교체할까봐 만들어둠
        Destroy(gameObject);
    }
}
