using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 500;
    private Rigidbody _rb;
    private bool _canMove = true;
    public UnityEvent OnCoinCollected;
    public UnityEvent OnPlayerMoving;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        if (OnCoinCollected == null) OnCoinCollected = new UnityEvent();
        if (OnPlayerMoving == null) OnPlayerMoving = new UnityEvent();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!_canMove) return;
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        Vector3 velocity = new Vector3(xAxis,0, zAxis);
        velocity.Normalize();
        _rb.velocity = velocity * _movementSpeed;
        if (velocity.magnitude > .1f) OnPlayerMoving?.Invoke();
    }
    public void SetCanMoveMode(bool pMoveMode)
    {
        _canMove = pMoveMode;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CoinCollectible>(out var coin))
        {
            coin.Interact();
            OnCoinCollected?.Invoke();
        }
    }
}
