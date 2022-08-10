using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPointObject;
    [SerializeField] private UIController _uiController;
    [SerializeField] private PhysicsMovement _physicsMovement;

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
            _uiController.IsFinish = true;
            SceneManager.LoadScene(0);
        }
    }
}
