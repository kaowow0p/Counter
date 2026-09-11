using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueChanged;

    [SerializeField] private MouseController _mouseController;
    [SerializeField] private WaitForSeconds _wait = new WaitForSeconds(0.5f);

    private int _currentValue;
    private bool _isRunning;
    private Coroutine _countingCoroutine;

    private void OnEnable()
    {
        if (_mouseController != null)
            _mouseController.ButtonClicked += HandleButtonClicked;
    }

    private void OnDisable()
    {
        if (_mouseController != null)
            _mouseController.ButtonClicked -= HandleButtonClicked;
    }

    private void HandleButtonClicked()
    {
        _isRunning = !_isRunning;

        if (_isRunning)
        {
            _countingCoroutine = StartCoroutine(CountUp());
        }
        else
        {
            StopCoroutine(_countingCoroutine);
        }
    }

    private IEnumerator CountUp()
    {
        while (_isRunning)
        {
            yield return _wait;
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);
        }
    }
}