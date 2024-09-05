using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRadius = 1;
    public UnityEvent OnTamed;
    //[SerializeField] private Collider _collider;

    private void Start()
    {
        if (OnTamed == null) OnTamed = new UnityEvent();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var _collisions = Physics.OverlapSphere(transform.position, _interactionRadius);
            if (_collisions == null || _collisions.Length == 0) return;
            for (int i = 0; i < _collisions.Length; i++)
            {
                if (_collisions[i].TryGetComponent<EnemyBase>(out var enemy))
                {
                    OnTamed?.Invoke();
                    enemy.InstaKill();
                    CounterManager.Instance.ChangeKillAmout(-3);
                }
                /*if (_collisions[i].TryGetComponent<Interactable>(out Interactable interactable))
                {
                    interactable.DoInteraction();
                }*/
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _interactionRadius);
    }
}
