using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    [SerializeField] private Slider minuteSlider;
    [SerializeField] private Slider secondSlider;
    private string alarmTimeString;
    void Start()
    {
        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = alarmTimeString;
    }

    public void SetHour(int changedHour)
    {
        if (changedHour >= 0 && changedHour < 24)
            SettingAlarm.hour = changedHour;
        else
            Debug.LogError("Hour is more than 23 or less than 0");
    }

    public void SetMinute(int changedMinute)
    {
        if (changedMinute >= 0 && changedMinute < 60)
            SettingAlarm.minute = changedMinute;
        else
            Debug.LogError("Minute is more than 59 or less than 0");
    }

    public void SetSecond(int changedSecond)
    {
        if (changedSecond >= 0 && changedSecond < 60)
            SettingAlarm.second = changedSecond;
        else
            Debug.LogError("Second is more than 59 or less than 0");
    }
    void Update()
    {
        SettingAlarm.minute = (int)minuteSlider.value;
        SettingAlarm.second = (int)secondSlider.value;
        alarmTimeString = SettingAlarm.hour.ToString("D2") + ":" + SettingAlarm.minute.ToString("D2") + ":" + SettingAlarm.second.ToString("D2");
        buttonText.text = alarmTimeString;
    }
}
