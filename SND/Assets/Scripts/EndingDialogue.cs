using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogue : MonoBehaviour
{
    public Canvas endingScene;
    public string[] dialogues;
    private int currentDialogueIndex = 0;

    // 대사를 출력할 UI 텍스트 컴포넌트
    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {   
        endingScene.gameObject.SetActive(false);
        if (dialogues.Length > 0)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogues.Length)
        {
            endingScene.gameObject.SetActive(true);
            return;
        }

        dialogueText.text = dialogues[currentDialogueIndex];
    }
}
