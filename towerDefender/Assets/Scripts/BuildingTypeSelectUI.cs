using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] Sprite ArrowSprite;
    Dictionary<BuildingTypeSO, Transform> buildingTypes;
    Transform arrowBut;
    private void OnEnable()
    {
        BuildingManager.Instance.OnBuidingChanged += Instance_OnBuidingChanged;
    }

   
    private void OnDisable()
    {
        BuildingManager.Instance.OnBuidingChanged -= Instance_OnBuidingChanged;

    }
    private void Awake()
    {
        buildingTypes = new();

        Transform temp = transform.Find("BuildingSelectTemp");
        temp.gameObject.SetActive(false);
        BuildingTypeListSO buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        int index = 0;


         arrowBut = Instantiate(temp, transform);
        arrowBut.gameObject.SetActive(true);
        arrowBut.GetComponent<RectTransform>().anchoredPosition = new Vector2(130 * index, 0);
        arrowBut.Find("building").GetComponent<Image>().sprite = ArrowSprite;
        arrowBut.Find("building").GetComponent<RectTransform>().sizeDelta = new Vector2(-30, -30);
        arrowBut.GetComponent<Button>().onClick.AddListener(() =>
        { BuildingManager.Instance.SetActiveBuildingType(null); });


        index++;

        foreach (var building in buildingTypeListSO.List)
        {
            Transform newBuild = Instantiate(temp, transform);
            newBuild.gameObject.SetActive(true);
            newBuild.GetComponent<RectTransform>().anchoredPosition = new Vector2(130 * index, 0);
            newBuild.Find("building").GetComponent<Image>().sprite = building.sprite;
            newBuild.GetComponent<Button>().onClick.AddListener(() =>
            { BuildingManager.Instance.SetActiveBuildingType(building); });
            buildingTypes[building] = newBuild;

            index++;
        }
    }
    private void Start()
    {
        UpdateBuildingTypeSelected();
    }

    private void Instance_OnBuidingChanged(object sender,BuildingManager.OnBuildingChangedEventArgs e)
    {
        UpdateBuildingTypeSelected();

    }

    void UpdateBuildingTypeSelected()
    {
        arrowBut.Find("selected").gameObject.SetActive(false);
        foreach (var building in buildingTypes.Keys)
        {
            buildingTypes[building].Find("selected").gameObject.SetActive(false);
        }

        BuildingTypeSO typeSO = BuildingManager.Instance.GetActiveBuildingType();
        if(typeSO == null)
        {
            arrowBut.Find("selected").gameObject.SetActive(true);
        }
        else
        {
            buildingTypes[typeSO].Find("selected").gameObject.SetActive(true);

        }
    }
}
