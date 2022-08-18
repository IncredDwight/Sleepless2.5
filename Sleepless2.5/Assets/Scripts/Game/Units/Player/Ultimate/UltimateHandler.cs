using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IUltimate))]
public class UltimateHandler : MonoBehaviour
{
    public delegate void PowerAdded(float amount);
    public PowerAdded OnPowerAdded;

    [SerializeField] private float _requiredPowerAmount = 1000;
    private float _power;

    private IUltimate _ultimate;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _ultimate = GetComponent<IUltimate>();
        _playerInput = FindObjectOfType<PlayerInput>();
        GameEvents.OnUnitDied += AddPower;
    }

    private void Update()
    {
        if (_playerInput.GetUltimateKey() && _power >= _requiredPowerAmount)
        {
            _ultimate.Execute();
            _power = 0;
            OnPowerAdded?.Invoke(_power);
        }
    }

    private void AddPower(float amount)
    {
        _power += amount;
        if (_power >= _requiredPowerAmount)
            _power = _requiredPowerAmount;
        OnPowerAdded?.Invoke(_power / _requiredPowerAmount);
    }


}
