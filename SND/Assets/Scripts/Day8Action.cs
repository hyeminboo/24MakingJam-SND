using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day8Action : MonoBehaviour
{
    public GameObject dialog;
    public TMP_Text speaker;
    public TMP_Text contentText;
    private bool isClickAllowed = true;

    public TMP_FontAsset dokkaebi;
    public TMP_FontAsset defaultFont;
    public GameObject panel;
    private SpriteRenderer panelImage;
    public SpriteRenderer doorSpriteRenderer;
    public Sprite newDoorSprite;
    private int currentContentIndex = 0;
    public GameObject light1;
    public GameObject light2;
    public GameObject door1;
    public GameObject door2;
    public Sprite door1Sprite;
    public Sprite door2Sprite;


    private string[] speakers = { "도깨비", "", "" };
    private string[] contents = {
        "왜이렇게 귀찮게 구는 것이냐 머리가 있으면 생각이란걸 하란 말이다!",
        "봇짐을 뒤적거리더니 초롱꽃을 꺼내준다.",
    };

    void Start()
    {
        dialog.SetActive(false);

        panelImage = panel.GetComponent<SpriteRenderer>();
        if (panelImage == null)
        {
            Debug.LogError("패널에 SpriteRenderer 컴포넌트가 없습니다.");
            return;
        };

        StartCoroutine(StartSequence());
    }



    private IEnumerator StartSequence()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        yield return new WaitForSeconds(1f);
        Debug.Log("화면 어둡게");
        SetPanelAlpha(1);

        dialog.SetActive(true);
        contentText.text = "바람이 불어 호롱불이 꺼진다.\n\n캄캄한 어둠.\n\n아무것도 보이지 않는다.";
        yield return new WaitForSeconds(2f);
        dialog.SetActive(false);

    }

    private void SetPanelAlpha(float alpha)
    {
        Color panelColor = panelImage.color;
        panelColor.a = alpha;  // 알파 값만 조정
        panelImage.color = panelColor;
    }

    public IEnumerator FadeInScreen()
    {
        SpriteRenderer door1SpriteRenderer = door1.GetComponent<SpriteRenderer>();
        SpriteRenderer door2SpriteRenderer = door2.GetComponent<SpriteRenderer>();
        door1SpriteRenderer.sprite = door1Sprite;
        door2SpriteRenderer.sprite = door2Sprite;

        door1.SetActive(true);
        door2.SetActive(true);
        light1.SetActive(false);
        light2.SetActive(true);
        float duration = 1.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            SetPanelAlpha(Mathf.Lerp(1, 0, elapsedTime / duration));
            yield return null;
        }
        SetPanelAlpha(0);
        Debug.Log("다이얼로그");
        dialog.SetActive(true);
        speaker.font = defaultFont;
        contentText.font = defaultFont;
        speaker.text = "";
        contentText.text = "주변이 다시 환해진다.";
        Debug.Log("문 활성화");

        yield return new WaitForSeconds(0.5f);
        contentText.text = "문에 부적이 없다!!";
        yield return new WaitForSeconds(2f);
        contentText.text = "바람때문에 문에 붙어있어야 할 부적이 바닥에 떨어진 모양이다.이리저리 뒤섞여서 어느 문에 붙어있었는지도 모르겠다.";
        dialog.SetActive(false);
    }

    public IEnumerator DKBDialog()
    {
        yield return StartCoroutine(DisplayTextOnClick());
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeInScreen());


    }

    private IEnumerator DisplayTextOnClick()
    {
        while (currentContentIndex < contents.Length)
        {
            if (Input.GetMouseButtonDown(0) && isClickAllowed)
            {
                dialog.SetActive(true);
                isClickAllowed = false;
                speaker.text = speakers[currentContentIndex];
                contentText.text = contents[currentContentIndex];

                if (speaker.text == "도깨비")
                {
                    speaker.font = dokkaebi;
                    contentText.font = dokkaebi;
                }
                else
                {
                    speaker.font = defaultFont;
                    contentText.font = defaultFont;
                }

                currentContentIndex++;
                yield return new WaitForSeconds(0.5f);
                isClickAllowed = true;
            }

            yield return null;
        }

        dialog.SetActive(false);
    }
}
