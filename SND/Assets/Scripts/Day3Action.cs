using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day3Action : DayAction
{
    public GameObject image;
    public GameObject dialog;
    public TMP_Text contentText;
    public Button yes;
    public Button no;
    private bool day3end = false;
    public Button Close;
    public GameObject itemPanel;
    public TMP_Text itemdescription;

    void Start()
    {
        image.gameObject.SetActive(false);
        dialog.gameObject.SetActive(false);
        contentText.text = "";
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        itemPanel.gameObject.SetActive(false);
        itemdescription.text = "";
        yes.onClick.AddListener(OnYesButtonClick);
        no.onClick.AddListener(OnNoButtonClick);
    }

    public override IEnumerator PerformDayAction()
    {
        // 이미지와 대화창 활성화
        image.SetActive(true);
        dialog.SetActive(true);
        contentText.text = "Eat or Not?";

        // 3초 뒤에 버튼을 활성화하는 코루틴 시작
        StartCoroutine(ActivateButtonsAfterDelay(3f));
        yield return new WaitUntil(() => day3end);
    }

    private IEnumerator ActivateButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        yes.gameObject.SetActive(true);
        no.gameObject.SetActive(true);
    }
    public void OnYesButtonClick()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        contentText.text = "Yum";
        day3end = true;

    }
    public void OnNoButtonClick()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        contentText.text = "Keep it";
        Gamemanager.instance.OnItemButtonClick(2);
        StartCoroutine(ItemDescription(1f));
    }
    private IEnumerator ItemDescription(float delay)
    {
        yield return new WaitForSeconds(delay);
        itemPanel.SetActive(true);
        itemdescription.text = "Muk";
    }
    public void ClosePanel()
    {
        day3end = true;
    }

}
