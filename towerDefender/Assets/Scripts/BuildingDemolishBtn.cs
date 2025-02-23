using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDemolishBtn : MonoBehaviour
{
   [SerializeField] Building building;

   private void Awake()
   {
      transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
      {
         var Cost = building.GetComponent<BuildingTypeHolder>().BuildingTypeSO;
         foreach (var VARIABLE in Cost.constructionCostArray)
         {
            ResourcesManager.Instance.AddResources(VARIABLE.resourcesTypeSO,Mathf.FloorToInt(VARIABLE.amount * .6f));
         }
         Destroy(building.gameObject);
      });
   }
}
