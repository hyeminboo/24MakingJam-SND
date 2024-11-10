using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Day5Action : DayAction
{
    public TMP_FontAsset defaultFont;
    public TMP_FontAsset dokkaebi;

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

    private string[] speakers = { "", "", "도깨비", "도깨비" };
    private string[] contents = {
        "방 한 구석에서 누군가 중얼거리는 소리가 들린다. 어쩐지 으스스하다.",
        "가까이 다가가보니… 도깨비다. \n\n한 손에 들어오는 크기로 일렁거리는 게 생각보다 귀엽다.",
        "하여튼 꾸물거리긴. 배고파 돌아가시는 줄 알았다.",
        "맛있는 냄새가 나는데. 분명히 먹을거리를 가지고 있으렷다!"
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

                speaker.text = speakers[currentContentIndex];
                contentText.text = contents[currentContentIndex];

                if (speaker.text == "도깨비")
                {
                    speaker.font = dokkaebi;
                    contentText.font = dokkaebi;
                    contentText.fontSize = 40;
                }
                else
                {
                    contentText.font = defaultFont;
                    contentText.font = defaultFont;
                }

                currentContentIndex++;
                yield return new WaitForSeconds(0.5f);
                isClickAllowed = true;
            }

            yield return null;
        }

        if (InventoryManager.instance.inventoryItems.Contains(Gamemanager.instance.item2))
        {

            optionBtn1.SetActive(true);
            option1.text = "(메밀묵을 꺼내준다.)";
            optionBtn2.SetActive(true);
            option2.text = "없는데?";
        }
        else
        {
            speaker.text = "도깨비";
            contentText.text = "에잇 이번 판은 허탕이군. \n킁킁 냄새를 맡던 도깨비가 흥미를 잃고 사라진다. ";
            day5end = true;
        }


    }
    public void giveMuk1()

    {
        speaker.text = "도깨비";
        contentText.text = "고맙다는 인사도 없이 맛있게 먹어치우고는 아주 자연스럽게 봇짐에 올라탄다.";
        InventoryManager.instance.inventoryItems.Remove(Gamemanager.instance.item2);
        InventoryManager.instance.UpdateInventoryUI();

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
            speaker.text = "도깨비";
            contentText.text = "없는데는 반말이고 이놈아. \n어린 놈이 어디서 버릇없이 어른한테 반말을 지껄이느냐? \n여기까지 왔는데 거짓말하면 큰일난다는 걸 아직도 모르겠느냐?\n네 이놈 메밀묵을 가지고 있을텐데 어서 꺼내보거라.";
            DKB.gameObject.SetActive(false);
            option1.text = "(메밀묵을 꺼내준다.)";
            option2.text = "진짜 없는데요?";
            noCount++;
        }
        else
        {
            speaker.text = "";
            contentText.text = "나를 빤히 쳐다보던 도깨비의 입꼬리가 일그러진다. 그리고……";
            StartCoroutine(BacktoPrologue());
        }

    }
    private IEnumerator BacktoPrologue()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("prologue");
    }
    private IEnumerator WaitforEnd()
    {
        yield return new WaitForSeconds(3f);
        day5end = true;
    }
}
