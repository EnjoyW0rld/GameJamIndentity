using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    public UnityEvent<EnemyBase> OnEnemyKilled;
    public UnityEvent<RoomInstance> OnAllEnemyKilled;
    private void Awake()
    {
        if (_instance != null || _instance != this)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    private void Start()
    {
        OnEnemyKilled = new UnityEvent<EnemyBase>();
        OnAllEnemyKilled = new UnityEvent<RoomInstance>();
    }
}
