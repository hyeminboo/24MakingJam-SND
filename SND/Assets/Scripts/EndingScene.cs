using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScene : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public string[] dialogues;
    private int currentDialogueIndex = 0;
    public float dialogueInterval = 2f;

    public Text dialogueText;


    void Start()
    {   
        dialogueCanvas.gameObject.SetActive(false);
        StartCoroutine(DisplayDialogueWithInterval());
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
}