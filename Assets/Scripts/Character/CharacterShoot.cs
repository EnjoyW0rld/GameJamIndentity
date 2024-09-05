using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterShoot : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bullet;
    [SerializeField] private float _shootCooldown;
    [SerializeField] protected float _bulletSpeed = 10;
    [SerializeField] private Vector3 _bulletSpawnOffset = new Vector3(0,.5f,0);
    public UnityEvent OnPlayerShot;

    private Plane _plane;
    private void Start()
    {
        if (OnPlayerShot == null) OnPlayerShot = new UnityEvent();
        _plane = new Plane(Vector3.up, Vector3.zero);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            Vector3 aimPoint = Vector3.zero;
            if (_plane.Raycast(ray, out float entryPoint))
            {
                aimPoint = ray.GetPoint(entryPoint);
            }
            PlayerBullet bullet = Instantiate(_bullet, transform.position + _bulletSpawnOffset, Quaternion.identity);
            Vector3 bulletDir = (aimPoint - transform.position).normalized;
            bulletDir.y = 0;
            bullet.Initialize(bulletDir,_bulletSpeed);
            OnPlayerShot?.Invoke();
        }
    }
}
