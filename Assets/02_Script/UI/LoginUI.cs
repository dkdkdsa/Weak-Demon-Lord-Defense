using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginUI : MonoBehaviour
{

    [SerializeField] private TMP_InputField emailField, passwordField;
    [SerializeField] private TMP_Text filaSibal;

    public void Login(Action<bool> compAction)
    {

        AuthManager.instance.Login(emailField.text, passwordField.text, (x) =>
        {

            compAction?.Invoke(x);

            if (x == false)
            {

                filaSibal.text = "로그인 실패";

                FAED.InvokeDelay(() =>
                {

                    filaSibal.text = "";

                }, 1.5f);

            }

        });

    }

}
