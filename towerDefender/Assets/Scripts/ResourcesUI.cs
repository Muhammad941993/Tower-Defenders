using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResourcesUI : MonoBehaviour
{
    private ResourceTypeListSO resourceList;
    Dictionary<ResourceTypeSO, Transform> ResourceTypeTransformDictionry;
    private void Awake()
    {
         resourceList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        ResourceTypeTransformDictionry = new();
        Transform trans = transform.Find("resourceTemplet");
        trans.gameObject.SetActive(false);
        int resourceCounter = 0;
        foreach (var item in resourceList.List)
        {
           Transform go =  Instantiate(trans, transform);
            go.gameObject.SetActive(true);
            float offset = -160f;
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset * resourceCounter,0);
            go.Find("image").GetComponent<Image>().sprite = item.resourceSprite;
         
            ResourceTypeTransformDictionry[item] = go;
            resourceCounter++;
        }

    }

    private void Start()
    {
        UpdateResourcesUI();
        ResourceManager.Instance.OnResourceAmountChanged += OnHAngeHappend;
    }

    private void OnHAngeHappend(object sender, EventArgs e)
    {
        UpdateResourcesUI();
    }

    void UpdateResourcesUI()
    {
        foreach (var item in resourceList.List)
        {
            Transform go = ResourceTypeTransformDictionry[item];
            int amount = ResourceManager.Instance.GetResourceAmount(item);
            go.Find("text").GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
       

    }
}
