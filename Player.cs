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

    private void Update()
    {
        moneyUI.text = "���� : "+ this.money +" ��";
        FeverEvent();
    }

    public void AddMoney()
    {
        int mp = isFever ? moneyPower * 2 : moneyPower;
        this.money = this.money + mp;
    }

    public void ToggleFever()
    {
        isFever = !isFever;
        //Instantiate(feverEffect, FeverTimeUi.transform);
        ParticleSystem particleObject = Instantiate(feverEffect, FeverTimeUi.transform);
        particleObject.Play();
    }

    private void FeverEvent()
    {
        if (feverTime <= 0) {
            isFever = false;
        }
        if (isFever) {
            feverTime -= Time.deltaTime;
        }
        FeverTimeUi.text = Mathf.Round(feverTime) + "��";
    }
}
