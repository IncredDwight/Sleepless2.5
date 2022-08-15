using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FillImage : MonoBehaviour
{
    [SerializeField] private float _fillTime = 1;
    private float _maxFill = 1;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount += Time.deltaTime * _maxFill / _fillTime;
    }

    public void ResetFill()
    {
        _image.fillAmount = 0;
    }

    public void SetFillTime(float time)
    {
        _fillTime = time;
        if (_fillTime < 0)
            _fillTime = 0;
    }
}
