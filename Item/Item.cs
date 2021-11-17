using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //마우스 이벤트를 가져오는 코드
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // 가격
    public Text priceUi; // 가격표
    public Player player; // 플레이어 오브젝트
    public string itemName; //아이템 이름
    public Text itemNameUi; //아이템 이름 TEXT
    bool isBuy; //아이템을 삿는지 안삿는지

    public int mp; //머니 파워

    private void Awake()
    {
        priceUi.text = this.price + " 원";
        itemNameUi.text = this.itemName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이 아이탬의 가격 : " + price);
        BuyItem();
    }

    public void BuyItem()
    {
        if (this.price > player.money) {
            Debug.Log("잔액이 부족합니다");
            return;
        }

        if (this.isBuy) {
            Debug.Log("이미 구매한 상품 입니다");
            return;
        }

        player.money -= this.price;
        player.SetItem(this);
        isBuy = true;
    }

    public int GetMp()
    {
        return this.mp;
    }

    

    
}
