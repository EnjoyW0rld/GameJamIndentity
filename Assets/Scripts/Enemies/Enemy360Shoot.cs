using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy360Shoot : EnemyBase
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _shotBulletsAmount;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.P)) DoShoot();
    }
    private void DoShoot()
    {
        float degree = 360f / _shotBulletsAmount;
        Vector3 projDir = new Vector3(1, 0, 0);
        for (int i = 0; i < _shotBulletsAmount; i++)
        {
            Bullet spawnedBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            spawnedBullet.Initialize(Quaternion.Euler(0, degree * i, 0) * projDir);
        }
    }
}
