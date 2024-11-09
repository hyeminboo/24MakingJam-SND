using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //추후에 각 스테이지 별 알맞은 버튼 클릭 시 아이템 추가되는 형식으로 변경될 것
    public Button itemButton1;  // 아이템 1 추가 버튼
    public Button itemButton2;  // 아이템 2 추가 버튼
    public Button itemButton3;

    void Start()
    {
        itemButton1.onClick.AddListener(() => OnItemButtonClick(1));
        itemButton2.onClick.AddListener(() => OnItemButtonClick(2));
        itemButton3.onClick.AddListener(() => OnItemButtonClick(3));
    }

    private void OnItemButtonClick(int itemIndex)
    {
        Debug.Log($"버튼 {itemIndex} 눌림");
        switch (itemIndex)
        {
            case 1:
                Gamemanager.instance.OnItemButtonClick(1); // 아이템 1 추가
                break;
            case 2:
                Gamemanager.instance.OnItemButtonClick(2); // 아이템 2 추가
                break;
            case 3:
                Gamemanager.instance.OnItemButtonClick(3); // 아이템 3 추가
                break;
            default:
                Debug.LogError("아이템 인덱스가 잘못되었습니다.");
                break;
        }
    }
}
