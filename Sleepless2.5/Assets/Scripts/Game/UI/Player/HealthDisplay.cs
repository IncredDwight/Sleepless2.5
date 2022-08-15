using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthDisplay : MonoBehaviour
{
    private Health _playerHealth;
    private Text _healthDisplay;

    private void Awake()
    {
        _healthDisplay = GetComponent<Text>();
        GameEvents.OnCharacterSpawned += SetHealth;
    }

    public void ChangeDisplay(float health)
    {
        _healthDisplay.text = health.ToString();
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= ChangeDisplay;
        GameEvents.OnCharacterSpawned -= SetHealth;
    }

    private void SetHealth(GameObject character)
    {
        _playerHealth = character.GetComponent<Health>();
        _playerHealth.OnHealthChanged += ChangeDisplay;

        ChangeDisplay(_playerHealth.GetMaxHealth());
    }
}
