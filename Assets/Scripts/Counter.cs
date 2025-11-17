using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    private int _countStartValue = 0;
    private int _countCurrentValue = 0;

    public int CountStartValue => _countStartValue;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _countCurrentValue = _countStartValue;
    }

    public void IncrementCount(int value)
    {
        _countCurrentValue += value;
        ValueChanged?.Invoke(_countCurrentValue);
    }   
}
