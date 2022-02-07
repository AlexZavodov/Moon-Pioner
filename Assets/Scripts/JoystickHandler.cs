using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private Image joystickBackground;
    [SerializeField]
    private Image joustickArea;
    [SerializeField]
    private Image joystick;

    private Vector2 joystickBackgroundStartPosition;

    protected Vector2 inputVector;
    private void Awake()
    {
        joystickBackgroundStartPosition = joystickBackground.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * 2 / joystickBackground.rectTransform.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / joystickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 joystickBackgroundPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joustickArea.rectTransform, eventData.position, null, out joystickBackgroundPosition))
        {
            joystickBackground.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBackground.rectTransform.anchoredPosition = joystickBackgroundStartPosition;

        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
