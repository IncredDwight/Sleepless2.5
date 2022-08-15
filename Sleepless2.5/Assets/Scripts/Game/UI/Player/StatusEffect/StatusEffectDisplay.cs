using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _statusEffectDisplayPrefab;
    [SerializeField] private Transform _statusEffectDisplayParent;

    private Dictionary<StatusEffectData, GameObject> _statusEffectDisplays = new Dictionary<StatusEffectData, GameObject>();
    private PlayerStatusEffectHandler _playerStatusEffectHandler;

    private void Awake()
    {
        GameEvents.OnCharacterSpawned += SetHandler;
    }

    private void OnDisable()
    {
        GameEvents.OnCharacterSpawned -= SetHandler;
        _playerStatusEffectHandler.OnEffectApplied -= Display;
        _playerStatusEffectHandler.OnEffectRemoved -= Remove;
        _playerStatusEffectHandler.OnEffectReseted -= Reset;
    }

    private void SetHandler(GameObject character)
    {
        _playerStatusEffectHandler = character.GetComponent<PlayerStatusEffectHandler>();
        _playerStatusEffectHandler.OnEffectApplied += Display;
        _playerStatusEffectHandler.OnEffectRemoved += Remove;
        _playerStatusEffectHandler.OnEffectReseted += Reset;
    }

    private void Display(StatusEffectData data)
    {
        if (!_statusEffectDisplays.ContainsKey(data))
        {
            GameObject statusEffectDisplay = Instantiate(_statusEffectDisplayPrefab, _statusEffectDisplayParent);
            statusEffectDisplay.transform.GetChild(0).GetComponent<Image>().sprite = data.Icon;
            statusEffectDisplay.GetComponentInChildren<FillImage>().SetFillTime(data.LifeTime);
            _statusEffectDisplays.Add(data, statusEffectDisplay);
        }
    }

    private void Remove(StatusEffectData data)
    {
        Destroy(_statusEffectDisplays[data]);
        _statusEffectDisplays.Remove(data);
    }

    private void Reset(StatusEffectData data)
    {
        _statusEffectDisplays[data].GetComponentInChildren<FillImage>().ResetFill();
    }
}
