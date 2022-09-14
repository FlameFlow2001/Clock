using UnityEngine;
using System;

public class Alarm : MonoBehaviour
{
    public DateTime dateTime;
    public Alarm(DateTime alarmDateTime)
    {
        dateTime = alarmDateTime;
    }

    public int CompareTo(Alarm obj)
    {
        if (obj == null) return 1;

        Alarm otherAlarm = obj as Alarm; ;
        if (otherAlarm != null)
            return dateTime.CompareTo(otherAlarm.dateTime);
        else
            throw new ArgumentException("Object is not a Alarm");
    }
}
