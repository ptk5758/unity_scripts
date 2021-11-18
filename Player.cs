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
    public SpriteRenderer feverLight; //�ǹ� Ÿ���� �˸��� ��
    public int buyFeverTime; // �ǹ�Ÿ�� �Ǹ� �ð�
    public int feverTimePrice; // �ǹ�Ÿ�� ���� ���� �д�

    public ParticleSystem feverEffect; // �ǹ� �̺�Ʈ    

    public GameObject ShopUI; //���� UI

    private Item item; //������
    public Text weaponUi; //������ Ui    

    private void Update()
    {
        moneyUI.text = "���� : "+ this.money +" ��";
        FeverEvent();
    }

    private void Awake()
    {
        feverLight.color = Color.blue;
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

        if (isFever) {
            feverLight.color = Color.red;
        } else {
            feverLight.color = Color.blue;
        }

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
        Debug.Log(item.itemName + "���� �Ϸ� �̺�Ʈ");
    }

    public void BuyFeverTime() //�ǹ�Ÿ�� ���� �Լ�
    {
        
        if (this.money < this.feverTimePrice) {
            Debug.Log("�ܾ��� �����մϴ� �̺�Ʈ");
            return;
        }

        this.money -= this.feverTimePrice;
        this.feverTime += this.buyFeverTime;
    }
}