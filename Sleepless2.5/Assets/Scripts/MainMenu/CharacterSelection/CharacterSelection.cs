using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private CharacterData[] _characters;

    private int _currentCharacterIndex;
    private int _maxCharacterIndex;

    private const string CharacterIndexSaveKey = "CharacterIndex";

    public delegate void CharacterChanged(CharacterData data);
    public event CharacterChanged OnCharacterChanged;

    private void Awake()
    {
        _maxCharacterIndex = _characters.Length - 1;
    }

    public void SelectLeft()
    {
        ChangeCharacterIndex(-1);
    }

    public void SelectRight()
    {
        ChangeCharacterIndex(1);
    }

    private void ChangeCharacterIndex(int amount)
    {
        _currentCharacterIndex += amount;
        if (_currentCharacterIndex < 0)
            _currentCharacterIndex = _maxCharacterIndex;
        if (_currentCharacterIndex > _maxCharacterIndex)
            _currentCharacterIndex = 0;

        PlayerPrefs.SetInt(CharacterIndexSaveKey, _currentCharacterIndex);

        OnCharacterChanged?.Invoke(_characters[_currentCharacterIndex]);
    }
}
