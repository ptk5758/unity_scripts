using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //���콺 �̺�Ʈ�� �������� �ڵ�
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // ����
    public Text priceUi; //���� Ui

    public Player player; // �÷��̾� ������Ʈ
    public string itemName; //������ �̸�    
    public int mp; //�Ӵ� �Ŀ�
    public int growMp; // �Ӵ� �Ŀ� ���� ��ġ

    public int level; //�������� ����
    public Text levelUi; //������ ���� UI

    public int[] prices; //������ ����
    public int maxLevel; //�ƽ� ����
    bool isMaxLevel; //�ƽ� ���� ���� �ƴ���


    private void Awake()
    {
        maxLevel = prices.Length;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�� �������� ���� : " + price);
        BuyItem();
    }

    public void BuyItem()
    {
        if (this.level == this.maxLevel) {
            Debug.Log("�̹� �ִ� ���׷��̵� �����Դϴ�");
            return;
        }

        if (this.price > player.money) {
            Debug.Log("�ܾ��� �����մϴ�");
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
            priceUi.text = this.price + "��";
        }
        
        if (level != 1) { 
            mp += growMp;
        }
        
    }

    

    
}
