using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Enemy _target;
    Transform _projectileSpawnPoint;
    [SerializeField]private float _arrowLanchTime = 0.3f;
    float _arrowLanchTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _arrowLanchTimer = _arrowLanchTime;
        _projectileSpawnPoint = GameObject.Find("ProjectileSpawnPoint").transform;
        InvokeRepeating(nameof(LookForNearestTarget), 1f, 0.4f);
    }

    private void Update()
    {
        if(_target == null) return;
        _arrowLanchTimer -= Time.deltaTime;
        if (_arrowLanchTimer < 0)
        {
            _arrowLanchTimer = _arrowLanchTime;
            ArrowProjectile.Create(_projectileSpawnPoint.position, _target);
        }
        
    }

    void LookForNearestTarget()
    {
        var nearestTarget = Physics2D.OverlapCircleAll(transform.position, 15);
        
        foreach (var VARIABLE in nearestTarget)
        {
            var enemy = VARIABLE.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (_target == null)
                {
                    _target = enemy;
                }
                else
                {
                    if (Vector2.Distance(transform.position, _target.transform.position) >
                        Vector2.Distance(transform.position, VARIABLE.transform.position))
                    {
                        _target = enemy;
                    }
                    
                }
            }
        }
    }
}
