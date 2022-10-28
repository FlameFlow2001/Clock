using UnityEngine;
using System;
using TMPro;

public class SettingAlarm : MonoBehaviour
{
    public enum Months { January = 1, February, March, April, May, June, Jule, August, September, October, November, December };
    public static DateTime dateTime;
    public static int year;
    [Range (1, 12)]
    public static Months month;
    [Range(1, 31)]
    public static int day;
    public static int hour;
    public static int minute;
    public static int second;
    public static int daysInMonth;
    public int alarmDelayTime = 300;
    [SerializeField] private GameObject settingTimeErrorWindow;
    [SerializeField] private TextMeshProUGUI settedTimeText;
    [SerializeField] private TextMeshProUGUI settedDateText;
    private void Awake()
    {
        year = DateTime.Now.Year;
        month = (Months)DateTime.Now.Month;
        day = DateTime.Now.Day;
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        dateTime = new DateTime(year, (int)month, day, hour, minute, second);
    }

    private void Update()
    {
        daysInMonth = DateTime.DaysInMonth(year, (int)month);
        if (day > daysInMonth)
            day = daysInMonth;
    }

    public void SettingDateTime()
    {
        dateTime = new DateTime(year, (int)month, day, hour, minute, second);
        if (dateTime > DateTime.Now)
        {
            AlarmList.alarms.Add(new Alarm(dateTime));
            AlarmList.ShowAlarmList();
            settedTimeText.text = AlarmList.alarms[0].dateTime.TimeOfDay.ToString();
            settedDateText.text = AlarmList.alarms[0].dateTime.Date.ToString("d");
        }
        else
        {
            Instantiate(settingTimeErrorWindow);
        }
    }

    public void DeleteAlarm()
    {
        if (AlarmList.alarms.Count > 0)
            AlarmList.alarms.RemoveAt(0);
    }

    public void DelayAlarm()
    {
        AlarmList.alarms[0].DelayAlarm(alarmDelayTime);
    }
}
