using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public void RotateArrow(Vector3 startPos, Vector3 endPos)
    {
        float rotValue = 180 / (float)Screen.width;
        float rotDegree = (rotValue * startPos.x) - 90f;
        Quaternion inputRot = Quaternion.Euler(transform.rotation.x, -rotDegree, transform.rotation.z);
        transform.rotation = FindObjectOfType<TouchInput>().transform.rotation * inputRot;
    }
}
