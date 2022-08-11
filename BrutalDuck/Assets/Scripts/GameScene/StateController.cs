using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPoint;
    private TouchInput _touchInput;
    private CheckPointMove _checkPointMove;
    private Rigidbody _rigidBody;
    public bool IsTimeStoped;

    private void Awake()
    {
        IsTimeStoped = false;
        _touchInput = GetComponent<TouchInput>();
        _checkPointMove = _checkPoint.GetComponent<CheckPointMove>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if ((_rigidBody.velocity == Vector3.zero) && (transform.position != _checkPoint.transform.position))
        {
            _checkPointMove.MoveCheckPoint(this.gameObject);
        }

        if (IsTimeStoped || _rigidBody.velocity.z > 0.5f
            || _rigidBody.velocity.x > 0.5f || _rigidBody.velocity.y > 0.5f)
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
