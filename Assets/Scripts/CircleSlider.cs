using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject sliderHandle;
    private Slider slider;
    private bool cursorOnSliderArea = false;
    public void OnPointerEnter(PointerEventData eventData) { cursorOnSliderArea = true; }
    public void OnPointerExit(PointerEventData eventData) { cursorOnSliderArea = false; }

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if (cursorOnSliderArea)
        {
            if (Input.GetMouseButton(0))
            {
                float angle = Vector3.Angle(Vector3.up, Input.mousePosition - transform.position);
                if (Input.mousePosition.x < transform.position.x)
                {
                    sliderHandle.transform.rotation = Quaternion.Euler(0, 0, angle);
                    slider.value = Mathf.Round((360 - angle) / 360 * (Mathf.Abs(slider.minValue) + Mathf.Abs(slider.maxValue)));
                    if (slider.value == 60)
                        slider.value = 0;
                }
                else
                {
                    sliderHandle.transform.rotation = Quaternion.Euler(0, 0, -angle);
                    slider.value = Mathf.Round(angle / 360 * (Mathf.Abs(slider.minValue) + Mathf.Abs(slider.maxValue)));
                }
            }
        }
    }
}
