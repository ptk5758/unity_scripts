using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //���콺 �̺�Ʈ�� �������� �ڵ�
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler
{
    public int price; // ����
    public Text priceUi; // ����ǥ
    public Player player; // �÷��̾� ������Ʈ
    public string itemName; //������ �̸�
    public Text itemNameUi; //������ �̸� TEXT
    bool isBuy; //�������� ����� �Ȼ����

    public int mp; //�Ӵ� �Ŀ�

    private void Awake()
    {
        priceUi.text = this.price + " ��";
        itemNameUi.text = this.itemName;
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

        if (this.isBuy) {
            Debug.Log("�̹� ������ ��ǰ �Դϴ�");
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
