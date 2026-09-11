using System;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    public event Action ButtonClicked;

    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
}