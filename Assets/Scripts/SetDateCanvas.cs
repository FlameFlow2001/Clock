using UnityEngine;
using System;

public class SetDateCanvas : MonoBehaviour
{
    public enum Months { January = 1, February, March, April, May, June, Jule, August, September, October, November, December };
    public static int year;
    public static Months month;
    [Range(1,31)]
    public static int day;
    public static int maxDaysInMonth = 31;
    public static int daysInMonth;
    private void Start()
    {
        InitializeDateCanvas();
    }
    public static void InitializeDateCanvas()
    {
        year = DateTime.Now.Year;
        month = (Months)DateTime.Now.Month;
        day = DateTime.Now.Day;
        daysInMonth = DateTime.DaysInMonth(year, (int)month);
    }

    public static void ChangeDaysInMonth()
    {
        daysInMonth = DateTime.DaysInMonth(year, (int)month);
        if (day > daysInMonth)
            day = daysInMonth;
    }
    public static void SetDate()
    {
        SettingAlarm.year = year;
        SettingAlarm.month = (SettingAlarm.Months)month;
        SettingAlarm.day = day;
    }
}
