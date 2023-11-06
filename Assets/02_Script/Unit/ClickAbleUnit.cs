using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAbleUnit : MonoBehaviour
{
    private UIController controller;

    private void Awake()
    {
        
        controller = FindObjectOfType<UIController>();

    }

    private void OnMouseDown()
    {

        controller.StartControlUnit(transform);

    }



}
