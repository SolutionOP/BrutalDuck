using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPoint;
    private CheckPointMove _checkPointMove;
    private Rigidbody _rigidBody;
    private TouchInput _touchInput;

    private void Awake()
    {
        _checkPointMove = _checkPoint.GetComponent<CheckPointMove>();
        _rigidBody = GetComponent<Rigidbody>();
        _touchInput = GetComponent<TouchInput>();
    }
    private void Update()
    {
        if ((_rigidBody.velocity == Vector3.zero) && (transform.position != _checkPoint.transform.position))
        {
            _checkPointMove.MoveCheckPoint(transform.gameObject);
        }

        if (_rigidBody.velocity != Vector3.zero)
        {
            _touchInput.enabled = false;
        }
        else
        {
            _touchInput.enabled = true;
        }
    }
}
