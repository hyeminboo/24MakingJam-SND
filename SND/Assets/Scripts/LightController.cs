using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D; // Light2D 컴포넌트 참조
    public float minIntensity = 1.2f;  // 최소 조명 강도
    public float maxIntensity = 2f;  // 최대 조명 강도
    public float changeDuration = 0.15f;  // 조명 강도 변화에 걸리는 시간

    private void Start()
    {
        if (light2D == null)
        {
            light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        }

        StartCoroutine(ChangeLightIntensity());
    }

    private IEnumerator ChangeLightIntensity()
    {
        while (true)
        {

            float targetIntensity = Random.Range(minIntensity, maxIntensity);
            float initialIntensity = light2D.intensity;
            float elapsedTime = 0f;

            // changeDuration 동안 intensity 값을 점진적으로 변경
            while (elapsedTime < changeDuration)
            {
                elapsedTime += Time.deltaTime;
                light2D.intensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsedTime / changeDuration);
                yield return null;
            }

            // 다음 변경까지의 대기 시간 (1~5초 사이 랜덤)
            float waitTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
