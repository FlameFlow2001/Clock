using UnityEngine;

public class MonthButton : MonoBehaviour
{
    MonthSnapScroll monthSnapScroll;

    private void Start()
    {
        monthSnapScroll = GetComponentInParent<MonthSnapScroll>();
    }
    public void ChangeMonth()
    {
        SetDateCanvas.month = (SetDateCanvas.Months)monthSnapScroll.centerContentId+1;
    }
}
