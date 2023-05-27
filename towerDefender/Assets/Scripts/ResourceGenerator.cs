using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;
    BuildingTypeSO BuildingTypeSO;
    private void Awake()
    {
        BuildingTypeSO = GetComponent<BuildingTypeHolder>().BuildingTypeSO;

        timerMax = BuildingTypeSO.ResourceGeneratorData.TimerMax;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer += timerMax;
            ResourceManager.Instance.AddResource(BuildingTypeSO.ResourceGeneratorData.ResourceTypeSO, 1);
           // print(BuildingTypeSO.name);
        }
    }
}
