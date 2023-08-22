using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;


public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    BuildingTypeListSO buildingTypeListSO;
    BuildingTypeSO newActiveBuilding;

    //public UnityEvent OnbuidlingChanged;
    public event EventHandler<OnBuildingChangedEventArgs> OnBuidingChanged;
    public class OnBuildingChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuilding;
    }
    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if(newActiveBuilding != null && IfCanSpawn(newActiveBuilding, UtilityClass.GetmouseWorledPosition()))
            Instantiate(newActiveBuilding.Prefab,UtilityClass.GetmouseWorledPosition(), Quaternion.identity);

           
        }
    }


   
    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        newActiveBuilding = buildingType;
        OnBuidingChanged?.Invoke(this, new OnBuildingChangedEventArgs {activeBuilding = newActiveBuilding });
    }

    public BuildingTypeSO GetActiveBuildingType() { return newActiveBuilding; }

    bool IfCanSpawn(BuildingTypeSO buildingType, Vector3 position)
    {
        var collider = buildingType.Prefab.GetComponent<BoxCollider2D>();


       var overlaps =   Physics2D.OverlapBoxAll(position, collider.size, 0);
        bool isClear = overlaps.Length == 0;
        if (!isClear) return false;

        var collider2d = Physics2D.OverlapCircleAll(position, newActiveBuilding.MinConstractionRadious);
        foreach (var item in collider2d)
        {
            var holder = item.GetComponent<BuildingTypeHolder>();
            if (holder != null)
            {
                if(holder.BuildingTypeSO == buildingType)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
