using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedBackPlayer : MonoBehaviour
{

    [SerializeField] private string damageTextKey;
    [SerializeField] private string effectKey;

    private bool isShack;

    public void PlayFeedback(float damage)
    {


        SetText(damage);
        Shack();
        SetParticle();


    }

    private void SetText(float damage)
    {

        var txtObj = FAED.TakePool<TMP_Text>(damageTextKey,
            transform.position + Random.insideUnitSphere,
            Quaternion.Euler(45, 0, 0));

        if (damage == -1)
        {

            txtObj.text = "¹æ¾î!";

        }
        else
        {

            txtObj.text = damage.ToString();

        }

        txtObj.transform
            .DOMoveY(txtObj.transform.position.y + 3, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => Destroy(txtObj));

    }
    private void SetParticle()
    {

        var ptcObj = FAED.TakePool<ParticleSystem>(effectKey,
            transform.position + Random.insideUnitSphere,
            Quaternion.identity);

        ptcObj.Play();

        FAED.InvokeDelay(() =>
        {

            FAED.InsertPool(ptcObj.gameObject);

        }, 3f);

    }
    private void Shack()
    {

        if (isShack) return;
        isShack = true;

        transform.DOShakePosition(0.3f).OnComplete(() => isShack = false);

    }

}
