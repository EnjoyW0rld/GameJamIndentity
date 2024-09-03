using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 500;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        Vector3 velocity = new Vector3(xAxis,0, zAxis);
        velocity.Normalize();
        _rb.velocity = velocity * _movementSpeed * Time.deltaTime;

    }
}
