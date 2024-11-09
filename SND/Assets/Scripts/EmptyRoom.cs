using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyRoom : MonoBehaviour
{
    public GameObject imageObject;

    [SerializeField]
    private float imageDisplayTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        imageObject.SetActive(false);
    }
    // Update is called once per frame
    void OnMouseDown() {
        StartCoroutine(DisplayImageAndProceed());
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
        SceneManager.LoadScene("Empty Room");   
    }
}
