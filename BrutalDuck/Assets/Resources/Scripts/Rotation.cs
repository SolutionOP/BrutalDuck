using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void RotateCar(Vector3 startPos, Vector3 endPos)
    {
        Vector3 directionVector = endPos - startPos;
        directionVector.Normalize();
        float rotAngle = Mathf.Clamp(Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg, -90f, 90f);
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotAngle, transform.rotation.z);
    }
}
