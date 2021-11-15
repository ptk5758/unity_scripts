using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    RectTransform rectTrans;

    private void Awake()
    {
        rectTrans = this.gameObject.GetComponent<RectTransform>();
    }

    public void OpenShop()
    {
        rectTrans.anchoredPosition = new Vector2(0,0);
    }

    public void CloseShop()
    {
        rectTrans.anchoredPosition = new Vector2(500, 0);
    }
}
