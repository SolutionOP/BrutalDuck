using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Text _bestTime;
    [SerializeField] private BestResult _bestResultSO;
    private MainSceneManager _mainSceneManager;

    private void Start()
    {
        SetBestResult();
        _mainSceneManager = FindObjectOfType<MainSceneManager>().gameObject.GetComponent<MainSceneManager>();
    }
    public void PlayButton()
    {
        _mainSceneManager.LoadSomeScene(1);
    }

    public void SetBestResult()
    {
        _bestTime.text = _bestResultSO.ResultTime.ToString("0.0000") + "s";
    }
}
