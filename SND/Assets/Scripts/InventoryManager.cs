using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventoryItems = new List<Item>();
    public Canvas inventorycanvas;
    public GameObject inventorySlots;
    public Button DKB;
    public GameObject itemPanel;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Button close;
    public Button use;
    public Button item1;
    public Button item2;
    public Button item3;
    public Image itemImage;
    private Day8Action day8Action;
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
        DKB.gameObject.SetActive(false);
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
        DKB.onClick.AddListener(() => StartCoroutine(DKBcall()));
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
            Transform slot = inventorySlots.transform.GetChild(i);

            Image icon = slot.GetComponentInChildren<Image>();

            if (icon != null)
            {
                if (inventoryItems[i] != null && inventoryItems[i].icon != null)
                {
                    icon.sprite = inventoryItems[i].icon;
                    Color color = icon.color;
                    color.a = 1f;
                    icon.color = color;
                }
                else
                {
                    icon.sprite = null;
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(slot.GetComponent<RectTransform>());
        }

        for (int i = inventoryItems.Count; i < inventorySlots.transform.childCount; i++)
        {
            Transform slot = inventorySlots.transform.GetChild(i);
            Image icon = slot.GetComponentInChildren<Image>();
            if (icon != null)
            {
                icon.sprite = null; // 빈 슬롯의 이미지 제거
                Color color = icon.color;
                color.a = 0f;
                icon.color = color;
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
        itemImage.sprite = item.icon;

        Debug.Log(itemName);

        if (item.itemName == "초롱꽃" && Gamemanager.instance.day == 8)
        {
            use.gameObject.SetActive(true);

            GameObject dayActionObject = GameObject.Find("Day8Action");
            Day8Action day8Action = dayActionObject.GetComponent<Day8Action>();

            if (day8Action != null)
            {
                use.onClick.AddListener(() => StartCoroutine(day8Action.FadeInScreen()));
            }
        }
        else if (item.itemName == "수수떡" && Gamemanager.instance.day == 10)
        {
            use.gameObject.SetActive(true);
            //use.onClick.AddListener();
        }
    }
    public IEnumerator DKBcall()
    {
        // 도깨비 8일차인 경우에만 동작
        if (Gamemanager.instance.day == 8)
        {
            GameObject dayActionObject = GameObject.Find("Day8Action");
            Day8Action day8Action = dayActionObject?.GetComponent<Day8Action>();

            if (day8Action != null)
            {
                // DKBDialog 코루틴 실행
                yield return StartCoroutine(day8Action.DKBDialog());
            }
        }
        else
        {
            // 도깨비가 없을 경우
            Debug.Log("도깨비 없음");
        }
    }
}
