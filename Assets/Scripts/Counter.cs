using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputListener))]

public class Counter : MonoBehaviour
{
    [SerializeField] private int _counterIncrement = 1;
    [SerializeField] private float _incrementTimeWaitSec = 0.5f;

    private InputListener _inputListener;

    private bool _isActive = false;
    private int _countStartValue = 0;
    private int _countCurrentValue = 0;

    private Coroutine _activeCounterCoroutive;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _countCurrentValue = _countStartValue;
        ValueChanged?.Invoke(_countCurrentValue);
    }

    private void OnEnable()
    {
        _inputListener = GetComponent<InputListener>();
        _inputListener.LeftMouseClicked += HandleCounterCoroutine;
    }

    private void OnDisable()
    {
        _inputListener.LeftMouseClicked -= HandleCounterCoroutine;
    }

    private void HandleCounterCoroutine()
    {
        _isActive = !_isActive;

        if (_isActive == true && _activeCounterCoroutive == null)
        {
            _activeCounterCoroutive = StartCoroutine(IncrementCounterOnTimer());
        }
        else
        {
            StopCoroutine(_activeCounterCoroutive);
            _activeCounterCoroutive = null;
        }
    }

    private IEnumerator IncrementCounterOnTimer()
    {
        WaitForSeconds wait = new(_incrementTimeWaitSec);

        while (_isActive == true)
        {
            yield return wait;
            _countCurrentValue += _counterIncrement;
            ValueChanged?.Invoke(_countCurrentValue);
        }
    }  
}
