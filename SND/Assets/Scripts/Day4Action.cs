using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day4Action : MonoBehaviour
{
    public float blinkInterval = 0.5f;  // 깜빡임 간격
    public float blinkDuration = 5f;    // 깜빡임 지속 시간
    private float originalAlpha;
    private Button papaericon;
    private Image papaericonImage; // 버튼의 Image 컴포넌트
    private Pass passScript;
    private Fail failScript;

    void Start()
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

        passScript.isDoorClickable = false;
        failScript.isDoorClickable = false;
        Debug.Log("클릭 못함");

        papaericon = ReadPaper.instance.papericon;
        papaericonImage = papaericon.GetComponent<Image>(); // 버튼의 Image 컴포넌트 가져오기

        // 원래 알파 값 저장 (기본 알파 값)
        originalAlpha = papaericonImage.color.a;

        // 깜빡임 시작
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f; // 시간 추적 변수
        Color btnColor = papaericonImage.color; // 버튼의 현재 색상

        while (elapsedTime < blinkDuration)
        {
            // 알파 값을 0으로 설정하여 버튼을 숨김
            btnColor.a = 0f;
            papaericonImage.color = btnColor;

            // 지정된 간격만큼 대기
            yield return new WaitForSeconds(blinkInterval);

            // 알파 값을 1로 설정하여 버튼을 보임
            btnColor.a = originalAlpha;
            papaericonImage.color = btnColor;

            // 다시 대기
            yield return new WaitForSeconds(blinkInterval);

            // 경과 시간 업데이트
            elapsedTime += blinkInterval * 2; // 두 번의 대기 시간 합산
        }
    }

    public void StopBlinking()
    {
        // 깜빡임을 멈추고 알파 값을 원래 상태로 복원
        StopCoroutine(BlinkEffect());
        Color btnColor = papaericonImage.color;
        btnColor.a = originalAlpha;
        papaericonImage.color = btnColor;
    }
}
