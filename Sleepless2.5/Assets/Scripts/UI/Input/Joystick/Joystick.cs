using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _joystickContainer;
    [SerializeField] private Image _joystickHandler;
    [SerializeField, Range(0, 1)] private float _joystickHandlerRadius = 0.5f;

    private Vector2 _direction;

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickHandler.rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 position);

        float x = position.x / _joystickContainer.rectTransform.sizeDelta.x;
        float y = position.y / _joystickContainer.rectTransform.sizeDelta.y;

        _direction = new Vector2(x, y);
        _direction = (_direction.magnitude > 1) ? _direction.normalized : _direction;

        _joystickHandler.rectTransform.anchoredPosition = new Vector3(_direction.x * _joystickContainer.rectTransform.sizeDelta.x * _joystickHandlerRadius, _direction.y * _joystickContainer.rectTransform.sizeDelta.y * _joystickHandlerRadius);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        _joystickHandler.rectTransform.anchoredPosition = Vector3.zero;
    }
}
