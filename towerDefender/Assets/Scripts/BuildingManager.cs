using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance {  get; private set; }

    private BuildingTypeSO activeBuldingType;
    private BuildingTypeListSO buildingTypeListSO;
    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuldingType;
    }
    private void Awake()
    {
        Instance = this;
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            if(activeBuldingType != null && CanSpawnBuilding(activeBuldingType, UtilsClass.GetMouseWorledPosition()))
            {
                if (ResourcesManager.Instance.CanAfford(activeBuldingType.constructionCostArray))
                {
                    ResourcesManager.Instance.SpendResources(activeBuldingType.constructionCostArray);
                    Instantiate(activeBuldingType.prefab, UtilsClass.GetMouseWorledPosition(), Quaternion.identity);

                }
            }
        }
    }

    public BuildingTypeSO GetActiveBuilding()=> activeBuldingType;
    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuldingType = buildingType;
        OnActiveBuildingTypeChanged?.Invoke(this,
            new OnActiveBuildingTypeChangedEventArgs { activeBuldingType = activeBuldingType 
            });
    }
    
    bool CanSpawnBuilding(BuildingTypeSO buildingType , Vector3 position)
    {
        var prefabCollider = buildingType.prefab.GetComponent<BoxCollider2D>();
        var colliders2d = Physics2D.OverlapBoxAll(position, prefabCollider.size,0);

        bool isAreaClear = colliders2d.Length == 0;
        if (!isAreaClear) return false;

        colliders2d = Physics2D.OverlapCircleAll(position, buildingType.minConstructionRadius);
        foreach (var collider in colliders2d)
        {
            var building = collider.GetComponent<BuildingTypeHolder>();
            if (building != null)
            {
                if(building.BuildingTypeSO == buildingType)
                {
                    return false;
                }
            }
        }
        float maxConstructionRadius = 30;
        colliders2d = Physics2D.OverlapCircleAll(position, maxConstructionRadius);
        foreach (var collider in colliders2d)
        {
            var building = collider.GetComponent<BuildingTypeHolder>();
            if (building != null)
            {
               return true;
            }
        }

        return false;
    }
}
