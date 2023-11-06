using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingUpUI : MonoBehaviour
{

    [SerializeField] private TMP_InputField email, password, userName;
    [SerializeField] private TMP_Text failSibal;

    public void SingUp(Action<bool> compAction)
    {

        AuthManager.instance.SingUp(email.text, password.text, userName.text,(x) =>
        {

            compAction?.Invoke(x);

            if(x == false)
            {

                failSibal.text = "회원가입 실패";

                FAED.InvokeDelay(() =>
                {

                    failSibal.text = "";

                }, 1.5f);

            }

        });

    }

}
