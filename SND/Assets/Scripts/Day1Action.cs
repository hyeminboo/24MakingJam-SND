using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day1Action : DayAction
{
    public Button flower;  // 꽃 버튼
    public Button Close;
    private string[] contents = {
        "line1",
        "line2",
        "line3"
    };
    public GameObject dialog;
    public GameObject itemPanel;
    public TMP_Text itemdescription;
    public TMP_Text contentText;
    private int currentContentIndex = 0;
    private bool isClickAllowed = true;
    private bool allTextDisplayed = false;
    private bool day1end = false;

    void Start()
    {
        flower.gameObject.SetActive(false);
        Close.gameObject.SetActive(false);
        dialog.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        itemdescription.text = "";
        flower.onClick.AddListener(OnFlowerButtonClick);
        Close.onClick.AddListener(ClosePanel);
        contentText.text = contents[currentContentIndex];
    }

    public override IEnumerator PerformDayAction()
    {
        flower.gameObject.SetActive(true);
        dialog.gameObject.SetActive(true);

        yield return StartCoroutine(DisplayTextOnClick());

        allTextDisplayed = true;
        yield return new WaitUntil(() => day1end);
    }

    private void OnFlowerButtonClick()
    {
        if (allTextDisplayed)
        {
            itemPanel.SetActive(true);
            itemdescription.text = "Flower";
            Close.gameObject.SetActive(true);
            Gamemanager.instance.OnItemButtonClick(1);
        }
    }
    private void ClosePanel()
    {
        itemPanel.SetActive(true);
        itemdescription.text = "Flower";
        day1end = true;
    }

    private IEnumerator DisplayTextOnClick()
    {
        while (currentContentIndex < contents.Length)
        {
            if (Input.GetMouseButtonDown(0) && isClickAllowed)
            {
                isClickAllowed = false;

                contentText.text = contents[currentContentIndex];
                currentContentIndex++;
                yield return new WaitForSeconds(0.5f);
                isClickAllowed = true;
            }

            yield return null;
        }

        dialog.SetActive(false);
        allTextDisplayed = true;
    }
}
