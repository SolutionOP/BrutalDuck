using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPoint;
    private TouchInput _touchInput;
    private CheckPointMove _checkPointMove;
    private Rigidbody _rigidBody;
    public bool IsTimeStoped = false;

    private void Awake()
    {
        _touchInput = GetComponent<TouchInput>();
        _checkPointMove = _checkPoint.GetComponent<CheckPointMove>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if ((_rigidBody.velocity == Vector3.zero) && (transform.position != _checkPoint.transform.position))
        {
            _checkPointMove.MoveCheckPoint(transform.gameObject);
        }

        if (_rigidBody.velocity != Vector3.zero || IsTimeStoped)
        {
            ChangeInputState(false);
        }
        else
        {
            ChangeInputState(true);
        }
    }

    public void ChangeInputState(bool state)
    {
        _touchInput.enabled = state;
    }
}
