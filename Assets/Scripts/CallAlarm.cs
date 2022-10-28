using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAlarm : MonoBehaviour
{
    [SerializeField] private GameObject ringingAlarmCanvas;
    void Update()
    {
        if (AlarmList.alarms.Count > 0 && DateTime.Now.ToString() == AlarmList.alarms[0].dateTime.ToString())
        {
            ringingAlarmCanvas.SetActive(true);
            AlarmList.alarms[0].EnableAlarm();
        }
    }
}
