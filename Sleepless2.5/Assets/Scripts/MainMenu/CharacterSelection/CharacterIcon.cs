using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CharacterIcon : MonoBehaviour
{
    [SerializeField] private CharacterSelection _characterSelection;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _characterSelection.OnCharacterChanged += SetIcon;
    }

    private void SetIcon(CharacterData data)
    {
        _image.sprite = data.Sprite;
    }

    private void OnDestroy()
    {
        _characterSelection.OnCharacterChanged -= SetIcon;
    }
}
