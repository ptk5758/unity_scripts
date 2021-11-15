using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int money; // 현재소지금
    public Text moneyUI; // 현재소지금 UI
    public int moneyPower; // 머니 파워

    public bool isFever; //피버 인지아닌지
    public Text FeverTimeUi; // 피버 타임 UI
    public float feverTime; // 피버 타임

    public ParticleSystem feverEffect; // 피버 이벤트    

    public GameObject ShopUI; //상점 UI

    private Item item; //아이템
    public Text weaponUi; //아이템 Ui

    private void Update()
    {
        moneyUI.text = "지갑 : "+ this.money +" 원";
        FeverEvent();
    }

    public void AddMoney() //돈 더하는 함수
    {
        int mp = this.moneyPower;

        if (this.item != null) {
            mp += this.item.GetMp();
        }

        if (isFever) {
            mp = mp * 2;
        }


        this.money = this.money + mp;


        // 피버일때 
        // 1. 두배 후에 아이템 공격력 ++

        // 2. 아이템 공격력 더해서 두배
    }

    public void ToggleFever() //피버 토글 함수 겸사겸사 파티클
    {
        isFever = !isFever;        
        ParticleSystem particleObject = Instantiate(feverEffect, FeverTimeUi.transform);
        particleObject.Play();
    }

    private void FeverEvent() //피버 이벤트
    {
        if (feverTime <= 0) {
            isFever = false;
        }
        if (isFever) {
            feverTime -= Time.deltaTime;
        }
        FeverTimeUi.text = Mathf.Round(feverTime) + "초";
    }

    public void SetItem(Item item) //아이템 셋 하는함수
    {
        
        this.item = item;
        weaponUi.text = "장착중인 무기 : " + this.item.itemName;
        Debug.Log(item.itemName + "장착 완료");
    }
}
/////////////////////////////////////////////////////
// 1. 있는 기능 잘쓰기 => private static void int class  이런 기능 잘다루기 
// 2. 알고리즘 잘쓰기 => 