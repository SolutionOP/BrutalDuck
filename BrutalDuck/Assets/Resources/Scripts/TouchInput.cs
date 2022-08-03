using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private PhysicsMovement _physicsMovement;
    private Vector3 _touchStartPosition;
    private Vector3 _finishTouchPosition;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch currentTouch = Input.GetTouch(0);
            if (currentTouch.phase == TouchPhase.Began)
            {
                _touchStartPosition = currentTouch.position;
            }
            else if (currentTouch.phase == TouchPhase.Canceled
                  || currentTouch.phase == TouchPhase.Ended)
            {
                _finishTouchPosition = currentTouch.position;
                _physicsMovement.Move(_touchStartPosition, _finishTouchPosition);
            }
        }
    }
}
