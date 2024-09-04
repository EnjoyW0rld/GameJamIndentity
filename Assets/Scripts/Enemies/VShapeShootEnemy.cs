using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VShapeShootEnemy : EnemyBase
{
    [SerializeField] private float _shootFrequency;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;


    private Transform _character;
    protected override void Start()
    {
        base.Start();
        _character = CounterManager.Instance.CharacterMover.transform;
        StartCoroutine(DoShooting());
    }
    protected override void Update()
    {
        base.Update();
    }
    private IEnumerator DoShooting()
    {
        while (this != null)
        {
            Shoot();
            yield return new WaitForSeconds(_shootFrequency);
        }
    }
    private void Shoot()
    {
        Vector3 dir = _character.position - transform.position;
        for (int i = -1; i < 2; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);
            Vector3 turnedDir = (Quaternion.Euler(0, 10 * i, 0) * dir).normalized;
            turnedDir.y = 0;
            bullet.Initialize(turnedDir, _bulletSpeed);
        }
    }
}
