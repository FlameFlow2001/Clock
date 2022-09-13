using UnityEngine;

public class DayButton : MonoBehaviour
{
    public DaySnapScroll daySnapScroll;
    private void Start()
    {
        daySnapScroll = GetComponentInParent<DaySnapScroll>();
    }

    public void ChangeDay()
    {
        SetDateCanvas.day = daySnapScroll.centerContentId + 1;
    }
}
