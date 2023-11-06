using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingUpUI : MonoBehaviour
{

    [SerializeField] private TMP_InputField email, password, userName;

    public void SingUp()
    {

        AuthManager.instance.SingUp(email.text, password.text, userName.text);

    }

}
