using System;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private HealthSystem _healthSystem;
    BuildingTypeSO _buildingType;
    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _buildingType = GetComponent<BuildingTypeHolder>().BuildingTypeSO;
        
        
        _healthSystem.SetHealthAmountMax(_buildingType.healthAmountMax,true);
       _healthSystem.OnDied += HealthSystemOnOnDied;
    }

    private void HealthSystemOnOnDied(object sender, EventArgs e)
    {
       Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthSystem.Damage(10);
        }
    }
}
