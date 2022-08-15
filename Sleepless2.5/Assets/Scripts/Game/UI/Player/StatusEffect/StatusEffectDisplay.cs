using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectDisplay : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private FillImage _fillImage;

    public void SetDisplay(StatusEffectData data)
    {
        _image.sprite = data.Icon;
        _fillImage.SetFillTime(data.LifeTime);
    } 

    public void Reset()
    {
        _fillImage.ResetFill();
    }

}
