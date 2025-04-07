using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRepairBtn : MonoBehaviour
{
   [SerializeField] HealthSystem healthSystem;
   [SerializeField] ResourcesTypeSO resourcesType;

   private void Awake()
   {
      transform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
      {
          int missingHealth = healthSystem.GetHealthAmountMax() - healthSystem.GetHealthAmount();
          int repairCost = missingHealth / 2;
          ResourceAmount[] resourceAmountCost = new ResourceAmount[]
              { new ResourceAmount() { resourcesTypeSO = resourcesType, amount = repairCost } };

          if (ResourcesManager.Instance.CanAfford(resourceAmountCost))
          {
              ResourcesManager.Instance.SpendResources(resourceAmountCost);
              healthSystem.HealFull();
          }
          else
          {
              ToolTipeUI.Instance.Show("Can't afford repair cost");
          }
         
      });
   }
}
