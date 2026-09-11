using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueChanged;

    [SerializeField] private MouseController mouseController;

    private int currentValue;
    private bool isRunning;
    private Coroutine countingCoroutine;

    private void OnEnable()
    {
        if (mouseController != null)
            mouseController.ButtonClicked += HandleButtonClicked;
    }

    private void OnDisable()
    {
        if (mouseController != null)
            mouseController.ButtonClicked -= HandleButtonClicked;
    }

    private void HandleButtonClicked()
    {
        isRunning = !isRunning;

        if (isRunning)
        {
            countingCoroutine = StartCoroutine(CountUp());
        }
        else
        {
            StopCoroutine(countingCoroutine);
        }
    }

    private IEnumerator CountUp()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(0.5f);
            currentValue++;
            ValueChanged?.Invoke(currentValue);
        }
    }
}