using System;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    public event Action ButtonClicked;

    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
}