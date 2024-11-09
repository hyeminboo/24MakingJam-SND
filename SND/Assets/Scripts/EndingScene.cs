using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScene : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public GameObject panel;
    public GameObject imageObject;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    public float dialogueInterval = 2f;

    public Text dialogueText;

    private float changeDuration = 3.5f;

    void Start()
    {   
        imageObject.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
        StartCoroutine(StartChange());
        StartCoroutine(DisplayDialogueWithInterval());
    }

    private IEnumerator StartChange() {
        yield return new WaitForSeconds(changeDuration);
        StartCoroutine(ChangePanel());
    }

    private IEnumerator DisplayDialogueWithInterval()
    {

        // 대화 배열을 순회하면서 일정 간격으로 대사를 출력
        while (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            yield return new WaitForSeconds(dialogueInterval);  // 대사 간격만큼 대기

            currentDialogueIndex++;  // 다음 대사로 이동
        }
    }

    private IEnumerator ChangePanel() {
        imageObject.gameObject.SetActive(true);
        Color panelColor = panel.GetComponent<Image>().color;
        Color imageColor = imageObject.GetComponent<Image>().color;

        panelColor.a = 0f;
        imageColor.a = 0f;

        float startTime = Time.time;

        while (panelColor.a < 1f) {
            float timeElapsed = Time.time - startTime;
            float alphaValue = Mathf.Lerp(0f, 0.6f, timeElapsed / changeDuration);  // 시간에 비례하여 alpha 값 변화
            panelColor.a = alphaValue;
            imageColor.a = alphaValue;

            panel.GetComponent<Image>().color = panelColor;
            imageObject.GetComponent<Image>().color = imageColor;

            yield return null;
        }
    }

    
}