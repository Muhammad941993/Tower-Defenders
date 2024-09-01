using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance {  get; private set; }

    private BuildingTypeSO activeBuldingType;
    private BuildingTypeListSO buildingTypeListSO;
    private Camera mainCamera;
    private void Awake()
    {
        Instance = this;
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

    }
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            if(activeBuldingType != null)
            {
                Instantiate(activeBuldingType.Prefab, GetMouseWorledPosition(), Quaternion.identity);
            }
        }
    }

    public BuildingTypeSO GetActiveBuilding()=> activeBuldingType;
    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuldingType = buildingType;
    }
    Vector3 GetMouseWorledPosition()
    {
        Vector3 WorlesPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        WorlesPosition.z = 0;
        return WorlesPosition;
    }
}
