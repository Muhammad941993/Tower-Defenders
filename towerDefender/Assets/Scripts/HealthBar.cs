using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;

    private Transform _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _healthBar = transform.Find("bar");
        healthSystem.OnDamaged += HealthSystemOnOnDamaged;
        UpdateHealthBarVisible();
    }

    private void HealthSystemOnOnDamaged(object sender, EventArgs e)
    {
        _healthBar.localScale = new Vector3(healthSystem.GetHeathNormalized(), 1, 1);
        UpdateHealthBarVisible();
    }

    private void UpdateHealthBarVisible()
    {
        if (healthSystem.IsFullHealth())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }
}
