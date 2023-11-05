using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int money;

    public event Action OnValueChanged;

}
