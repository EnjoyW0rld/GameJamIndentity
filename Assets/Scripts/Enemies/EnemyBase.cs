using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField,Min(1)] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    protected float _currentHealth;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void DoDamage(int pDamageAmount)
    {
        _currentHealth -= pDamageAmount;
        if (_currentHealth <= 0)
        {
            DestroyThis();
            EventManager.Instance.OnEnemyKilled?.Invoke(this);
        }
    }
    private void DestroyThis()
    {
        print(name + " got killed");
    }
}