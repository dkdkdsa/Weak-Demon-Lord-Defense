using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSystem : MonoBehaviour
{
    [SerializeField] private RectTransform titleTrs;
    [SerializeField] private RectTransform btnsTrs;
    [SerializeField] private Image rend;

    private void Start()
    {

        StartCoroutine(CO());

    }

    private IEnumerator CO()
    {

        float per = 0;

        while(per < 1)
        {

            per += Time.deltaTime;
            rend.material.SetFloat("_FullGlowDissolveFade", 1 - per);
            yield return null;

        }

        StartTw();

    }

    private void StartTw()
    {

        SoundManager.Instance.PlaySound("Gameover");

        titleTrs.DOMoveY(800, 0.3f).SetEase(Ease.InExpo).OnComplete(() => {
            titleTrs.DORotate(new Vector3(0, 0, 180), 0.3f).SetEase(Ease.InCirc).OnComplete(() => {
                titleTrs.DORotate(new Vector3(0, 0, 360), 0.3f).SetEase(Ease.OutCirc);
            });
            titleTrs.DOScale(new Vector3(2, 2, 2), 0.3f).SetEase(Ease.OutCubic).OnComplete(() => {
                titleTrs.DOScale(new Vector3(1, 1, 1), 0.3f).SetEase(Ease.InCubic);
            });
        });

        btnsTrs.DOMoveY(540, 0.5f).SetEase(Ease.OutBounce);

    }

    public void NextScene(string name)
    {
        //SoundManager.Instance.PlaySound("Button");
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
