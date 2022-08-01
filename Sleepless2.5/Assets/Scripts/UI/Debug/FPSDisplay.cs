using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSDisplay : MonoBehaviour
{
    private Text _fpsText;
    private string _fpsTitle = " FPS";

    private float _pollingTime = 1;
    private float _time;
    private int _frameCount;

    private void Awake()
    {
        _fpsText = GetComponent<Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _frameCount++;

        if(_time >= _pollingTime)
        {
            int frameRate = Mathf.RoundToInt(_frameCount / _time);
            _fpsText.text = frameRate.ToString() + _fpsTitle;

            _time -= _pollingTime;
            _frameCount = 0;
        }
    }
}
