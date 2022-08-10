using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 50f;
    public Quaternion TargetRotation;
    private void Update()
    {
        if (transform.rotation != TargetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

}
