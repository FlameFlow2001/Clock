using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject secondClockArrow;
    [SerializeField] private GameObject minuteClockArrow;
    [SerializeField] private GameObject hourClockArrow;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dateText;
    private void Update()
    {
        secondClockArrow.transform.rotation = Quaternion.Euler(0, 0, DateTime.Now.Second * -6);
        minuteClockArrow.transform.rotation = Quaternion.Euler(0, 0, (DateTime.Now.Minute * -6) - (DateTime.Now.Second / 10f));
        hourClockArrow.transform.rotation = Quaternion.Euler(0,0, (DateTime.Now.Hour * -30) - (DateTime.Now.Minute / 2));
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
        dateText.text = DateTime.Now.ToString("d");
    }
}
