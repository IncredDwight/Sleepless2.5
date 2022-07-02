using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
   // private Vector2 _mouseInput;

    private void Update()
    {
        Vector2 _mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(_mouseInput.y, _mouseInput.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
