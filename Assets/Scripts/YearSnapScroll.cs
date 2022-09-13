using System;
using TMPro;
public class YearSnapScroll : SnapScroll
{
    protected override void FillContent()
    {
        for (int i = 0; i < instButtons.Count; i++)
        {
            instButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (DateTime.Now.Year + i).ToString();
        }
    }
}
