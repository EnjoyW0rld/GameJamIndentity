using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 500;
    private Rigidbody _rb;
    private bool _canMove = true;
    private void Start()
    {
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
        }
    }
}
