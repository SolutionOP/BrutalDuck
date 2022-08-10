using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private BestResult _bestResultSO;

    private void Awake()
    {
        _bestResultSO.TmpResultTime = 0;
    }
    public void ReachedFinishLine()
    {
        if (_bestResultSO.TmpResultTime < _bestResultSO.ResultTime)
        {
            _bestResultSO.ResultTime = _bestResultSO.TmpResultTime;
        }
        LoadSomeScene(1);
    }

    public void LoadSomeScene(int sceneManager)
    {
        SceneManager.LoadScene(sceneManager);
    }
}
