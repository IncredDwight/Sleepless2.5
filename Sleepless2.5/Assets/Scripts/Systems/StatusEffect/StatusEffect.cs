using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    protected StatusEffectData _data;

    private bool _isAffecting;
    private float _nextEffect;
    private float _effectRate;
    private float _lifeTime;

    protected float _effectAmount;

    private void Update()
    {
        if (_isAffecting)
        {
            if (Time.time > _nextEffect)
            {
                Affect();
                _nextEffect = Time.time + _effectRate;
            }

            if (_lifeTime > 0)
                _lifeTime -= Time.deltaTime;
            else
                EndEffect();
        }


    }

    protected virtual void StartEffect()
    {
        _isAffecting = true;
    }

    protected virtual void EndEffect()
    {
        _isAffecting = false;
        Destroy(this);
    }

    protected virtual void Affect()
    {

    }

    public void SetData(StatusEffectData data)
    {
        _data = data;
        _lifeTime = _data.LifeTime;
        _effectRate = _data.EffectRate;
        _effectAmount = _data.EffectAmount;
        StartEffect();
    }

    public void ResetEffect()
    {
        _lifeTime = _data.LifeTime;
    }

}
