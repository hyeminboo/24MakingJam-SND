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
        isDoorClickable = false;

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
            default:
                yield return new WaitForSeconds(imageDisplayTime);
                imageObject.SetActive(false);
                break;
        }

        Gamemanager.instance.day++;

        isDoorClickable = true;
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < 15) {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }


}
