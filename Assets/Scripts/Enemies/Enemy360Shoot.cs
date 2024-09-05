using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy360Shoot : EnemyBase
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _shotBulletsAmount;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private float _bulletSpeed;

    public UnityEvent OnEnemyShoots;

    protected override void Start()
    {
        base.Start();
        if (OnEnemyShoots == null) OnEnemyShoots = new UnityEvent();
        StartCoroutine(DoShooting());
    }
    protected override void Update()
    {
        //base.Update();
        //if (Input.GetKeyDown(KeyCode.P)) DoShoot();
    }
    private IEnumerator DoShooting()
    {
        while(this != null)
        {
            yield return new WaitForSeconds(_shootFrequency);
            OnEnemyShoots?.Invoke();
            Shoot();
        }
    }
    private void Shoot()
    {
        float degree = 360f / _shotBulletsAmount;
        Vector3 projDir = new Vector3(1, 0, 0);
        for (int i = 0; i < _shotBulletsAmount; i++)
        {
            Bullet spawnedBullet = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);
            spawnedBullet.Initialize((Quaternion.Euler(0, degree * i, 0) * projDir).normalized,_bulletSpeed);
        }
    }
}
