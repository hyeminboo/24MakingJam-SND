using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpPaper : MonoBehaviour
{
    public GameObject paper;
    public GameObject papericon;
    public GameObject paper_rolled;
    public GameObject paper_unrolled;

    private bool isPaperOpen = false;

    void Start()
    {
        paper_rolled.SetActive(false);
        paper_unrolled.SetActive(false);
        papericon.SetActive(false);
    }

    public void Open()
    {
        paper.SetActive(false);
        paper_rolled.SetActive(true);
        isPaperOpen = true;
    }

    void Update()
    {
        if (isPaperOpen && Input.GetMouseButtonDown(0))
        {
            if (paper_rolled.activeSelf)
            {
                paper_rolled.SetActive(false);
                paper_unrolled.SetActive(true);
            }
            else
            {
                paper_unrolled.SetActive(false);
                papericon.SetActive(true);
                isPaperOpen = false;
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Stage1");
    }
}
