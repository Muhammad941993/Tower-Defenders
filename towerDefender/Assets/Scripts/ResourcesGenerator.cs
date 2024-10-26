using UnityEngine;

public class ResourcesGenerator : MonoBehaviour
{
    ResourcesGeneratorData resourceGeneratorData;
    float timer;
    float timerMax;


    private void Awake()
    {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().BuildingTypeSO.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        int nearResource = GetNearbyResourceAmount(resourceGeneratorData, transform.position);

        if (nearResource <= 0)
        {
            this.enabled = false;
        }
        else
        {
            timerMax = resourceGeneratorData.timerMax / 2 +
                resourceGeneratorData.timerMax *
                (1 - nearResource / resourceGeneratorData.maxResourceAmount);
        }
    }

    public static int GetNearbyResourceAmount(ResourcesGeneratorData resourceGeneratorData, Vector3 position)
    {
        var collider2dArray =
            Physics2D.OverlapCircleAll(position, resourceGeneratorData.resourceDetectionRadius);

        int nearResource = 0;
        foreach (var collider in collider2dArray)
        {
            var node = collider.GetComponent<ResourceNode>();
            if (node != null)
            {
                if (node.ResourcesType == resourceGeneratorData.ResourceTypeSO)
                {
                    nearResource++;

                }
            }
        }
        nearResource = Mathf.Clamp(nearResource, 0, resourceGeneratorData.maxResourceAmount);
        return nearResource;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerMax;
            ResourcesManager.Instance.AddResources(resourceGeneratorData.ResourceTypeSO, 1);
        }
    }
    public ResourcesGeneratorData GetResourcesGeneratorData()
    {
        return resourceGeneratorData;
    }

    public float GetAmountGeneratedPerSecond()
    {
        return 1 / timerMax;
    }

    public float GetTimeNormalized()
    {
        return timer / timerMax;
    }
}
