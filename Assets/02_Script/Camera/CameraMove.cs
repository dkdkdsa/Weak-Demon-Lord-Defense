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
    private Vector2 clickPoint;

    public bool moveAble = true;

    private void Awake()
    {
        cam = Camera.main;
        vcam = GetComponent<CinemachineVirtualCamera>();
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
            //이걸 보고 있다면 배치 중 카메라가 움직여서 직접 뜯어 고칠려고 이 스크립트를 열었겠지 최대원,
            //아래의 주석을 풀면 된다고?(너가 배치메니저를 그대로 쓴다면야)
            //if (BatchManager.Instance.isDrag) return;

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

        if (vcam.m_Lens.OrthographicSize >= maxSize && scroll > 0) //최대 줌아웃
        {
            vcam.m_Lens.OrthographicSize = maxSize;
        }
        else if (vcam.m_Lens.OrthographicSize <= minSize && scroll < 0) //최대 줌인
        {
            vcam.m_Lens.OrthographicSize = minSize;
        }
        else
            vcam.m_Lens.OrthographicSize += scroll;
    }
}