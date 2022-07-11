using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthDisplay : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private TextMeshProUGUI _healthDisplay;

    private void Awake()
    {
        _healthDisplay = GetComponent<TextMeshProUGUI>();

        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerHealth.OnHealthChanged += ChangeDisplay;

        ChangeDisplay(_playerHealth.GetHealth());
    }

    public void ChangeDisplay(float health)
    {
        _healthDisplay.text = health.ToString();
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= ChangeDisplay;
    }
}
