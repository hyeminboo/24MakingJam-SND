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
        contentText.text = "메밀묵…? 제사를 지내고 남은 것 같다.\n머리를 썼더니 출출한데 먹을까? ";

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
        contentText.text = "맛있다. \n다음 수수께끼는 더 잘 풀 수 있을 것 같은 기분이 든다.";
        day3end = true;

    }
    public void OnNoButtonClick()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        contentText.text = "무슨 일이 생길지 모르니 일단은 챙겨가보자.";
        Gamemanager.instance.OnItemButtonClick(2);
        StartCoroutine(ItemDescription(1f));
    }
    private IEnumerator ItemDescription(float delay)
    {
        yield return new WaitForSeconds(delay);
        itemPanel.SetActive(true);
        itemdescription.text = "메밀묵 \n\n봇짐이 한층 더 고소해졌다.";
    }
    public void ClosePanel()
    {
        day3end = true;
    }

}
