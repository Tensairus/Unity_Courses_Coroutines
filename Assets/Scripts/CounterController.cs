using System.Collections;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private int _counterIncrement = 1;
    [SerializeField] private float _incrementTimeWaitSec = 0.5f;

    public bool _isActive = false;

    private Coroutine _activeCounterCoroutive;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;

            HandleCounterCoroutines();
        }
    }

    private void HandleCounterCoroutines()
    {
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

    public IEnumerator IncrementCounterOnTimer()
    {
        while(_isActive == true)
        {
            yield return new WaitForSeconds(_incrementTimeWaitSec);
            _counter.IncrementCount(_counterIncrement);            
        }
    }
}