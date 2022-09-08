using UnityEngine;
using TMPro;

public class DateButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    void Start()
    {
        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = SettingAlarm.dateTime.ToString("d");
    }
}
