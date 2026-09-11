using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.ValueChanged += HandleValueChanged;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.ValueChanged -= HandleValueChanged;
    }

    private void HandleValueChanged(int value)
    {
        Debug.Log(value);
        if (_counterText != null)
            _counterText.text = value.ToString();
    }
}