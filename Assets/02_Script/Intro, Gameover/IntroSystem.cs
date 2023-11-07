using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
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

    [Header("Login")]
    [SerializeField] private Transform singUp;
    [SerializeField] private Transform login;
    [SerializeField] private Transform ranking;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject btnss;

    const float title_1Ypos = 270f + 540f;
    const float title_2Xpos = 960f;
    const float btnsYpos = 540f;

    private SingUpUI singUpUI;
    private LoginUI loginUI;

    private void Awake()
    {
        
        singUpUI = GetComponent<SingUpUI>();
        loginUI = GetComponent<LoginUI>();

        if(AuthManager.instance.userData.userName != null)
        {

            nameText.text = AuthManager.instance.userData.userName;
            btnss.SetActive(false);

        }

    }

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

    public void LoginPanel(bool open)
    {

        if (open)
        {

            login.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuad);

        }
        else
        {

            login.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.OutQuad);

        }

    }

    public void SignUpPanel(bool open)
    {

        if (open)
        {

            singUp.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuad);

        }
        else
        {

            singUp.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.OutQuad);

        }

    }

    public void RankingPanel(bool open)
    {

        if (open)
        {

            ranking.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuad);

        }
        else
        {

            ranking.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.OutQuad);

        }

    }

    public void IntroPanel(bool open)
    {

        if (open)
        {

            introPanel.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutQuad);

        }
        else
        {

            introPanel.transform.DOLocalMoveY(-1100, 0.5f).SetEase(Ease.OutQuad);

        }

    }

    public void SignUp()
    {

        singUpUI.SingUp((x) =>
        {

            if(x == true)
            {

                btnss.gameObject.SetActive(false);
                SignUpPanel(false);
                InStagePanel();
                nameText.text = AuthManager.instance.userData.userName;

            }

        });

    }

    public void Login()
    {

        loginUI.Login((x) =>
        {

            if (x == true)
            {

                btnss.gameObject.SetActive(false);
                LoginPanel(false);
                InStagePanel();
                nameText.text = AuthManager.instance.userData.userName;

            }

        });

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
