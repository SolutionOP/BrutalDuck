using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _finish;
    private float _totalDistance;

    private void Start()
    {
        _totalDistance = GetDistance(_car.transform.position, _finish.transform.position);  
    }
    public float GetDistance(Vector3 startPos, Vector3 endPos)
    {
        return Vector3.Magnitude(endPos - startPos);
    }

    public int CalculateDistancePercentage()
    {
        return 100 - (Mathf.RoundToInt((GetDistance(_car.transform.position, _finish.transform.position) * 100) / _totalDistance));
    }
}
