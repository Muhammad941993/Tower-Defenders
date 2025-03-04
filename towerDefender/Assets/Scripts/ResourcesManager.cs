using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance { get; private set; }

    public event EventHandler OnResourcesAmountChanged;
    private ResourcesTypeListSO resourcesTypeListSO;
    Dictionary<ResourcesTypeSO, int> resourceTypeAmount = new();
    [SerializeField] List<ResourceAmount> startResourceAmounts = new List<ResourceAmount>();

    private void Awake()
    {
        Instance = this;

        resourcesTypeListSO = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        foreach (var item in resourcesTypeListSO.List)
        {
            resourceTypeAmount[item] = 0;
        }
        foreach (var VARIABLE in startResourceAmounts)
        {
            AddResources(VARIABLE.resourcesTypeSO, VARIABLE.amount);
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void AddResources(ResourcesTypeSO resourceType, int amount)
    {
        resourceTypeAmount[resourceType] += amount;
        OnResourcesAmountChanged?.Invoke(this,EventArgs.Empty);
    }

    public int GetResourceAmount(ResourcesTypeSO resourceType) => resourceTypeAmount[resourceType];

    public bool CanAfford(ResourceAmount[] resourceAmounts)
    {
        foreach (var resourceAmount in resourceAmounts)
        {
            if(GetResourceAmount(resourceAmount.resourcesTypeSO) < resourceAmount.amount)
            {
                return false;
            }
        }
        return true;
    }

    public void SpendResources(ResourceAmount[] resourceAmounts)
    {
        foreach (var resourceAmount in resourceAmounts)
        {
            resourceTypeAmount[resourceAmount.resourcesTypeSO] -= resourceAmount.amount; 
        }
    }


}
