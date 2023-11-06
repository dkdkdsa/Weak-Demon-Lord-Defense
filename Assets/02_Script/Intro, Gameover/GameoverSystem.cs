using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverSystem : MonoBehaviour
{
    [SerializeField] private RectTransform titleTrs;
    [SerializeField] private RectTransform btnsTrs;

    private void Start()
    {
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
