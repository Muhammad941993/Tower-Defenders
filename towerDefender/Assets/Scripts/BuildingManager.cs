using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private BuildingTypeSO WoodHarvester;
    private BuildingTypeListSO buildingTypeListSO;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        WoodHarvester = buildingTypeListSO.List[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(WoodHarvester.Prefab, GetMouseWorledPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            WoodHarvester = buildingTypeListSO.List[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            WoodHarvester = buildingTypeListSO.List[1];
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            WoodHarvester = buildingTypeListSO.List[2];
        }
    }

    Vector3 GetMouseWorledPosition()
    {
        Vector3 WorlesPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        WorlesPosition.z = 0;
        return WorlesPosition;
    }
}
