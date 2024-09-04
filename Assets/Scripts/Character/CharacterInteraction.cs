using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRadius = 1;
    //[SerializeField] private Collider _collider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var _collisions = Physics.OverlapSphere(transform.position, _interactionRadius);
            if (_collisions == null || _collisions.Length == 0) return;
            for (int i = 0; i < _collisions.Length; i++)
            {
                if (_collisions[i].TryGetComponent<Interactable>(out Interactable interactable))
                {
                    interactable.DoInteraction();
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _interactionRadius);
    }
}
