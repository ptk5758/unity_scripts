using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //마우스 이벤트를 가져오는 코드
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // 가격
    public Text priceUi; //가격 Ui

    public Player player; // 플레이어 오브젝트
    public string itemName; //아이템 이름    
    public int mp; //머니 파워
    public int growMp; // 머니 파워 성장 수치

    public int level; //아이템의 레벨
    public Text levelUi; //아이템 레벨 UI

    public int[] prices; //레벨별 가격
    public int maxLevel; //맥스 레벨
    bool isMaxLevel; //맥스 레벨 인지 아닌지


    private void Awake()
    {
        maxLevel = prices.Length;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이 아이탬의 가격 : " + price);
        BuyItem();
    }

    public void BuyItem()
    {
        if (this.level == this.maxLevel) {
            Debug.Log("이미 최대 업그레이드 상태입니다");
            return;
        }

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

    public virtual void LevelUp()
    {
        this.level++;
        
        if (this.level == this.maxLevel) {
            levelUi.text = "MAX";
            this.price = 0;
            priceUi.text = "MAX";
        } else {
            levelUi.text = "Lv : " + this.level;
            this.price = this.prices[this.level];
            priceUi.text = this.price + "원";
        }
        
        if (level != 1) { 
            mp += growMp;
        }
        
    }

    

    
}
