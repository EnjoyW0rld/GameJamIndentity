using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    private static CounterManager _instance;
    public static CounterManager Instance { get { return _instance; } }

    [SerializeField] private int _killedAmount;
    [SerializeField] private int _accuracy;
    [SerializeField] private int _obssesivnes;

    public int KilledAmount { get { return _killedAmount; } }
    public int Accuracy { get { return _accuracy; } }
    public int Obsesivnes { get { return _obssesivnes; } }

    private CharacterMover _characterMover;
    public CharacterMover CharacterMover { get { return _characterMover; } }
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
        _characterMover = FindObjectOfType<CharacterMover>();
    }
    public void ChangeObsessivnes(int pValueToAdd)
    {
        _obssesivnes += pValueToAdd;
    }
    public void ChangeKillAmout(int pValueToAdd)
    {
        _killedAmount += pValueToAdd;
    }
    private void AddToKillAmount(EnemyBase pBaseEnemy)
    {
        ChangeKillAmout(1);
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
