using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void IncreaseMovementSpeed(float amount);
    void DecreaseMovementSpeed(float amount);
    float GetMovementSpeed();
}
