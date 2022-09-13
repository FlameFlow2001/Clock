using TMPro;
using System;
using UnityEngine;

public class DaySnapScroll : SnapScroll
{
    protected override void Start()
    {
        centerContentId = DateTime.Now.Day - 1;
        base.Start();
    }
    protected override void FillContent()
    {
        for (int i = 0; i < instButtons.Count; i++)
        {
            instButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }

    protected override void ValueChangeFunctions()
    {
        base.ValueChangeFunctions();
        CheckNumOfButtons();
    }
    protected void CheckNumOfButtons()
    {
        int activeButtons = 0;
        for (int i = 0; i < buttonNumber; i++)
        {
            if (instButtons[i].activeSelf)
                activeButtons++;
        }

        if (SetDateCanvas.daysInMonth < activeButtons)
        {
            for (int i = buttonNumber-1; i >= SetDateCanvas.daysInMonth; i--)
                instButtons[i].SetActive(false);
        }

        if (SetDateCanvas.daysInMonth > activeButtons)
        {
            for (int i = activeButtons-1; i < SetDateCanvas.daysInMonth; i++)
                instButtons[i].SetActive(true);
        }

    }
}
