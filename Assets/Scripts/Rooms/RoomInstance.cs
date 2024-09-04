using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RoomInstance : MonoBehaviour
{
    [SerializeField] private int _startEnemyAmount;
    [SerializeField] protected EnemyBase _enemyPrefab;
    [SerializeField] private Bounds _bounds;
    [SerializeField] private Vector3 _playerSpawnPos;

    private int _enemyLeft;
    public Vector3 PlayerSpawnPoint { get { return _playerSpawnPos; } }

    private void Start()
    {
        _enemyLeft = _startEnemyAmount;
        EventManager.Instance.OnEnemyKilled.AddListener(DecreaseEnemyAmount);
        SpawnEnemies();
    }
    private void SpawnEnemies()
    {
        for (int i = 0; i < _startEnemyAmount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-_bounds.extents.x, _bounds.extents.x) + _bounds.center.x, 1f, Random.Range(-_bounds.extents.z, _bounds.extents.z) + _bounds.center.z);
            EnemyBase enemy = Instantiate(_enemyPrefab, spawnPos, _enemyPrefab.transform.rotation);
        }
    }
    private void DecreaseEnemyAmount(EnemyBase pEnemy)
    {
        _enemyLeft--;
        if (_enemyLeft <= 0)
        {
            print("all enemies killed");
            EventManager.Instance.OnAllEnemyKilled?.Invoke(this);
        }
    }
    private void OnDestroy()
    {
        EventManager.Instance.OnEnemyKilled.RemoveListener(DecreaseEnemyAmount);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(_bounds.center, _bounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(_playerSpawnPos, new Vector3(.5f, .5f, .5f));
    }
}