using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayDescription : MonoBehaviour
{
    public TMP_Text speaker;
    public TMP_Text content;
    public GameObject panel;
    private bool isDialogueEnded = false;


    private string[] speakers = { "영매", "", "", "첫 번째 혼령", "두 번째 혼령", "세 번째 혼령"};
    private string[] contents = { "여기가 어디지...?", "깊은 숲 속에서 길을 헤매던 영매. \n\n세 갈래로 나뉜 길 앞에 서있다.", "각 길목에서 혼령의 목소리가 들리고,\n\n혼령은 각 길에 대해 설명하지만 혼령의 말은 언제나 반만 진실이다.", "이 길로 가면 서낭당에 닿을테지만 내가 말하는대로는 하지 않는 게 좋을거요.", "이 길은 네놈이 찾는 길이 아니다. 하지만 두 번째 길을 따라가야 해.", "여기 있는 길들은 전부 허상이라네. 특히 첫 번째 길은 절대로 가면 안 돼." };
    private int currentIndex = 0;


    void Start()
    {
        UpdateDialogue();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDialogueEnded)
        {
            currentIndex++;

            if (currentIndex >= speakers.Length)
            {
                isDialogueEnded = true; // 대화 종료 설정
                panel.SetActive(false); // 패널 비활성화
            }
            else
            {
                UpdateDialogue();
            }
        }
    }
    void UpdateDialogue()
    {
        speaker.text = speakers[currentIndex];
        content.text = contents[currentIndex];
    }
    public void Spirit1()
    {
        ShowDialogue(speakers[3], contents[3]);
    }

    public void Spirit2()
    {
        ShowDialogue(speakers[4], contents[4]);
    }

    public void Spirit3()
    {
        ShowDialogue(speakers[5], contents[5]);
    }

    // 다이얼로그와 패널을 표시하고 7초 후 숨김
    private void ShowDialogue(string Name, string Content)
    {
        speaker.text = Name;
        content.text = Content;
        panel.SetActive(true); // 패널 활성화
        StopAllCoroutines(); // 이전 코루틴 중지 (다시 시작할 때)
        StartCoroutine(HidePanelAfterDelay(7f));
    }

    // 7초 후 패널 및 텍스트 비활성화
    private IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(false); // 패널 비활성화
        speaker.text = ""; // 이름 텍스트 초기화
        content.text = ""; // 내용 텍스트 초기화
    }
}
