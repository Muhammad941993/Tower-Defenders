using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    SpriteRenderer spriteRender;
    private void Awake()
    {
        spriteRender = transform.Find("sprite").GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeSelected;
        Hide();
    }

    private void BuildingManager_OnActiveBuildingTypeSelected(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs eventArgs)
    {
        if(eventArgs.activeBuldingType != null)
        {
            Show(eventArgs.activeBuldingType.sprite);
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = UtilsClass.GetMouseWorledPosition();
    }

    void Show(Sprite sprite)
    {
        spriteRender.gameObject.SetActive(true);
        spriteRender.sprite = sprite;
    }
    void Hide()
    {
        spriteRender.gameObject.SetActive(false);
    }
}
