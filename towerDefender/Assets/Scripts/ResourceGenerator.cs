using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;
    ResourceGeneratorData resourceGeneratorData;
    private void Awake()
    {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().BuildingTypeSO.ResourceGeneratorData;

        timerMax = resourceGeneratorData.TimerMax;
    }
    private void Start()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 5);
        int counter =0;
        foreach (var item in collider2Ds)
        {

          ResourceNode rsourceNode =  item.GetComponent<ResourceNode>();
            if(rsourceNode != null)
            {
                if(rsourceNode.resourceType == resourceGeneratorData.ResourceTypeSO)
                {
                    counter++;

                }
            }
        }
        counter = Mathf.Clamp(counter , 0, resourceGeneratorData.MaxResourceAmount);
        if(counter == 0)
        {
            enabled = false;
        }
        else
        {
            timerMax = (resourceGeneratorData.TimerMax / 2) +
                resourceGeneratorData.TimerMax * (1 - (float)(counter / resourceGeneratorData.MaxResourceAmount));
        }

    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer += timerMax;
            ResourceManager.Instance.AddResource(resourceGeneratorData.ResourceTypeSO, 1);
        }
    }
}
