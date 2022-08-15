using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplayManager : MonoBehaviour
{
    [SerializeField] private StatusEffectDisplay _statusEffectDisplay;
    [SerializeField] private Transform _statusEffectDisplayParent;

    private Dictionary<StatusEffectData, StatusEffectDisplay> _statusEffectDisplays = new Dictionary<StatusEffectData, StatusEffectDisplay>();
    private PlayerStatusEffectHandler _playerStatusEffectHandler;

    private void Awake()
    {
        GameEvents.OnCharacterSpawned += SetHandler;
    }

    private void OnDisable()
    {
        GameEvents.OnCharacterSpawned -= SetHandler;
        _playerStatusEffectHandler.OnEffectApplied -= DisplayStatusEffect;
        _playerStatusEffectHandler.OnEffectRemoved -= RemoveStatusEffectDisplay;
        _playerStatusEffectHandler.OnEffectReseted -= ResetStatusEffect;
    }

    private void SetHandler(GameObject character)
    {
        _playerStatusEffectHandler = character.GetComponent<PlayerStatusEffectHandler>();
        _playerStatusEffectHandler.OnEffectApplied += DisplayStatusEffect;
        _playerStatusEffectHandler.OnEffectRemoved += RemoveStatusEffectDisplay;
        _playerStatusEffectHandler.OnEffectReseted += ResetStatusEffect;
    }

    private void DisplayStatusEffect(StatusEffectData data)
    {
        if (!_statusEffectDisplays.ContainsKey(data))
        {
            StatusEffectDisplay statusEffectDisplay = Instantiate(_statusEffectDisplay, _statusEffectDisplayParent);
            statusEffectDisplay.SetDisplay(data);
            _statusEffectDisplays.Add(data, statusEffectDisplay);
        }
    }

    private void RemoveStatusEffectDisplay(StatusEffectData data)
    {
        Destroy(_statusEffectDisplays[data].gameObject);
        _statusEffectDisplays.Remove(data);
    }

    private void ResetStatusEffect(StatusEffectData data)
    {
        _statusEffectDisplays[data].Reset();
    }
}
