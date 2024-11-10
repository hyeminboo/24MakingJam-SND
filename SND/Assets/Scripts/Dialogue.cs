using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject imageObject;

    // 대사를 배열로 선언
    public string[] dialogues;
    public string[] kkaebi;

    private int currentDialogueIndex = 0;

    // 대사를 출력할 UI 텍스트 컴포넌트
    public Text dialogueText;
    public Text kkaebiText;

    void Start()
    {   
        imageObject.SetActive(false);
        // 첫 번째 대사 출력
        if (dialogues.Length > 0)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    // 오브젝트 클릭 시 호출되는 함수
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(DisplayNextDialogue());
        }
    }

    private IEnumerator DisplayNextDialogue()
    {
        currentDialogueIndex++;
        
        if (currentDialogueIndex >= dialogues.Length)
        {   
            dialogueText.text = "";
            kkaebiText.text = kkaebi[0];

            imageObject.SetActive(true);

            yield return new WaitForSeconds(3f);


            LoadNextScene();
            yield break;
        }

        dialogueText.text = dialogues[currentDialogueIndex];
    }


    private void LoadNextScene() {

        kkaebiText.text = "";

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 16) {
            SceneManager.LoadScene("Prologue");
        }
    }

}


