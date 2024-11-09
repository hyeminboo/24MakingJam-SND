using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    // 대사를 배열로 선언
    public string[] dialogues;
    private int currentDialogueIndex = 0;

    // 대사를 출력할 UI 텍스트 컴포넌트
    public Text dialogueText;

    void Start()
    {   
        // 첫 번째 대사 출력
        if (dialogues.Length > 0)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    // 오브젝트 클릭 시 호출되는 함수
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogues.Length)
        {
            LoadNextScene();
            return;
        }

        dialogueText.text = dialogues[currentDialogueIndex];
    }


    private void LoadNextScene() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 16) {
            SceneManager.LoadScene("SampleScene");
        }
    }

}


