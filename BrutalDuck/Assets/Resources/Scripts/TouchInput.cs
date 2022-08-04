using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private PhysicsMovement _physicsMovement;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Moved)
            {
                _physicsMovement.RotateCar(currentTouch.position);
            }
            else if (currentTouch.phase == TouchPhase.Canceled
                  || currentTouch.phase == TouchPhase.Ended)
            {
                _physicsMovement.Move();
            }
        }
    }
}