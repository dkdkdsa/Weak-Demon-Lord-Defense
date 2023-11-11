using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    
    public int Money
    {

        get
        {

            return money;

        }

        set
        {

            money = value;
            OnValueChanged?.Invoke();

        }

    }

    [SerializeField] private int money;

    public event Action OnValueChanged;

    private void Start()
    {
        OnValueChanged?.Invoke();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Intro");

        }

    }

}
