using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour
{
    public int buttonNumber;
    public GameObject buttonPrefab;
    public float spaceBetweenButtons;
    public float snapSpeed = 25f;
    [HideInInspector] public List<GameObject> instButtons = new List<GameObject>();
    protected List<Vector2> buttonPositions = new List<Vector2>();
    protected RectTransform contentRect;
    protected GameObject centerContent;
    [HideInInspector] public int centerContentId;
    protected bool scrollingNow;
    protected Vector2 contentVector;
    protected virtual void Start()
    {
        contentRect = GetComponent<RectTransform>();
        CreateContent();
        FillContent();
        centerContent = instButtons[centerContentId];
    }

    protected void Update()
    {
        if (scrollingNow)
        {
            FindCentralContent();
        }
        else
        {
            contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, buttonPositions[centerContentId].y, snapSpeed * Time.deltaTime);
            contentRect.anchoredPosition = contentVector;
        }
    }

    protected void CreateContent()
    {
        for (int i = 0; i < buttonNumber; i++)
        {
            instButtons.Add(Instantiate(buttonPrefab, transform, false));
            if (i > 0)
            {
                instButtons[i].transform.localPosition = new Vector2(instButtons[i - 1].transform.localPosition.x,
    instButtons[i - 1].transform.localPosition.y + buttonPrefab.GetComponent<RectTransform>().sizeDelta.y + spaceBetweenButtons);
            }
            buttonPositions.Add(-instButtons[i].transform.localPosition);
        }
    }

    protected virtual void ValueChangeFunctions()
    {
        PressCentralButton();
        SetDateCanvas.ChangeDaysInMonth();
    }

    protected void FindCentralContent()
    {
        float distanceCurrToCenter = Mathf.Abs(contentRect.anchoredPosition.y - buttonPositions[centerContentId].y);
        if (centerContentId > 0)
        {
            float distancePrevToCenter = Mathf.Abs(contentRect.anchoredPosition.y - buttonPositions[centerContentId - 1].y);
            if (distancePrevToCenter < distanceCurrToCenter)
            {
                centerContentId--;
                ValueChangeFunctions();
                return;
            }
        }

        if (centerContentId < instButtons.Count-1)
        {
            float distanceNextToCenter = Mathf.Abs(contentRect.anchoredPosition.y - buttonPositions[centerContentId + 1].y);
            if (distanceNextToCenter < distanceCurrToCenter)
            {
                centerContentId++;
                ValueChangeFunctions();
                return;
            }
        }
    }

    public void PressCentralButton()
    {
        instButtons[centerContentId].GetComponent<Button>().onClick.Invoke();
    }
    public void Scrolling(bool nowScrolling)
    {
        scrollingNow = nowScrolling;
    }
    protected virtual void FillContent() { }
}
