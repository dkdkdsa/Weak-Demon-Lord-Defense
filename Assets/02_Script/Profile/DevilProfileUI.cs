using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DevilProfileUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image profileImage;
    [SerializeField] private TextMeshProUGUI waveClearText;
    [SerializeField] private GameObject redScreen;

    [Header("Sprite")]
    [SerializeField] private Sprite orgSprite;
    [SerializeField] private Sprite winSprite;
    [SerializeField] private Sprite loseSprite;

    const float profileTime = 5f;
    const float textTime = 0.5f;

    private void Start()
    {
        WaveManager.instance.OnWaveCompleteEvent += WinActive;
        WaveManager.instance.OnWaveFailureEvent += LoseActive;
    }

    private void LoseActive()
    {
        profileImage.sprite = loseSprite;

        waveClearText.gameObject.SetActive(true);
        waveClearText.rectTransform.position = new Vector3(960, 1140, 0);
        waveClearText.rectTransform.DOMoveY(540, 0.3f).SetEase(Ease.OutBounce);
        waveClearText.text = "웨이브 실패";

        StartCoroutine(ChangeProfile());
        StartCoroutine(DownText());
        StartCoroutine(RedScreenUp());
    }

    private void WinActive()
    {
        profileImage.sprite = winSprite;

        waveClearText.gameObject.SetActive(true);
        waveClearText.rectTransform.position = new Vector3(960, 1140, 0);
        waveClearText.rectTransform.DOMoveY(540, 0.3f).SetEase(Ease.OutBounce);
        waveClearText.text = "웨이브 성공";

        StartCoroutine(ChangeProfile());
        StartCoroutine(DownText());
    }

    IEnumerator ChangeProfile()
    {
        yield return new WaitForSeconds(profileTime);
        profileImage.sprite = orgSprite;
    }

    IEnumerator DownText()
    {
        yield return new WaitForSeconds(textTime);
        waveClearText.gameObject.SetActive(false);
    }

    IEnumerator RedScreenUp()
    {
        redScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        redScreen.SetActive(false);
    }
}
