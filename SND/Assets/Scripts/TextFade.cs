using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextFade : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;

    private TMP_Text[] texts;
    private int currentTextIndex = 0;
    private bool isFading = false;

    private void Start()
    {
        // 텍스트 배열 초기화 및 초기 투명도 설정
        texts = new TMP_Text[] { text1, text2, text3 };
        foreach (var text in texts)
        {
            SetTextAlpha(text, 0);
        }

        // 첫 번째 텍스트 페이드 인 시작
        StartCoroutine(AutoFadeSequence());
    }

    private void Update()
    {
        // 클릭 시 현재 텍스트를 즉시 나타내고, 다음 텍스트로 이동
        if (Input.GetMouseButtonDown(0))
        {
            if (isFading)
            {
                // 현재 텍스트를 즉시 완전히 표시하고 페이드 인 중지
                SetTextAlpha(texts[currentTextIndex], 1);
                StopAllCoroutines();
                isFading = false;

                // 다음 텍스트로 넘어가기 위해 다시 AutoFadeSequence 시작
                currentTextIndex++;
                StartCoroutine(AutoFadeSequence());
            }
        }
    }

    private IEnumerator AutoFadeSequence()
    {
        while (currentTextIndex < texts.Length)
        {
            isFading = true;
            yield return StartCoroutine(FadeInText(texts[currentTextIndex]));
            isFading = false;

            // 다음 텍스트로 이동 전 1초 대기
            yield return new WaitForSeconds(1f);
            currentTextIndex++;
        }

        // 모든 텍스트가 끝난 후 3초 대기 후 씬 전환
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("3WayWoods");
    }

    private IEnumerator FadeInText(TMP_Text text)
    {
        // 페이드 인 효과 (1초 동안)
        for (float alpha = 0; alpha <= 1; alpha += Time.deltaTime)
        {
            SetTextAlpha(text, alpha);
            yield return null;

            // 클릭 시 페이드 인을 중지하고 즉시 표시
            if (!isFading) yield break;
        }
    }

    private void SetTextAlpha(TMP_Text text, float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }

    public void SkipText()
    {
        SceneManager.LoadScene("3WayWoods");
    }
}
