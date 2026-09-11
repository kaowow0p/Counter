using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private TextMeshProUGUI counterText;

    private void OnEnable()
    {
        counter.ValueChanged += HandleValueChanged;
    }

    private void OnDisable()
    {
        if (counter != null)
            counter.ValueChanged -= HandleValueChanged;
    }

    private void HandleValueChanged(int value)
    {
        Debug.Log(value);
        if (counterText != null)
            counterText.text = value.ToString();
    }
}