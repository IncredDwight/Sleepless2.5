using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, ITakeDamage, IHeal
{
    [SerializeField] private float _maxHealth;
    private float _health;

    public delegate void HealthChanged(float health);
    public event HealthChanged OnHealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Die();
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

    public float GetHealth()
    {
        return _health;
    }

    protected abstract void Die();
}
