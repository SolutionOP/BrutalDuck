using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private PhysicsMovement _physicsMovement;
    private Rotation _rotation;
    private Vector3 _startTouchPos;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
        _rotation = GetComponent<Rotation>();
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
                _rotation.RotateCar(currentTouch.position, _startTouchPos);
            }
            else if (currentTouch.phase == TouchPhase.Canceled
                  || currentTouch.phase == TouchPhase.Ended)
            {
                Vector2 directionVector = currentTouch.position - (Vector2)_startTouchPos;
                _physicsMovement.Move(directionVector.magnitude);
            }
        }
    }
}
