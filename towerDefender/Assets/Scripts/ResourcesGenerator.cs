using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesGenerator : MonoBehaviour
{
    BuildingTypeSO buildingTypeSO;
    float timer;
    float timerMax;

    private void Awake()
    {
        buildingTypeSO = GetComponent<BuildingTypeHolder>().BuildingTypeSO;
        timerMax = buildingTypeSO.resourceGeneratorData.timerMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timerMax;
            ResourcesManager.Instance.AddResources(buildingTypeSO.resourceGeneratorData.ResourceTypeSO,1);
        }
    }
}
