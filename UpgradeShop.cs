using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    RectTransform rectTrans;
    private void Awake()
    {
        rectTrans = this.gameObject.GetComponent<RectTransform>();
    }

    public void OpenUpgradeShop()
    {
        rectTrans.anchoredPosition = new Vector2(0, 0);
    }

    public void CloseUpgradeShop()
    {
        rectTrans.anchoredPosition = new Vector2(-500, 0);
    }
}
