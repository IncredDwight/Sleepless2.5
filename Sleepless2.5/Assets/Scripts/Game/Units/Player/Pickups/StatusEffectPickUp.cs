using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectPickUp : MonoBehaviour
{
    [SerializeField] private StatusEffectData _statusEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStatusEffectHandler playerStatusEffectHandler = collision.gameObject.GetComponent<PlayerStatusEffectHandler>();
        playerStatusEffectHandler?.ApplyEffect(_statusEffect);
    }
}
