using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(float moveForce)
    {
        _rigidBody.AddRelativeForce(Vector3.forward * moveForce, ForceMode.Acceleration);
    }

    public void NullVelocity()
    {
        _rigidBody.velocity = Vector3.zero;
    }
}
