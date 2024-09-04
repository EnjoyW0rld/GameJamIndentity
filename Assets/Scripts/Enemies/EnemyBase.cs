using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Min(1)] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    private Rigidbody _rb;
    protected float _currentHealth;
    private Vector3 _currentDir;


    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
        StartCoroutine(ChangeDirection(3));
    }
    protected virtual void Update()
    {
        _rb.velocity = _currentDir * _moveSpeed;
    }
    private IEnumerator ChangeDirection(float pFrequency)
    {
        while (this != null)
        {
            _currentDir = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));
            _currentDir.Normalize();
            yield return new WaitForSeconds(pFrequency);
        }
    }

    public void DoDamage(int pDamageAmount)
    {
        _currentHealth -= pDamageAmount;
        if (_currentHealth <= 0)
        {
            DestroyThis();
        }
    }
    private void DestroyThis()
    {
        EventManager.Instance.OnEnemyKilled?.Invoke(this);
        gameObject.SetActive(false);
    }
}