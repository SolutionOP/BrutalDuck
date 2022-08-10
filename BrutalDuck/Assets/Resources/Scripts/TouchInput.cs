using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab; 
    [SerializeField] private UIController _uiController;
    private PhysicsMovement _physicsMovement;
    private ArrowRotation _arrowRotation;
    private MomentumCalculation _momentumCalculation;
    private CarRotation _carRotation;
    private Vector3 _startTouchPos;
    private float _clampImpuls;
    private float _impulsPercentage;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
        _arrowRotation = _arrowPrefab.GetComponent<ArrowRotation>();
        _momentumCalculation = GetComponent<MomentumCalculation>();
        _carRotation = GetComponent<CarRotation>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                _startTouchPos = currentTouch.position;
                _arrowPrefab.SetActive(true);
            }
            else if (currentTouch.phase == TouchPhase.Moved)
            {
                _clampImpuls = _momentumCalculation.GetClampImpuls((Vector2)_startTouchPos, currentTouch.position);
                _impulsPercentage = _momentumCalculation.GetImpulsPercentage(_clampImpuls);
                _uiController.ChangeTensionForce((int)_impulsPercentage);
                _arrowRotation.RotateArrow(currentTouch.position, _startTouchPos);
            }
            else if (currentTouch.phase == TouchPhase.Canceled
                  || currentTouch.phase == TouchPhase.Ended)
            {
                if (_startTouchPos != Vector3.zero)
                {
                    _uiController.IsFinish = false;
                    _clampImpuls = _momentumCalculation.GetClampImpuls((Vector2)_startTouchPos, currentTouch.position);
                    _carRotation.TargetRotation = _arrowPrefab.transform.rotation;
                    _physicsMovement.Move(_momentumCalculation.GetMoveForceValue(_clampImpuls));
                    _arrowPrefab.SetActive(false);
                    _uiController.ChangeTensionForce(0);
                    _startTouchPos = Vector3.zero;  
                }
            }
        }
    }
}
