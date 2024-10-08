using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    protected int _damage;
    private bool _needDestroy;
    [SerializeField] protected string _obstacleLayer;

    public void Initialize(Vector3 pDirection, float pSpeed = 50, int pDamage = 1)
    {
        _direction = pDirection;
        _speed = pSpeed;
        _damage = pDamage;
        StartCoroutine(DespawnCooldown(5));
    }
    protected virtual void Update()
    {
        transform.position += _direction * Time.deltaTime * _speed;
        if (_needDestroy) DoDestroy(false);
    }
    private IEnumerator DespawnCooldown(float pDestructonTime)
    {
        yield return new WaitForSeconds(5);
        _needDestroy = true;
    }
    protected virtual void DoDestroy(bool pShotEntity)
    {
        Destroy(gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CharacterHealth>(out CharacterHealth _health))
        {
            if (_health.DecreaseHealth(_damage))
            {
                Destroy(gameObject);
            }
        }
        if(other.gameObject.layer == LayerMask.NameToLayer(_obstacleLayer))
        {
            DoDestroy(false);
        }
    }
}
