using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentumCalculation : MonoBehaviour
{
    [SerializeField] private float _addForceValue;

    private float _halfScreen;

    private void Awake()
    {
        _halfScreen = Screen.height / 2;
    }

    public float GetMoveForceValue(float clampImpuls)
    {
        float force = clampImpuls / Screen.height;
        return force * _addForceValue;
    }

    public float GetClampImpuls(Vector2 startPos, Vector2 endPos)
    {
        float differentY = startPos.y - endPos.y;
        return Mathf.Clamp(differentY, 0, _halfScreen);
    }

    public float GetImpulsPercentage(float clampImpuls)
    {
        return (clampImpuls * 100) / _halfScreen;
    }
}
