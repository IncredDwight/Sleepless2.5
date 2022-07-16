using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IAbility))]
public class CountAbility : MonoBehaviour
{
    [SerializeField] private int _count;

    [SerializeField] private KeyCode _abilityKey = KeyCode.C;

    private IAbility _ability;

    private void Awake()
    {
        _ability = GetComponent<IAbility>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(_abilityKey) && _count > 0)
        {
            _ability.Execute();
            _count--;
        }
    }
}
