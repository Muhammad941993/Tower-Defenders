using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    Dictionary<ResourcesTypeSO, Transform> resourceTypeTransformDictionary = new();
    ResourcesTypeListSO resourcesTypeListSO;
    Transform resourcesTemp;
    private void Awake()
    {
        resourcesTemp = transform.Find("resourceTemp");
        resourcesTemp.gameObject.SetActive(false);

        resourcesTypeListSO = Resources.Load<ResourcesTypeListSO>(typeof(ResourcesTypeListSO).Name);
       
    }
    private void Start()
    {
        ResourcesManager.Instance.OnResourcesAmountChanged += ResourcesManager_OnResourcesAmountChanged;

        float offsetAmount = -100;
        int resourceCounter = 0;
        foreach (var resource in resourcesTypeListSO.List)
        {
            var resourceTemp = Instantiate(resourcesTemp, transform);
            resourceTypeTransformDictionary[resource] = resourceTemp;

            resourceTemp.gameObject.SetActive(true);

            resourceTemp.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(offsetAmount * resourceCounter, -35);
            resourceCounter++;

            resourceTemp.Find("image").GetComponent<Image>().sprite = resource.Image;
            resourceTemp.Find("text").GetComponent<TextMeshProUGUI>().text =
                ResourcesManager.Instance.GetResourceAmount(resource).ToString();

        }
    }

    private void ResourcesManager_OnResourcesAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResource();
    }

    public void UpdateResource()
    {
        foreach (var resource in resourcesTypeListSO.List)
        {

            resourceTypeTransformDictionary[resource].Find("text").GetComponent<TextMeshProUGUI>().text =
                ResourcesManager.Instance.GetResourceAmount(resource).ToString();

        }
    }
}
