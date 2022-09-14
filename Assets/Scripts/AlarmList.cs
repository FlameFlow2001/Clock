using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class AlarmList : MonoBehaviour
{
    public static List<Alarm> alarms = new List<Alarm>();
    public static void ShowAlarmList()
    {
        string debugString = "";
        if (alarms.Count > 0)
        {
            foreach (Alarm alarm in alarms)
            {
                debugString += alarm.dateTime + "\n";
            }
            Debug.Log(debugString);
        }
    }
}
