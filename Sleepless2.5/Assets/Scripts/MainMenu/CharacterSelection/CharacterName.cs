using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CharacterName : MonoBehaviour
{
    [SerializeField] private CharacterSelection _characterSelection;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _characterSelection.OnCharacterChanged += SetName;
    }

    private void SetName(CharacterData data)
    {
        _text.text = data.Name;
    }

    private void OnDestroy()
    {
        _characterSelection.OnCharacterChanged -= SetName;
    }
}
