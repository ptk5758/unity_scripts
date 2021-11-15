using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int money; // ���������
    public Text moneyUI; // ��������� UI
    public int moneyPower; // �Ӵ� �Ŀ�

    public bool isFever; //�ǹ� �����ƴ���
    public Text FeverTimeUi; // �ǹ� Ÿ�� UI
    public float feverTime; // �ǹ� Ÿ��

    public ParticleSystem feverEffect; // �ǹ� �̺�Ʈ    

    public GameObject ShopUI; //���� UI

    private Item item; //������
    public Text weaponUi; //������ Ui

    private void Update()
    {
        moneyUI.text = "���� : "+ this.money +" ��";
        FeverEvent();
    }

    public void AddMoney() //�� ���ϴ� �Լ�
    {
        int mp = this.moneyPower;

        if (this.item != null) {
            mp += this.item.GetMp();
        }

        if (isFever) {
            mp = mp * 2;
        }


        this.money = this.money + mp;


        // �ǹ��϶� 
        // 1. �ι� �Ŀ� ������ ���ݷ� ++

        // 2. ������ ���ݷ� ���ؼ� �ι�
    }

    public void ToggleFever() //�ǹ� ��� �Լ� ����� ��ƼŬ
    {
        isFever = !isFever;        
        ParticleSystem particleObject = Instantiate(feverEffect, FeverTimeUi.transform);
        particleObject.Play();
    }

    private void FeverEvent() //�ǹ� �̺�Ʈ
    {
        if (feverTime <= 0) {
            isFever = false;
        }
        if (isFever) {
            feverTime -= Time.deltaTime;
        }
        FeverTimeUi.text = Mathf.Round(feverTime) + "��";
    }

    public void SetItem(Item item) //������ �� �ϴ��Լ�
    {
        
        this.item = item;
        weaponUi.text = "�������� ���� : " + this.item.itemName;
        Debug.Log(item.itemName + "���� �Ϸ�");
    }
}
/////////////////////////////////////////////////////
// 1. �ִ� ��� �߾��� => private static void int class  �̷� ��� �ߴٷ�� 
// 2. �˰��� �߾��� => 