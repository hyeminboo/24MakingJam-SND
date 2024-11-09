using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1Manager : MonoBehaviour
{
    //추후에 각 스테이지 별 알맞은 버튼 클릭 시 아이템 추가되는 형식으로 변경될 것
    public Button itemButton1;  // 아이템 1 추가 버튼

    public void getItem()
    {
        // 버튼 클릭 시 아이템 1 추가
        itemButton1.onClick.AddListener(() => Gamemanager.instance.OnItemButtonClick(1));
        Debug.Log("버튼1 눌림");
    }
}
