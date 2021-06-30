using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum NormalizationType
{
    NONE,
    NORMALIZE,
    NORMALIZED_IF_ABOVE_ONE
}

public class Player : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _xLabel;
    [SerializeField]
    private TMP_Text _yLabel;
    [SerializeField]
    private TMP_Text _magnitude;
    [SerializeField]
    private StickView _stickView;
    

    [SerializeField]
    private NormalizationType _normalizationType;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_normalizationType == NormalizationType.NORMALIZE || (_normalizationType == NormalizationType.NORMALIZED_IF_ABOVE_ONE && _direction.magnitude > 1f))
        {
            _direction = _direction.normalized;
        }
        _xLabel.text = "X : " + _direction.x.ToString("F3");
        _yLabel.text = "Y : " + _direction.y.ToString("F3");
        _magnitude.text = "Magnitude : " + _direction.magnitude.ToString("F3");
        _stickView.SetPoint(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * 5f;
    }
}
