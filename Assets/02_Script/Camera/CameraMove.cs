using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Transform player;

    [Header("Value")]
    [SerializeField] private float dragSpeed = 30.0f;
    [SerializeField] private float wheelSpeed = 30.0f;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;

    private Camera cam;
    private CinemachineVirtualCamera vcam;
    private PlayDeckManager deckManager;
    private Vector2 clickPoint;

    public bool moveAble = true;

    private void Awake()
    {
        cam = Camera.main;
        vcam = GetComponent<CinemachineVirtualCamera>();
        deckManager = FindObjectOfType<PlayDeckManager>();
    }

    private void Update()
    {
        CamMove();
        //CamScaling();
    }

    void CamMove()
    {
        if (!moveAble) return;

        if (Input.GetMouseButtonDown(0))
        {
            clickPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (deckManager.settingStart) return;

            Vector3 position
                    = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

            Vector3 move = -position * (Time.deltaTime * dragSpeed);
            move.z = move.y;
            move.y = 0;

            player.Translate(move);

        }
    }

    void CamScaling()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * -wheelSpeed;

        if (vcam.m_Lens.OrthographicSize >= maxSize && scroll > 0) //√÷¥Î ¡‹æ∆øÙ
        {
            vcam.m_Lens.OrthographicSize = maxSize;
        }
        else if (vcam.m_Lens.OrthographicSize <= minSize && scroll < 0) //√÷¥Î ¡‹¿Œ
        {
            vcam.m_Lens.OrthographicSize = minSize;
        }
        else
            vcam.m_Lens.OrthographicSize += scroll;
    }
}