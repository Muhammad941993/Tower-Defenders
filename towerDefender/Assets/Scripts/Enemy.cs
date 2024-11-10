using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Create(Vector2 position)
    {
        Transform enemy = Resources.Load<Transform>("Enemy");
        var x = Instantiate(enemy, position, Quaternion.identity);
        return x.GetComponent<Enemy>();
    }
    
    private Transform _target;
    private Rigidbody2D _rigidbody;
    private HealthSystem _healthSystem;

    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = BuildingManager.Instance.GetBuildingHQ().transform;
        _healthSystem.OnDied += HealthSystemOnOnDied;
        InvokeRepeating(nameof(LookForNearestTarget),1f,.5f);
    }

    private void OnDestroy()
    {
        _healthSystem.OnDied -= HealthSystemOnOnDied;

    }

    private void HealthSystemOnOnDied(object sender, EventArgs e)
    {
       Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _rigidbody.velocity = (_target.position - transform.position).normalized * _speed;

        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Building>() is not null)
        {
            other.gameObject.GetComponent<HealthSystem>().Damage(10);
            Destroy(gameObject);
        }
    }

    void LookForNearestTarget()
    {
        var nearestTarget = Physics2D.OverlapCircleAll(transform.position, 5);
        
        foreach (var VARIABLE in nearestTarget)
        {
            if (VARIABLE.GetComponent<Building>() is not null)
            {
                if (_target is null)
                {
                    _target = VARIABLE.transform;
                }
                else
                {
                    if (Vector2.Distance(transform.position, _target.position) >
                        Vector2.Distance(transform.position, VARIABLE.transform.position))
                    {
                        _target = VARIABLE.transform;
                    }
                    
                }
            }
        }

        if (_target is null)
        {
            _target = BuildingManager.Instance.GetBuildingHQ().transform;
        }
    }
}
