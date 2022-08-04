using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile, IPoolObject
{
    public GameObject Sender { get; set; }
    public Pool Pool { get; set; }

}
