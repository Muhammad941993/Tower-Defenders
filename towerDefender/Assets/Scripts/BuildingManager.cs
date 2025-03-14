using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance {  get; private set; }

    [SerializeField] Building hqBuilding;
    private BuildingTypeSO activeBuldingType;
    private BuildingTypeListSO buildingTypeListSO;
    Transform buildingConstraction;
    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;
    public bool IsGameOver { get; private set; } = false;

    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuldingType;
    }
    private void Awake()
    {
        Instance = this;
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        hqBuilding.GetComponent<HealthSystem>().OnDied += HQ_Died;
    }

    private void HQ_Died(object sender, EventArgs e)
    {
        GameOverUI.Instance.Show();
        IsGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            if(activeBuldingType is not null)
            {
                if (CanSpawnBuilding(activeBuldingType, UtilsClass.GetMouseWorledPosition(), out string reason))
                {
                    if (ResourcesManager.Instance.CanAfford(activeBuldingType.constructionCostArray))
                    {
                        ResourcesManager.Instance.SpendResources(activeBuldingType.constructionCostArray);
                        // Instantiate(activeBuldingType.prefab, UtilsClass.GetMouseWorledPosition(), Quaternion.identity);
                        BuildingConstraction.Create(UtilsClass.GetMouseWorledPosition(),activeBuldingType);
                    }
                    else
                    {
                        ToolTipeUI.Instance.Show("You can't afford the construction cost!",
                            new ToolTipeUI.ToolTipeTimer{Timer = 2});
                    }
                }
                else
                {
                    ToolTipeUI.Instance.Show(reason,new ToolTipeUI.ToolTipeTimer{Timer = 2});
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
    
    bool CanSpawnBuilding(BuildingTypeSO buildingType , Vector3 position , out string reason)
    {
        var prefabCollider = buildingType.prefab.GetComponent<BoxCollider2D>();
        var colliders2d = Physics2D.OverlapBoxAll(position, prefabCollider.size,0);

        bool isAreaClear = colliders2d.Length == 0;
        if (!isAreaClear)
        {
            reason = "Area Is Not Clear";
            return false;
        }

        colliders2d = Physics2D.OverlapCircleAll(position, buildingType.minConstructionRadius);
        foreach (var collider in colliders2d)
        {
            var building = collider.GetComponent<BuildingTypeHolder>();
            if (building is not null)
            {
                if(building.BuildingTypeSO == buildingType)
                {
                    reason = "Building Of The Same Type Is Exist";
                    return false;
                }
            }
        }
        float maxConstructionRadius = 30;
        colliders2d = Physics2D.OverlapCircleAll(position, maxConstructionRadius);
        foreach (var collider in colliders2d)
        {
            var building = collider.GetComponent<BuildingTypeHolder>();
            if (building is not null)
            {
                reason = "";
               return true;
            }
        }

        reason = "Building Is So Far";
        return false;
    }
    public Building GetBuildingHQ()=> hqBuilding;
}
