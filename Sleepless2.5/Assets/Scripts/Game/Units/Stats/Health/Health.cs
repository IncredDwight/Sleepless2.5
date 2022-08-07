using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDie))]
public class Health : MonoBehaviour, ITakeDamage, IHeal
{
    [SerializeField] private float _maxHealth;
    private float _health;

    public delegate void HealthChanged(float health);
    public event HealthChanged OnHealthChanged;

    private IDie _death;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    private void Awake()
    {
        _death = GetComponent<IDie>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            _death.Die();
        }

        OnHealthChanged?.Invoke(_health);
    }

    public void Heal(float heal)
    {
        _health += heal;
        if (_health > _maxHealth)
            _health = _maxHealth;

        OnHealthChanged?.Invoke(_health);
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }
}
