using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance { get; private set; }

    public event EventHandler OnResourcesAmountChanged;
    ResourcesTypeListSO resourcesTypeListSO;
    Dictionary<ResourcesTypeSO, int> resourceTypeAmount = new();
    private void Awake()
    {
        Instance = this;

        resourcesTypeListSO = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
        foreach (var item in resourcesTypeListSO.List)
        {
            resourceTypeAmount[item] = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddResources(resourcesTypeListSO.List[0], 10);
           
        }
    }
    public void PrintResources()
    {
        foreach (var item in resourceTypeAmount)
        {
            print(item.Key + "::" + item.Value);
        }
    }
    public void AddResources(ResourcesTypeSO resourceType, int amount)
    {
        resourceTypeAmount[resourceType] += amount;
        OnResourcesAmountChanged?.Invoke(this,EventArgs.Empty);
    }

    public int GetResourceAmount(ResourcesTypeSO resourceType) => resourceTypeAmount[resourceType];
}
