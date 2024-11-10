using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    private Enemy _target;
    private float _speed = 20f;

    public static ArrowProjectile Create(Vector2 position , Enemy target)
    {
        Transform arrow = Resources.Load<Transform>("Arrow");
        var arrowTransform = Instantiate(arrow, position, Quaternion.identity);
        ArrowProjectile arrowProjectile = arrowTransform.GetComponent<ArrowProjectile>();
        arrowProjectile.SetTarget(target);
        
        return arrowProjectile; 
    }
    public void SetTarget(Enemy target)
    {
        _target = target;
    }

    private Vector3 _targetDirection;
    private Vector3 _lastTargetDirection;
    private float _timeToDestroy = 2f;

    
    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _targetDirection = (_target.transform.position - transform.position).normalized;
            _lastTargetDirection = _targetDirection;
        }
        else
        {
            _targetDirection = _lastTargetDirection;
        }
       
        transform.position += _targetDirection * (_speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVector(_targetDirection));
        
        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy < 0)
        {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponent<HealthSystem>().Damage(10);
            Destroy(gameObject);
        }
    }
}
