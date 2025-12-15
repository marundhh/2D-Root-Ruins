using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuy : MonoBehaviour
{
    ShopChuTo shopChuTo;
    public int Index;

    private void Start()
    {
        shopChuTo = FindAnyObjectByType<ShopChuTo>();
    }
  public  void OnClickButton()
    {
        shopChuTo.id = Index;
        shopChuTo.Buy();
    }
    public void Setid()
    {
        shopChuTo.id=Index;
    }
}
