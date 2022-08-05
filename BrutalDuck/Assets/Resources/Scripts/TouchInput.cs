using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private PhysicsMovement _physicsMovement;
    private Vector3 _startTouchPos;

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
                _startTouchPos = currentTouch.position;
            }
            else if (currentTouch.phase == TouchPhase.Moved)
            {
                _physicsMovement.RotateCar(currentTouch.position, _startTouchPos);
            }
            else if (currentTouch.phase == TouchPhase.Canceled
                  || currentTouch.phase == TouchPhase.Ended)
            {
                Vector2 diff = currentTouch.position - (Vector2)_startTouchPos;
                _physicsMovement.Move(diff.magnitude);
            }
        }
    }
}
