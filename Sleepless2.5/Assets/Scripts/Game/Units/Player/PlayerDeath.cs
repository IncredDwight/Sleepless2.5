
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDie
{
    public void Die()
    {
        Debug.Log("Player is dead");
    }
}
