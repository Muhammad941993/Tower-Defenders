using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] bool RunOnce = true;
    [SerializeField] float positionOffsetY;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        int precisionMultiplayer = 5;
        spriteRenderer.sortingOrder = (int)-((transform.position.y + positionOffsetY) * precisionMultiplayer);

        if (RunOnce)
        {
            Destroy(this);
        }
    }
}
