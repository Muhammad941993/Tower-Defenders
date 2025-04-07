using System;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private HealthSystem _healthSystem;
    BuildingTypeSO _buildingType;
    Transform _buildingDemolishBtn;
    Transform _buildingRepairBtn;

    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _buildingType = GetComponent<BuildingTypeHolder>().BuildingTypeSO;
        _buildingDemolishBtn = transform.Find("pfBuildingDemolish");
        _buildingRepairBtn = transform.Find("pfBuildingRepair");

        
        _buildingDemolishBtn?.gameObject.SetActive(false);
        HideRepairBtn();
        
        _healthSystem.OnDamaged += HealthSystemOnOnDamaged;
        _healthSystem.OnHealed += HealthSystemOnOnHealed;
        _healthSystem.SetHealthAmountMax(_buildingType.healthAmountMax,true);
       _healthSystem.OnDied += HealthSystemOnOnDied;
    }

    private void HealthSystemOnOnHealed(object sender, EventArgs e)
    {
        if (_healthSystem.IsFullHealth())
        {
            HideRepairBtn();
        }
    }

    private void HealthSystemOnOnDamaged(object sender, EventArgs e)
    {
        EnableRepairBtn();
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

    void HideRepairBtn()
    {
        _buildingRepairBtn?.gameObject.SetActive(false);
    }

    void EnableRepairBtn()
    {
        _buildingRepairBtn?.gameObject.SetActive(true);
    }
}
