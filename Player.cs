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

    private void Update()
    {
        moneyUI.text = "지갑 : "+ this.money +" 원";
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
        FeverTimeUi.text = Mathf.Round(feverTime) + "초";
    }
}
