using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _tmpForce;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 startPos, Vector3 endPos)
    {
        _rigidBody.AddForce(Vector3.forward * _tmpForce, ForceMode.Acceleration);
    }
}
