using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] bool RunOnce;
    [SerializeField] float Offset;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        int presisionMultiplayer = 5;
        spriteRenderer.sortingOrder = - (int)(transform.position.y+ Offset) * presisionMultiplayer;

        if (RunOnce)
        {
            Destroy(this);
        }
    }
}
