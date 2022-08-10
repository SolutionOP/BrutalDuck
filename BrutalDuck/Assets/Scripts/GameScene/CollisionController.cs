using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPointObject;
    [SerializeField] private UIController _uiController;
    [SerializeField] private PhysicsMovement _physicsMovement;
    [SerializeField] private GameSceneManager _gameSceneManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _physicsMovement.NullVelocity();
            transform.position = _checkPointObject.transform.position;
            transform.rotation = _checkPointObject.transform.rotation;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _gameSceneManager.ReachedFinishLine();
            _uiController.IsFinish = true;
        }
    }
}
