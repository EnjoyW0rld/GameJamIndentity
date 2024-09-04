using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] private float _timeToDissapear;
    private float _currentTime;
    private void Start()
    {
        _currentTime = 0;
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _timeToDissapear)
        {
            CounterManager.Instance.ChangeObsessivnes(-1);
            Destroy(gameObject);
        }
    }
    public void Interact()
    {
        print("coin collected");
        CounterManager.Instance.ChangeObsessivnes(2);
        Destroy(gameObject);
    }
}
