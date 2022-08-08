using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;
    public Quaternion TargetRotation;
    private void Update()
    {
        RotateCar();
    }

    private void RotateCar()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, _rotationSpeed * Time.deltaTime);
    }
}
