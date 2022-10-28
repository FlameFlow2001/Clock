using System.Collections.Generic;
using UnityEngine;

public static class AlarmList
{
    public static List<Alarm> alarms = new List<Alarm>();
    public static void ShowAlarmList()
    {
        string debugString = "";
        foreach (Alarm alarm in alarms)
            debugString += alarm.dateTime + "\n";
        Debug.Log(debugString);
    }
}
