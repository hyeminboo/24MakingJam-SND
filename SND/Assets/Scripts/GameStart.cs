using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Image Title;
    public Button StartButton;
    public Button CreditButton;
    void Start()
    {
        SetAlpha(Title, 0f);
        SetAlpha(StartButton.image, 0f);
        SetAlpha(CreditButton.image, 0f);


        StartButton.gameObject.SetActive(false);
        CreditButton.gameObject.SetActive(false);

        StartCoroutine(ShowTitleAndButtons());
    }

    private IEnumerator ShowTitleAndButtons()
    {
        yield return new WaitForSeconds(3.5f);

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            SetAlpha(Title, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        StartButton.gameObject.SetActive(true);
        CreditButton.gameObject.SetActive(true);

        // StartButton 서서히 나타나기
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            SetAlpha(StartButton.image, alpha);
            yield return null;
        }

        // CreditButton 서서히 나타나기
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            SetAlpha(CreditButton.image, alpha);
            yield return null;
        }
    }

    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color color = graphic.color;
        color.a = alpha;
        graphic.color = color;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Prologue");
    }
}
