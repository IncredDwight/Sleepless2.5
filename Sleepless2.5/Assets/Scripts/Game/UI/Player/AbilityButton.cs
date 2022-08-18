using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private FillImage _fillImage;
    private CooldownAbility _cooldownAbility;

    private void Awake()
    {
        _fillImage.enabled = false;
        GameEvents.OnCharacterSpawned += SetAbility;
    }

    private void UpdateFill(float cooldown)
    {
        _fillImage.enabled = true;
        _fillImage.SetFillTime(cooldown);
        _fillImage.ResetFill();
    }

    private void SetAbility(GameObject character)
    {
        _cooldownAbility = character.GetComponent<CooldownAbility>();
        _cooldownAbility.OnAbilityExecuted += UpdateFill;
    }

}
