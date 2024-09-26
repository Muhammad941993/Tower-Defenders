using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuldingTypeSelectUI : MonoBehaviour
{
    [SerializeField] Sprite ArrowSprite;
    [SerializeField] List<BuildingTypeSO> ignoreBuildingTypeList;

    Transform arrowButton;
    Transform buttonTemplete;
    private BuildingTypeListSO buildingTypeListSO;
    Dictionary<BuildingTypeSO, Transform> buttonBuildingTransformDictionary = new();
    private void Awake()
    {
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        buttonTemplete = transform.Find("buttonTemplet");
        buttonTemplete.gameObject.SetActive(false);

        int index = 0;
        float offsetAmount = 130f;

        arrowButton = Instantiate(buttonTemplete, transform);
        arrowButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
        arrowButton.Find("image").GetComponent<Image>().sprite = ArrowSprite;
        arrowButton.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2 (40,40);
        arrowButton.Find("selected").gameObject.SetActive(true);
        arrowButton.gameObject.SetActive(true);
        arrowButton.GetComponent<Button>().onClick.AddListener(() =>
        { BuildingManager.Instance.SetActiveBuildingType(null); });
        index++;


        foreach (var buildingType in buildingTypeListSO.List)
        {
            if (ignoreBuildingTypeList.Contains(buildingType)) continue;

            var button = Instantiate(buttonTemplete, transform);
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            button.Find("image").GetComponent<Image>().sprite = buildingType.sprite;
            button.gameObject.SetActive(true);
            buttonBuildingTransformDictionary[buildingType] = button;
            button.GetComponent<Button>().onClick.AddListener(() => 
            { BuildingManager.Instance.SetActiveBuildingType(buildingType);  });
            
            index++;
        }

    }
    private void Start()
    {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
    {
        UpdateActiveBuildingTypeUI();
    }

    void UpdateActiveBuildingTypeUI()
    {
        arrowButton.Find("selected").gameObject.SetActive(false);

        foreach (var button in buttonBuildingTransformDictionary.Keys)
        {
            buttonBuildingTransformDictionary[button].Find("selected").gameObject.SetActive(false);
        }

        var selectedType = BuildingManager.Instance.GetActiveBuilding();
        if (selectedType == null)
        {
            arrowButton.Find("selected").gameObject.SetActive(true);
        }
        else
        {
            buttonBuildingTransformDictionary[selectedType].Find("selected").gameObject.SetActive(true);
        }
        
    }
}
