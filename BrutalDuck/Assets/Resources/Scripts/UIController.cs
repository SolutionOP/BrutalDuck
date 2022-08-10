using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _tensionForceText;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _passedText;
    [SerializeField] private GameObject _menuClaster;
    [SerializeField] private StateController _stateController;
    public bool IsFinish;
    private float _timerValue = 0f;


    private void Start()
    {
        IsFinish = true;
    }
    private void Update()
    {
        if (!IsFinish)
        {
            ChangeTimer(Time.deltaTime);
        }
        else
        {
            NullTimer();
        }
    }
    public void ChangeTensionForce(int impulsPercentage)
    {
        string tensionForce = "Tension Force: " + impulsPercentage.ToString() + "%";
        _tensionForceText.text = tensionForce;
    }

    private void ChangeTimer(float time)
    {
        _timerValue += time;
        _timeText.text = "Time: " + _timerValue.ToString("0.0000") + "s";
    }

    private void NullTimer()
    {
        _timeText.text = "Time: " + 0f + "s";
    }

    public void PauseGame()
    {
        _stateController.IsTimeStoped = true;
        _menuClaster.SetActive(true);
        ChangeTimeScale(0f);
    }

    private void ChangeTimeScale(float scaleValue)
    {
        Time.timeScale = scaleValue;
    }

    public void UnpauseGame()
    {
        _stateController.IsTimeStoped = false;
        _menuClaster.SetActive(false);
        ChangeTimeScale(1f);
    }
}