using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Min(1)] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CoinCollectible _coin;
    private Rigidbody _rb;
    protected float _currentHealth;
    private Vector3 _currentDir;
    public UnityEvent OnDamageTaken;

    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
        if (OnDamageTaken == null) OnDamageTaken = new UnityEvent();
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
    public void InstaKill()
    {
        DestroyThis();
    }
    public void DoDamage(int pDamageAmount)
    {
        _currentHealth -= pDamageAmount;
        OnDamageTaken?.Invoke();
        if (_currentHealth <= 0)
        {
            DestroyThis();
        }
    }
    private void DestroyThis()
    {
        EventManager.Instance.OnEnemyKilled?.Invoke(this);
        Instantiate(_coin, transform.position, _coin.transform.rotation);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}