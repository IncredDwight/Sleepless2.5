using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _statusEffectDisplayPrefab;
    [SerializeField] private Transform _statusEffectDisplayParent;

    private PlayerStatusEffectHandler _playerStatusEffectHandler;

    private void Awake()
    {
        GameEvents.OnCharacterSpawned += SetHandler;
    }

    private void OnDisable()
    {
        GameEvents.OnCharacterSpawned -= SetHandler;
    }

    private void SetHandler(GameObject character)
    {
        _playerStatusEffectHandler = character.GetComponent<PlayerStatusEffectHandler>();
        _playerStatusEffectHandler.OnEffectApplied += Display;
    }

    private void Display(StatusEffectData data)
    {
        GameObject statusEffectDisplay = Instantiate(_statusEffectDisplayPrefab, _statusEffectDisplayParent);
        statusEffectDisplay.transform.GetChild(0).GetComponent<Image>().sprite = data.Icon;
    }
}
