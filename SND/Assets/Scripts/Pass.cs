// Pass.cs
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pass : MonoBehaviour
{
    public GameObject imageObject;
    public bool isDoorClickable = true;

    private Day1Action day1Action;
    private Day3Action day3Action;
    private Day5Action day5Action;
    private Day9Action day9Action;

    private Fail failScript;
    private GameObject[] failObjects;

    [SerializeField]
    private float imageDisplayTime = 2f;

    void Start()
    {
        isDoorClickable = true;
        imageObject.SetActive(false);
        TryFindFailScript();
    }

    void TryFindFailScript()
    {
        // "FailDoor" 태그를 가진 모든 오브젝트를 찾음
        failObjects = GameObject.FindGameObjectsWithTag("Fail Door");

        if (failObjects.Length > 0)
        {
            foreach (GameObject failObject in failObjects)
            {
                Fail failScript = failObject.GetComponent<Fail>();
                if (failScript != null)
                {
                    failScript.isDoorClickable = false;
                    Debug.Log("Fail Door 스크립트가 성공적으로 참조되었습니다.");
                }
                else
                {
                    Debug.LogError("FailDoor 오브젝트에서 Fail 스크립트를 찾을 수 없습니다.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Fail Door 오브젝트를 찾을 수 없습니다.");
        }
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
        isDoorClickable = false;

        // failObjects 배열을 사용하는 부분
        if (failObjects != null)
        {
            foreach (GameObject failObject in failObjects)
            {
                Fail failScript = failObject.GetComponent<Fail>();
                if (failScript != null)
                {
                    failScript.isDoorClickable = false;
                }
            }
        }

        Debug.Log("문선택" + Gamemanager.instance.day);

        imageObject.SetActive(true);
        GameObject dayActionObject = null;
        switch (Gamemanager.instance.day)
        {
            case 1:
                dayActionObject = GameObject.Find("Day1Action");
                day1Action = dayActionObject.GetComponent<Day1Action>();
                if (day1Action != null)
                {
                    yield return StartCoroutine(day1Action.PerformDayAction());
                }
                break;
            case 3:
                dayActionObject = GameObject.Find("Day3Action");
                day3Action = dayActionObject.GetComponent<Day3Action>();
                if (day3Action != null)
                {
                    yield return StartCoroutine(day3Action.PerformDayAction());
                }
                break;
            case 5:
                dayActionObject = GameObject.Find("Day5Action");
                day5Action = dayActionObject.GetComponent<Day5Action>();
                if (day5Action != null)
                {
                    yield return StartCoroutine(day5Action.PerformDayAction());
                }
                break;
            case 9:
                dayActionObject = GameObject.Find("Day9Action");
                day9Action = dayActionObject.GetComponent<Day9Action>();
                if (day9Action != null)
                {
                    yield return StartCoroutine(day9Action.PerformDayAction());
                }
                break;
            default:
                yield return new WaitForSeconds(imageDisplayTime);
                imageObject.SetActive(false);
                break;
        }

        Gamemanager.instance.day++;

        isDoorClickable = true;

        if (failObjects != null)
        {
            foreach (GameObject failObject in failObjects)
            {
                Fail failScript = failObject.GetComponent<Fail>();
                if (failScript != null)
                {
                    failScript.isDoorClickable = true;
                }
            }
        }

        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < 15)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
