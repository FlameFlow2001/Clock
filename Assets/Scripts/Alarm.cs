using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public DateTime dateTime;
    public AudioSource alarmSound;
    [SerializeField] private bool alarmEnabled = false;
    public Alarm(DateTime alarmDateTime)
    {
        dateTime = alarmDateTime;
    }

    public void Start()
    {
        alarmSound = GetComponent<AudioSource>();
    }
    public void DelayAlarm(int seconds)
    {
        DisableAlarm();
        dateTime = DateTime.Now.AddSeconds(seconds);
    }

    public void EnableAlarm()
    {
        alarmEnabled = true;
        alarmSound.Play();
    }

    public void DisableAlarm()
    {
        alarmEnabled = false;
        alarmSound.Stop();
    }
}
