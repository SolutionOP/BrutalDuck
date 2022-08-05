using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _constForce;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Move(float magnitude)
    {
        float moveForce = magnitude * _constForce;
        Debug.Log(moveForce);
        _rigidBody.AddRelativeForce(Vector3.forward * moveForce, ForceMode.Acceleration);
    }

    public void RotateCar(Vector3 rotatePos, Vector3 startPos)
    {
        Vector3 worldPos1 = Camera.main.ScreenToWorldPoint(new Vector3(rotatePos.x, rotatePos.y, Camera.main.transform.position.z * -1));
        Vector3 worldPos2 = Camera.main.ScreenToWorldPoint(new Vector3(startPos.x, startPos.y, Camera.main.transform.position.z * -1));
        Vector3 difference = worldPos2 - worldPos1;
        difference.Normalize();
        float rotAngle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        if (rotAngle >= -90f && rotAngle <= 90f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotAngle, transform.rotation.z);
        }
    }
}
