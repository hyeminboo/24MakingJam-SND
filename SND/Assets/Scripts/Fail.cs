using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    public GameObject imageObject;
    public bool isDoorClickable = true;

    [SerializeField]
    private float imageDisplayTime = 2f;

    void Start()
    {
        isDoorClickable = true;
        imageObject.SetActive(false);
    }


    void OnMouseDown()
    {
        if (isDoorClickable)
        {
            StartCoroutine(DisplayImageAndProceed());
        }
    }

    private IEnumerator DisplayImageAndProceed()
    {
        // 이미지 활성화
        imageObject.SetActive(true);

        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(imageDisplayTime);

        // 이미지 비활성화
        imageObject.SetActive(false);

        // 다음 스테이지로 전환
        LoadNextScene();
    }

    private void LoadNextScene()
    {

        SceneManager.LoadScene("Prologue");

    }
}
