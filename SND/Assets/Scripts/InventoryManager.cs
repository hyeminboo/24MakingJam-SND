using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventoryItems = new List<Item>();
    public Canvas inventorycanvas;
    public Transform inventoryPanel;
    public GameObject DKB;
    public GameObject itemPanel;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Button close;
    public Button use;
    public Button item1;
    public Button item2;
    public Button item3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // InventoryManager는 씬 전환 후에도 유지됨

            // Canvas가 루트 오브젝트로서 유지되도록
            if (inventorycanvas != null)
            {
                DontDestroyOnLoad(inventorycanvas); // Canvas 유지
            }
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 인스턴스가 있으면 새 인스턴스를 삭제
        }
    }

    private void Start()
    {
        DKB.SetActive(false);
        itemPanel.SetActive(false);
        itemDescription.text = "";
        itemName.text = "";
        use.gameObject.SetActive(false);

        InitializeInventory();  // 인벤토리 초기화 메서드 호출
    }

    private void OnEnable()
    {
        item1.onClick.AddListener(() =>
        {
            Debug.Log("Item 1 clicked");
            UseItem(1);
        }); item2.onClick.AddListener(() => UseItem(2));
        item3.onClick.AddListener(() => UseItem(3));
        close.onClick.AddListener(() => itemPanel.SetActive(false));
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

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Transform slot = inventoryPanel.GetChild(i);

            Image icon = slot.GetComponentInChildren<Image>();

            if (icon != null)
            {
                if (inventoryItems[i] != null && inventoryItems[i].icon != null)
                {
                    icon.sprite = inventoryItems[i].icon;
                }
                else
                {
                    icon.sprite = null;
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(slot.GetComponent<RectTransform>());
        }

        for (int i = inventoryItems.Count; i < inventoryPanel.childCount; i++)
        {
            Transform slot = inventoryPanel.GetChild(i);
            Image icon = slot.GetComponentInChildren<Image>();
            if (icon != null)
            {
                icon.sprite = null; // 빈 슬롯의 이미지 제거
            }
        }
    }

    public void UseItem(int index)
    {

        if (index - 1 < 0 || index - 1 >= inventoryItems.Count)
        {
            itemPanel.SetActive(true);
            itemName.text = "";
            itemDescription.text = "no item";
            return;
        }
        itemPanel.SetActive(true);
        Item item = inventoryItems[index - 1];
        itemName.text = item.itemName;
        itemDescription.text = item.description;

        Debug.Log(itemName);

        if (item.itemName == "초롱꽃" && Gamemanager.instance.day == 8)
        {
            use.gameObject.SetActive(true);
            //use.onClick.AddListener();
        }
        else if (item.itemName == "수수떡" && Gamemanager.instance.day == 10)
        {
            use.gameObject.SetActive(true);
            //use.onClick.AddListener();
        }
    }
    public void DKBcall()
    {
        //도꺠비 8일차 아니면 반응 X
        if (Gamemanager.instance.day == 8)
        {

        }
        else
        {

        }
    }
}
