using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IAbility))]
public class CooldownAbility : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    private float _currentCooldown;

    private PlayerInput _playerInput;
    private IAbility _ability;

    private void Awake()
    {
        _ability = GetComponent<IAbility>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput.GetAbilityKey() && _currentCooldown <= 0)
        {
            _ability.Execute();
            _currentCooldown = _cooldown;
        }

        if (_currentCooldown > 0)
            _currentCooldown -= Time.deltaTime;
    }
}
