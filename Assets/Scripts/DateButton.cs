using UnityEngine;
using TMPro;
using System;

public class DateButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    void Start()
    {
        buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = SettingAlarm.dateTime.ToString("d");
    }

    public void UpdateDateButtonText()
    {
        buttonText.text = new DateTime(SettingAlarm.year, (int)SettingAlarm.month, SettingAlarm.day).ToString("d");
    }
}
