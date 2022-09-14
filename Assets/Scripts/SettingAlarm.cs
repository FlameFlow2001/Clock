using UnityEngine;
using System;

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
    [SerializeField] static string dateTimeString;

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
            AlarmList.alarms.Sort();
            AlarmList.ShowAlarmList();
        }
    }
}
