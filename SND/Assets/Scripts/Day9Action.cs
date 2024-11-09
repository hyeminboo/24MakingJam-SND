using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Day9Action : DayAction
{
    public Button Tteok;  // 꽃 버튼
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
    private bool day9end = false;

    void Start()
    {
        Tteok.gameObject.SetActive(false);
        Close.gameObject.SetActive(false);
        dialog.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        itemdescription.text = "";
        Tteok.onClick.AddListener(OnTteokButtonClick);
        Close.onClick.AddListener(ClosePanel);
        contentText.text = contents[currentContentIndex];
    }

    public override IEnumerator PerformDayAction()
    {
        Tteok.gameObject.SetActive(true);
        dialog.gameObject.SetActive(true);

        yield return StartCoroutine(DisplayTextOnClick());

        allTextDisplayed = true;
        yield return new WaitUntil(() => day9end);
    }

    private void OnTteokButtonClick()
    {
        if (allTextDisplayed)
        {
            itemPanel.SetActive(true);
            itemdescription.text = "Tteok";
            Close.gameObject.SetActive(true);
            Gamemanager.instance.OnItemButtonClick(3);
        }
    }
    private void ClosePanel()
    {
        itemPanel.SetActive(true);
        itemdescription.text = "Flower";
        day9end = true;
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
