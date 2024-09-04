using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    private static CounterManager _instance;
    public static CounterManager Instance { get { return _instance; } }

    [SerializeField]private int _killedAmount;
    [SerializeField]private int _accuracy;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    private void Start()
    {
        EventManager.Instance.OnEnemyKilled.AddListener(AddToKillAmount);
    }
    private void AddToKillAmount(EnemyBase pBaseEnemy)
    {
        _killedAmount++;
    }
    public void ChangeAccuracy(bool pDidHit)
    {
        if (pDidHit)
        {
            _accuracy += 10;
        }
        else
        {
            _accuracy -= 1;
        }
    }
}
