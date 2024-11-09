using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayDescription : MonoBehaviour
{
    public TMP_Text name;
    public TMP_Text content;
    public GameObject panel;
    private bool isDialogueEnded = false;


    private string[] names = { "psychic", "spirit1", "spirit2", "spirit3" };
    private string[] contents = { "Where am I?", "spirit1 ~~", "spirit2", "spirit3" };
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

            if (currentIndex >= names.Length)
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
        name.text = names[currentIndex];
        content.text = contents[currentIndex];
    }
    public void Spirit1()
    {
        ShowDialogue(names[1], contents[1]);
    }

    public void Spirit2()
    {
        ShowDialogue(names[2], contents[2]);
    }

    public void Spirit3()
    {
        ShowDialogue(names[3], contents[3]);
    }

    // 다이얼로그와 패널을 표시하고 7초 후 숨김
    private void ShowDialogue(string Name, string Content)
    {
        name.text = Name;
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
        name.text = ""; // 이름 텍스트 초기화
        content.text = ""; // 내용 텍스트 초기화
    }
}
