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
        return clampImpuls * _addForceValue;
    }

    public float GetClampImpuls(Vector2 startPos, Vector2 endPos)
    {
        Vector2 directionVector = endPos - startPos;
        float resultMagnitude = directionVector.magnitude;
        return Mathf.Clamp(resultMagnitude, 0, _halfScreen);
    }

    public float GetImpulsPercentage(float clampImpuls)
    {
        return (clampImpuls * 100) / _halfScreen;
    }
}
