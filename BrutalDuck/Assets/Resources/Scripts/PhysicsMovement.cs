using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _addForceValue;
    private Rigidbody _rigidBody;
    private float _halfScreen;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _halfScreen = Screen.height / 2;
    }

    public void Move(float magnitude)
    {
        float clampImpuls = Mathf.Clamp(magnitude, 0, _halfScreen);
        float moveForce = clampImpuls * _addForceValue;
        float impulsPercentage = (clampImpuls * 100) / _halfScreen;
        _rigidBody.AddRelativeForce(Vector3.forward * moveForce, ForceMode.Acceleration);
    }
}
