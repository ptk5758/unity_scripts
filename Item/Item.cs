using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //마우스 이벤트를 가져오는 코드
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // 가격
    public Player player; // 플레이어 오브젝트
    public string itemName; //아이템 이름    
    public int mp; //머니 파워

    public int level; //아이템의 레벨
    public Text levelUi; //아이템 레벨 UI


    private void Awake()
    {

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

        player.money -= this.price;
        player.SetItem(this);        
        LevelUp();
    }

    public int GetMp()
    {
        return this.mp;
    }

    public void LevelUp()
    {
        this.level++;
        levelUi.text = "Lv : " + this.level;
    }

    

    
}
