using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joysticBG;
    [SerializeField]
    private Image joystic;
    private Vector2 inputVector;


    private void Start()
    {
        joysticBG = GetComponent<Image>();
        joystic = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero; //set posittion to default
        joystic.rectTransform.anchoredPosition = Vector2.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos; //create local variable
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joysticBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joysticBG.rectTransform.sizeDelta.x);  //getting the coordinates of the touch position on the joystick
            pos.y = (pos.y / joysticBG.rectTransform.sizeDelta.y);  //getting the coordinates of the touch position on the joystick
            
            inputVector = new Vector2(pos.x * 2, pos.y * 2);  //setting precise touch coordinates
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystic.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joysticBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joysticBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        return Input.GetAxis("Horizontal");     
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        return Input.GetAxis("Vertical");
    }
}
