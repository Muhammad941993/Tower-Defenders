using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int _healthAmountMax = 100;
    private int _healthAmount = 0;

    public event EventHandler OnDamaged;
    public event EventHandler OnDied;

    private void Awake()
    {
        _healthAmount = _healthAmountMax;

    }

    public void Damage(int damage)
    {
        _healthAmount -= damage;
        _healthAmount = Mathf.Clamp(_healthAmount, 0, _healthAmountMax);
        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    private bool IsDead()
    {
        return _healthAmount == 0;
    }

    public int GetHealthAmount() => _healthAmount;

    public float GetHeathNormalized()
    {
       return (float)_healthAmount / _healthAmountMax;
    }

    public bool IsFullHealth()
    {
        return _healthAmount == _healthAmountMax;
    }

    public void SetHealthAmountMax(int buildingTypeHealthAmountMax , bool updateHealth)
    {
       _healthAmountMax = buildingTypeHealthAmountMax;
       if (updateHealth)
       {
           _healthAmount = _healthAmountMax;
       }
    }
}