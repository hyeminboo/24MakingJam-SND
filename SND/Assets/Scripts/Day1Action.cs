using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day1Action : DayAction
{
    public Button flower;  // 꽃 버튼
    public Button Close;
    private string[] contents = {
        // "조심스레 들어가 보니 안쪽으로 통하는 문이 두 개가 있다.",
        // "각 문에는 부적이 붙어있는데 뭐라고 쓴 건지 도통 알아볼 수가 없다.",
        // "조금 더 가까이 다가가 부적을 건드리면 문이 큰 소리를 내며 닫힌다.",
        // "깜짝 놀라 뒤를 돌아보고 다시 부적을 보면 읽을 수 있는 글씨로 바뀌어있다."
        "방 가운데 환하게 반짝거리는 무언가가 있다.",
        "가까이 다가가보니… 하얀 초롱꽃이다. 챙겨볼까?",
        "(꽃 클릭 시 아이템 획득)"
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
            itemdescription.text = "하얀 초롱꽃. \n\n환하게 반짝거린다.";
            Close.gameObject.SetActive(true);
            Gamemanager.instance.OnItemButtonClick(1);
        }
    }
    private void ClosePanel()
    {
        itemPanel.SetActive(true);
        itemdescription.text = "하얀 초롱꽃. \n\n환하게 반짝거린다.";
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
