using UnityEngine;
using TMPro;

public class YearButton : MonoBehaviour
{
    public void ChangeYear()
    {
        int.TryParse(gameObject.GetComponentInChildren<TextMeshProUGUI>().text, out int year);
        SetDateCanvas.year = year;
    }
}