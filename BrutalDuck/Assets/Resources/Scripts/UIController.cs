using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _tensionForceText;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _passedText;
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
}