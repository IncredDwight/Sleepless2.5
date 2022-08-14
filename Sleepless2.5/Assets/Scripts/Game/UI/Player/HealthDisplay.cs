using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    private Text _healthDisplay;

    private void Awake()
    {
        _healthDisplay = GetComponent<Text>();

        _playerHealth.OnHealthChanged += ChangeDisplay;

        ChangeDisplay(_playerHealth.GetMaxHealth());
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
