using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventoryItems = new List<Item>();

    public Transform inventoryPanel;  // 인벤토리

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 변경되어도 유지
        }
        else
        {
            Destroy(gameObject);  // 중복 방지
        }
    }
    private void Start()
    {
        InitializeInventory();  // 인벤토리 초기화 메서드 호출
    }

    private void InitializeInventory()
    {
        // 인벤토리 초기화: 기본적으로 비워두기
        inventoryItems.Clear();  // 기존 아이템 제거
        UpdateInventoryUI();      // UI 업데이트
    }


    public void AddItem(Item newItem)
    {
        inventoryItems.Add(newItem);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        // 인벤토리 아이템을 UI에 반영
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            // 슬롯을 GameObject로 가져옴
            Transform slot = inventoryPanel.GetChild(i);

            // 슬롯의 하위에 있는 Image 컴포넌트 가져오기
            Image icon = slot.GetComponentInChildren<Image>();

            // 아이템의 아이콘을 해당 이미지 슬롯에 할당
            if (icon != null)
            {
                icon.sprite = inventoryItems[i].icon;
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(slot.GetComponent<RectTransform>());

        }

    }
}
