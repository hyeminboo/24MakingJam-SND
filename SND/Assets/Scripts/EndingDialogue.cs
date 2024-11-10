using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialogue : MonoBehaviour
{
   
    public GameObject dialog;
    public TMP_FontAsset defaultFont;
    public TMP_FontAsset dokkaebi;

    public TMP_Text speaker;
    public TMP_Text contentText;

    private int currentContentIndex = 0;

    public GameObject endingSceneObject;

    private string[] speakers = { "도깨비", "", "", "도깨비" };
    private string[] contents = {
        "네 놈이 이 문을 열기까지 꼬박 천 년이 걸렸다.\n이제 옳고 그름을 구분할 줄 알겠느냐?",
        "천 년...?",
        "저는 오늘 새벽에야 이 곳에 당도했습니다.\n오랫동안 산군 님을 찾아 해매었으니 부디 만나게 해 주십시오.",
        "아직도 네가 누군지 모르겠느냐?"
    };

    void Start() {
        StartCoroutine(DisplayTextOnClick());
    }


        
    private IEnumerator DisplayTextOnClick()
    {
        while (currentContentIndex < contents.Length)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialog.SetActive(true);
                speaker.text = speakers[currentContentIndex];
                contentText.text = contents[currentContentIndex];

                if (speaker.text == "도깨비")
                {
                    speaker.font = dokkaebi;
                    contentText.font = dokkaebi;
                    speaker.fontSize = 44;
                    contentText.fontSize = 40;
                }
                else
                {
                    speaker.font = defaultFont;
                    contentText.font = defaultFont;
                    speaker.fontSize = 40;
                    contentText.fontSize = 36;
                }

                currentContentIndex++;
                yield return new WaitForSeconds(3f);
            }

            yield return null;
        }

        dialog.SetActive(false);
        endingSceneObject.SetActive(true);
        // EndingScene의 StartChange 코루틴 실행
        endingSceneObject.GetComponent<EndingScene>().StartCoroutine("StartChange");
    }
        // endingCanvas.SetActive(true);
        // DisplayNextDialogue();
}

    

    // void DisplayNextDialogue()
    // {
    //     if (Input.GetMouseButtonDown(0)) {
    //         DisplayNextDialogue();
    //     }

    //     currentDialogueIndex++;

    //     if (currentDialogueIndex >= dialogues.Length)
    //     {
    //         endingCanvas.gameObject.SetActive(true);
    //         return;
    //     }

    //     dialogueText.text = dialogues[currentDialogueIndex];
    // }
    

