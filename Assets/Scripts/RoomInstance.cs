using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance : MonoBehaviour
{
    [SerializeField] private int _startEnemyAmount;
    [SerializeField] protected EnemyBase _enemyPrefab;

    private int _enemyLeft;

    private void Start()
    {
        _enemyLeft = _startEnemyAmount;
        EventManager.Instance.OnEnemyKilled.AddListener(DecreaseEnemyAmount);
    }
    private void DecreaseEnemyAmount(EnemyBase pEnemy)
    {
        _enemyLeft--;
    }
    private void OnDestroy()
    {
        EventManager.Instance.OnEnemyKilled.RemoveListener(DecreaseEnemyAmount);
    }
}
