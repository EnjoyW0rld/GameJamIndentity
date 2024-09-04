using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FronBurstEnemy : EnemyBase
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _shotBulletsAmount;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private float _bulletSpeed;
    private Transform _playerTransform;
    protected override void Start()
    {
        base.Start();
        _playerTransform = CounterManager.Instance.CharacterMover.transform;
        StartCoroutine(DoShoot());
    }
    protected override void Update()
    {
        base.Update();
    }
    private IEnumerator DoShoot()
    {
        while(this != null)
        {
            yield return new WaitForSeconds(_shootFrequency);
            StartCoroutine(DoBurst());
        }
    }
    private IEnumerator DoBurst()
    {
        for (int i = 0; i < _shotBulletsAmount; i++)
        {
            if (this == null) break;
            Vector3 dir = _playerTransform.position - transform.position;
            dir.y = 0;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);
            bullet.Initialize(dir.normalized, _bulletSpeed);
            yield return new WaitForSeconds(.5f);
        }
    }
}
