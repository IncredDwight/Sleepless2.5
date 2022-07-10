using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IAbility))]
public class CooldownAbility : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    private float _currentCooldown;

    [SerializeField] private KeyCode _abilityKey = KeyCode.C;

    private IAbility _ability;

    private void Awake()
    {
        _ability = GetComponent<IAbility>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_abilityKey) && _currentCooldown <= 0)
        {
            _ability.Execute();
            _currentCooldown = _cooldown;
        }

        if (_currentCooldown > 0)
            _currentCooldown -= Time.deltaTime;
    }
}
