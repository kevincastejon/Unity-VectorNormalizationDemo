using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickView : MonoBehaviour
{
    [SerializeField]
    private Transform _stickPoint;
    [SerializeField]
    private GameObject _squareBackground;
    [SerializeField]
    private GameObject _circleBackground;
    [SerializeField]
    private NormalizationType _normalizationType;

    private void Start()
    {
        if (_normalizationType == NormalizationType.NORMALIZE)
        {
            _squareBackground.SetActive(false);
        }
    }

    public void SetPoint(Vector2 point)
    {
        if (_normalizationType == NormalizationType.NORMALIZE || (_normalizationType == NormalizationType.CLAMP_AT_ONE && point.magnitude > 1f))
        {
            point = point.normalized;
        }
        _stickPoint.localPosition = point * 100;
    }
}
