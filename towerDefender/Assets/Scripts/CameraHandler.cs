using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachine;
    float orthograohicSize;
    float targetOrthograohicSize;
    // Start is called before the first frame update
    void Start()
    {
        orthograohicSize = cinemachine.m_Lens.OrthographicSize;
        targetOrthograohicSize = orthograohicSize;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandler();

        ZoomHandler();
    }
    void MoveHandler()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveSpeed = 30;
        transform.position += new Vector3(x, y, 0).normalized * moveSpeed * Time.deltaTime;
    }
    void ZoomHandler()
    {
        float zoomAmount = 2;
        targetOrthograohicSize += Input.mouseScrollDelta.y * zoomAmount;

        float maxSize = 30;
        float MinSize = 10;

        targetOrthograohicSize = Mathf.Clamp(targetOrthograohicSize, MinSize, maxSize);

        float zoomSpeed = 5f;
        orthograohicSize = Mathf.Lerp(orthograohicSize, targetOrthograohicSize, Time.deltaTime * zoomSpeed);
    }
}
