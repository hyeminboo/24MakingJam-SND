using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScene : MonoBehaviour
{
    //public Canvas dialogueCanvas;
    public GameObject panel;
    public GameObject imageObject;
    public GameObject imageym;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    public float dialogueInterval = 2f;

    public Text dialogueText;

    private float changeDuration = 3.5f;

    void Start()
    {   
        imageym.gameObject.SetActive(false);
        imageObject.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        //dialogueCanvas.gameObject.SetActive(false);
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

    private IEnumerator ChangePanel()
    {
        imageym.gameObject.SetActive(true);

        Color ymColor = imageym.GetComponent<Image>().color;
        Color panelColor = panel.GetComponent<Image>().color;
        Color imageColor = imageObject.GetComponent<Image>().color;

        // 초기 알파 값 설정
        ymColor.a = 0f;
        panelColor.a = 0f;
        imageColor.a = 0f;

        float startTime = Time.time;
        float ymFadeDuration = changeDuration; // ymimage가 나타나는 시간 설정

        // 1단계: ymimage 알파 값 변화 (빠르게 나타나기)
        while (ymColor.a < 1f)
        {
            float timeElapsed = Time.time - startTime;
            float ymAlphaValue = Mathf.Lerp(0f, 1f, timeElapsed / ymFadeDuration);
            ymColor.a = ymAlphaValue;
            imageym.GetComponent<Image>().color = ymColor;

            yield return null;
        }

        yield return new WaitForSeconds(9f);

        imageObject.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        // 2단계: panel과 imageObject 알파 값 변화 (천천히 나타나기)
        startTime = Time.time;  // panel과 imageObject 알파 변화 시작 시간을 새로 설정


        while (panelColor.a < 0.6f)
        {
            float timeElapsed = Time.time - startTime;
            float alphaValue = Mathf.Lerp(0f, 0.6f, timeElapsed / changeDuration);
            float fade = Mathf.Lerp(1f, 0f, timeElapsed / changeDuration);
            ymColor.a = fade;
            panelColor.a = alphaValue;
            imageColor.a = alphaValue;

            imageym.GetComponent<Image>().color = ymColor;
            panel.GetComponent<Image>().color = panelColor;
            imageObject.GetComponent<Image>().color = imageColor;

            yield return null;
        }

    }

    
}