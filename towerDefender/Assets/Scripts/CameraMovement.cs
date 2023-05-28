using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    float orthoGraphicSize;
    float targetOrthographicSize;
    private void Start()
    {
        orthoGraphicSize = virtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthoGraphicSize;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 20;

        targetOrthographicSize += Input.mouseScrollDelta.y * 2;

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, 10, 30);

        orthoGraphicSize = Mathf.Lerp(orthoGraphicSize , targetOrthographicSize , Time.deltaTime * 5);

        virtualCamera.m_Lens.OrthographicSize = orthoGraphicSize;

    }
}
