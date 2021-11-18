using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //���콺 �̺�Ʈ�� �������� �ڵ�
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // ����
    public Player player; // �÷��̾� ������Ʈ
    public string itemName; //������ �̸�    
    public int mp; //�Ӵ� �Ŀ�

    public int level; //�������� ����
    public Text levelUi; //������ ���� UI


    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�� �������� ���� : " + price);
        BuyItem();
    }

    public void BuyItem()
    {
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

    public void LevelUp()
    {
        this.level++;
        levelUi.text = "Lv : " + this.level;
    }

    

    
}
