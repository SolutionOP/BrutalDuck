using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointMove : MonoBehaviour
{
    public void MoveCheckPoint(GameObject target)
    {
        transform.position = target.transform.position;
        transform.rotation = target.transform.rotation;
    }
}
