using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private BestResult _bestResultSO;
    [SerializeField] private MainMenuButtons _menuButtons;

    private void Start()
    {
        LoadData();
    }
    public void LoadSomeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("bestTime"))
        {
            _bestResultSO.ResultTime = PlayerPrefs.GetFloat("bestTime");
            _menuButtons.SetBestResult();
        }
    }
}
