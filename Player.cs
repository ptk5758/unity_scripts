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
    public SpriteRenderer feverLight; //피버 타임을 알리는 등
    public int buyFeverTime; // 피버타임 판매 시간
    public int feverTimePrice; // 피버타임 구매 가격 분당

    public ParticleSystem feverEffect; // 피버 이벤트    

    public GameObject ShopUI; //상점 UI

    private Item item; //아이템
    public Text weaponUi; //아이템 Ui    

    private void Update()
    {
        moneyUI.text = "지갑 : "+ this.money +" 원";
        FeverEvent();
    }

    private void Awake()
    {
        feverLight.color = Color.blue;
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

        if (isFever) {
            feverLight.color = Color.red;
        } else {
            feverLight.color = Color.blue;
        }

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
        Debug.Log(item.itemName + "장착 완료 이벤트");
    }

    public void BuyFeverTime() //피버타임 구메 함수
    {
        
        if (this.money < this.feverTimePrice) {
            Debug.Log("잔액이 부족합니다 이벤트");
            return;
        }

        this.money -= this.feverTimePrice;
        this.feverTime += this.buyFeverTime;
    }
}