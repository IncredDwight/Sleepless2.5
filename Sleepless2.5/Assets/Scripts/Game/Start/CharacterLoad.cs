using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
    [SerializeField] private GameObject[] _characterPrefabs;

    private const string CharacterIndexSaveKey = "CharacterIndex";

    private void Start()
    {
        GameObject character = Instantiate(_characterPrefabs[PlayerPrefs.GetInt(CharacterIndexSaveKey)], Vector3.zero, Quaternion.identity);
        GameEvents.SendCharacterSpawned(character);
    }


}
