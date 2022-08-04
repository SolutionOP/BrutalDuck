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

    public void Move()
    {
        _rigidBody.AddRelativeForce(Vector3.forward * _tmpForce, ForceMode.Acceleration);
    }

    public void RotateCar(Vector3 rotatePos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(rotatePos.x, rotatePos.y, Camera.main.transform.position.z * -1));
        Vector3 difference = worldPos - transform.position;
        difference.Normalize();
        float rotAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float fixedAngle = (rotAngle - 90f) * 3;
        if (fixedAngle <= 90f || fixedAngle >=- 90f)
        { 
            transform.rotation = Quaternion.Euler(0f, fixedAngle , 0f);
        }
    }
}
