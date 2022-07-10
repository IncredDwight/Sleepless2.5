using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IUltimate))]
public class UltimateHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _ultimateKey = KeyCode.U;
    [SerializeField] private float _requiredPowerAmount = 100;
    private float _power;

    private IUltimate _ultimate;

    private void Awake()
    {
        _ultimate = GetComponent<IUltimate>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_ultimateKey) && _power >= _requiredPowerAmount)
            _ultimate.Execute();
    }

    public void AddPower(float amount)
    {
        _power += amount;
        if (_power >= _requiredPowerAmount)
            _power = _requiredPowerAmount;
    }


}
