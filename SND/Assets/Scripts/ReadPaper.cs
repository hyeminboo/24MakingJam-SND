using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPaper : MonoBehaviour
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
        DontDestroyOnLoad(papericon);
    }

    public void Open()
    {
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
    public void OpenAgain()
    {
        paper_unrolled.SetActive(true);
        isPaperOpen = true;

        if (isPaperOpen && Input.GetMouseButtonDown(0))
        {
            paper_unrolled.SetActive(false);
            isPaperOpen = false;
        }
    }
}
