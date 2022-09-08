using UnityEngine;
using System;

public class SetDateCanvas : MonoBehaviour
{
    public enum Months { January = 1, February, March, April, May, June, Jule, August, September, October, November, December };
    public int year;
    public Months month;
    [Range(1,31)]
    public int day;
    public int daysInMonth;

    private void Start()
    {
        year = DateTime.Now.Year;
        month = (Months)DateTime.Now.Month;
        day = DateTime.Now.Day;
    }

    private void Update()
    {
        daysInMonth = DateTime.DaysInMonth(year, (int)month);
        if (day > daysInMonth)
            day = daysInMonth;
    }

    public void SetDate()
    {
        SettingAlarm.year = year;
        SettingAlarm.month = (SettingAlarm.Months)month;
        SettingAlarm.day = day;
    }
}
