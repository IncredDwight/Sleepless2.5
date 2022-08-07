using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _heal = 25;
    [SerializeField] private Target _target = Target.Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHeal heal = collision.GetComponent<IHeal>();
        if(heal != null && collision.gameObject.CompareTag(_target.ToString()))
        {
            heal.Heal(_heal);
            Destroy(gameObject);
        }
    }
}
