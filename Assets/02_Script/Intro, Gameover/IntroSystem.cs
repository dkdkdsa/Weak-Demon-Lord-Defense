using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSystem : MonoBehaviour
{
    [Header("Camrea")]
    [SerializeField] private Transform camTrs;

    [Header("IntroPanel")]
    [SerializeField] private RectTransform introPanel;
    [SerializeField] private RectTransform title_1;
    [SerializeField] private RectTransform title_2;
    [SerializeField] private RectTransform btns;

    [Header("StagePanel")]
    [SerializeField] private RectTransform stagePanel;

    const float title_1Ypos = 270f + 540f;
    const float title_2Xpos = 960f;
    const float btnsYpos = 540f;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(title_1.DOMoveY(title_1Ypos, 0.7f).SetEase(Ease.OutCubic));
        sequence.Join(btns.DOMoveY(btnsYpos, 0.5f).SetEase(Ease.OutBounce));
        sequence.Append(title_2.DOMoveX(title_2Xpos, 0.5f).SetEase(Ease.OutExpo));
    }

    public void OutStagePanel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(introPanel.DOMoveY(1100 + 540, 0.5f).SetEase(Ease.InExpo));
        sequence.Append(camTrs.DORotate(new Vector3(90, 0, 0), 0.5f).SetEase(Ease.OutCirc));
        sequence.Join(camTrs.DOMoveZ(0, 0.5f).SetEase(Ease.OutCirc));
        sequence.Append(stagePanel.DOMoveY(540, 0.5f).SetEase(Ease.OutExpo));
    }

    public void InStagePanel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(stagePanel.DOMoveY(1100 + 540, 0.5f).SetEase(Ease.InExpo));
        sequence.Append(camTrs.DORotate(new Vector3(45, 0, 0), 0.5f).SetEase(Ease.OutCirc));
        sequence.Join(camTrs.DOMoveZ(-10, 0.5f).SetEase(Ease.OutCirc));
        sequence.Append(introPanel.DOMoveY(540, 0.5f).SetEase(Ease.OutExpo));
    }

    public void NextScene(string name)
    {
        SoundManager.Instance.PlaySound("Button");
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
