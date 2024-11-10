using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ReadPaper : MonoBehaviour
{
    public static ReadPaper instance;

    public Button papericon;
    public GameObject paper_unrolled;
    public Canvas papercanvas;
    public TMP_Text rules;
    private Pass passScript;
    private Fail failScript;

    private bool isPaperOpen = false;

    void Start()
    {
        InitializeScripts();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (papercanvas != null)
            {
                DontDestroyOnLoad(papercanvas);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isPaperOpen && Input.GetMouseButtonDown(0))
        {
            paper_unrolled.SetActive(false);
            isPaperOpen = false;
        }
    }

    public void OpenAgain()
    {
        InitializeScripts();

        if (!isPaperOpen)
        {
            if (Gamemanager.instance != null && Gamemanager.instance.day == 4)
            {
                rules.text = "\n\n- 왼쪽 문의 쪽지는 방에 통로가 있으면 참이고,\n호랑이가 있으면 거짓이다.\n\n-오른쪽 방문의 쪽지는 방에 통로가 있으면 거짓이고,\n호랑이가 있으면 참이다.";

                paper_unrolled.SetActive(true);
                isPaperOpen = true;

                if (passScript != null)
                {
                    passScript.isDoorClickable = true;
                    failScript.isDoorClickable = true;
                }
                else
                {
                    Debug.LogError("Pass 스크립트가 초기화되지 않았습니다.");
                }
            }
            else if (Gamemanager.instance != null && Gamemanager.instance.day == 10)
            {
                rules.text = "\n\n- 왼쪽 문의 쪽지는 방에 통로가 있으면 참이고,\n호랑이가 있으면 거짓이다.\n\n-오른쪽 방문의 쪽지는 방에 통로가 있으면 거짓이고,\n호랑이가 있으면 참이다.";
                paper_unrolled.SetActive(true);
                isPaperOpen = true;
                if (passScript != null)
                {
                    passScript.isDoorClickable = true;
                    failScript.isDoorClickable = true;
                }
                else
                {
                    Debug.LogError("Pass 스크립트가 초기화되지 않았습니다.");
                }

            }
            else
            {
                paper_unrolled.SetActive(true);
                isPaperOpen = true;
            }
        }
    }

    private void InitializeScripts()
    {
        if (passScript == null)
        {
            GameObject passObject = GameObject.Find("Pass Door");
            if (passObject != null)
            {
                passScript = passObject.GetComponent<Pass>();

                if (passScript != null)
                {
                    Debug.Log("Pass 스크립트가 성공적으로 참조되었습니다.");
                }
                else
                {
                    Debug.LogError("Pass 스크립트가 해당 게임 오브젝트에 존재하지 않습니다.");
                }
            }
            else
            {
                Debug.LogError("Pass 오브젝트를 찾을 수 없습니다.");
            }
        }

        if (failScript == null)
        {
            GameObject failObject = GameObject.Find("Fail Door");
            if (failObject != null)
            {
                failScript = failObject.GetComponent<Fail>();

                if (failScript != null)
                {
                    Debug.Log("Fail 스크립트가 성공적으로 참조되었습니다.");
                }
                else
                {
                    Debug.LogError("Fail 스크립트가 해당 게임 오브젝트에 존재하지 않습니다.");
                }
            }
            else
            {
                Debug.LogError("Fail 오브젝트를 찾을 수 없습니다.");
            }
        }
    }
}
