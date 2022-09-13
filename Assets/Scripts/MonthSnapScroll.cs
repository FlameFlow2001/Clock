using System;
using TMPro;

public class MonthSnapScroll : SnapScroll
{
    protected override void Start()
    {
        buttonNumber = 12;
        centerContentId = DateTime.Now.Month - 1;
        base.Start();
    }
    protected override void FillContent()
    {
        for (int i = 0; i < instButtons.Count; i++)
        {
            instButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = new DateTime(DateTime.Now.Year ,i+1, DateTime.Now.Day).ToString("MMM");
        }
    }
}
