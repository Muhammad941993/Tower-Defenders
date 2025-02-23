using System;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private HealthSystem _healthSystem;
    BuildingTypeSO _buildingType;
    Transform _buildingDemolishBtn;
    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _buildingType = GetComponent<BuildingTypeHolder>().BuildingTypeSO;
        _buildingDemolishBtn = transform.Find("pfBuildingDemolish");
        
        _buildingDemolishBtn?.gameObject.SetActive(false);
        _healthSystem.SetHealthAmountMax(_buildingType.healthAmountMax,true);
       _healthSystem.OnDied += HealthSystemOnOnDied;
    }

    private void HealthSystemOnOnDied(object sender, EventArgs e)
    {
       Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        _buildingDemolishBtn?.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _buildingDemolishBtn?.gameObject.SetActive(false);
    }
}
