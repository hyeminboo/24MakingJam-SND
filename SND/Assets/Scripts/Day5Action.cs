using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Day5Action : DayAction
{
    public GameObject DKB;
    public GameObject dialog;
    public TMP_Text speaker;
    public TMP_Text contentText;
    public GameObject optionBtn1;
    public GameObject optionBtn2;
    public TMP_Text option1;
    public TMP_Text option2;
    private bool isClickAllowed = true;
    private bool day5end;
    private int noCount = 0;

    private int currentContentIndex = 0;


    private string[] contents = {
        "line1",
        "line2",
        "line3"
    };
    void Start()
    {
        DKB.SetActive(false);
        dialog.SetActive(false);
        optionBtn1.SetActive(false);
        optionBtn2.SetActive(false);

    }
    public override IEnumerator PerformDayAction()
    {
        DKB.SetActive(true);
        dialog.SetActive(true);

        yield return StartCoroutine(DisplayTextOnClick());

        yield return new WaitUntil(() => day5end);
    }
    //content에 있는 대사 진행
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

        if (InventoryManager.instance.inventoryItems.Contains(Gamemanager.instance.item2))
        {

            optionBtn1.SetActive(true);
            option1.text = "Option1";
            optionBtn2.SetActive(true);
            option2.text = "Option2";
        }
        else
        {
            contentText.text = " ";
            day5end = true;
        }


    }
    public void giveMuk1()
    {
        contentText.text = "good";
        InventoryManager.instance.DKB.gameObject.SetActive(true);
        DKB.gameObject.SetActive(false);
        optionBtn1.SetActive(false);
        optionBtn2.SetActive(false);
        StartCoroutine(WaitforEnd());
    }
    public void dontgiveMuk1()
    {
        if (noCount != 1)
        {
            contentText.text = "bad";
            DKB.gameObject.SetActive(false);
            option1.text = "Option1";
            option2.text = "Option2";
            noCount++;
        }
        else
        {
            contentText.text = "bad";
            StartCoroutine(BacktoPrologue());
        }

    }
    private IEnumerator BacktoPrologue()
    {
        contentText.text = "line1";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("prologue");
    }
    private IEnumerator WaitforEnd()
    {
        yield return new WaitForSeconds(3f);
        day5end = true;
    }
}
