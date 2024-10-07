using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    ResourceNerbyOverlay resourceNerby;
    SpriteRenderer spriteRender;
    private void Awake()
    {
        spriteRender = transform.Find("sprite").GetComponent<SpriteRenderer>();
        resourceNerby = transform.Find("ResourceNerbyOverlay").GetComponent<ResourceNerbyOverlay>();
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
            resourceNerby.Show(eventArgs.activeBuldingType.resourceGeneratorData);
        }
        else
        {
            Hide();
            resourceNerby.Hide();
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
