using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerAttack))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKey;
    [SerializeField] private float _attackRate;

    private IPlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = GetComponent<IPlayerAttack>();
    }
}
