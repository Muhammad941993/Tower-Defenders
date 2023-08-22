using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public event EventHandler OnResourceAmountChanged;
    private Dictionary<ResourceTypeSO, int> ResourceTypeAmount;
    ResourceTypeListSO resourceList;
    private void Awake()
    {
        Instance = this;
        ResourceTypeAmount = new();

         resourceList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach (var resource in resourceList.List)
        {
            ResourceTypeAmount[resource] = 0;
        }
       // DicTest();
    }

    void DicTest()
    {
        foreach (var item in ResourceTypeAmount)
        {
            print(item.Key.nameString + ":" + ResourceTypeAmount[item.Key]);
            print("=======================");
        }
    }

    public void AddResource(ResourceTypeSO resourceType , int amount)
    {
        ResourceTypeAmount[resourceType] += amount;
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
      //  DicTest();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddResource(resourceList.List[0], 10);
            DicTest();
        }
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return ResourceTypeAmount[resourceType];
    }
}
