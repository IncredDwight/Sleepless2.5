using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateButton : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    private UltimateHandler _ultimateHandler;

    private void Awake()
    {
        GameEvents.OnCharacterSpawned += SetUltimate;
    }

    private void UpdateFill(float amount)
    {
        Debug.Log("Fill update");
        _fillImage.fillAmount = 1 - amount;
    }

    private void SetUltimate(GameObject character)
    {
        _ultimateHandler = character.GetComponent<UltimateHandler>();
        _ultimateHandler.OnPowerAdded += UpdateFill;
    }
}
