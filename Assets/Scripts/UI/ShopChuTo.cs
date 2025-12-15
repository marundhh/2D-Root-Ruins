using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using System;

public class ShopChuTo : MonoBehaviour
{
    public Animator xacnhanMenu;
    public int countItem;
    public int id;
    PlayerController player;

    public GameObject actract;

    public List<CollectableType> type;
    public List<Sprite> sprites = new List<Sprite>();

    public List<CollectableType> type2;
    public List<Sprite> sprites2 = new List<Sprite>();


    public TMP_InputField soLuong;

    public List<TextMeshProUGUI> countItemShop = new List<TextMeshProUGUI>();

    public TextMeshProUGUI giaText;

    public GameObject XacNhanMenu;

    public int SoLuongMua;

    public bool oneBuy = false;
    public bool oneSell = false;

    public bool Selling; 

    private void Start()
    {
        //
        soLuong.onValueChanged.AddListener(SoluongUpdate);
        player = FindAnyObjectByType<PlayerController>();

    }


    void SoluongUpdate(string input)
    {
        int.TryParse(input, out SoLuongMua);
        if (SoLuongMua > 0)
        {
            GoiShop();
        }
       
    }


    public void Buy()
    {
        XacNhanMenu.SetActive(true);
        xacnhanMenu.Play("XacNhanShow");
    }
    public void XacNhan()
    {
        countItemforSHop();
        if (Selling)
        {
            oneSell = true;
            GoiShop();
        }
        else
        {
            oneBuy = true;
            GoiShop();
        }

       
        Huy();
    }
    public void Huy()
    {
        countItemforSHop();
        soLuong.text = "";
        giaText.text = "0";
        xacnhanMenu.Play("XacNhanHide");
       

    }

    void GoiShop()
    {
        Debug.Log("sell"+ Selling);
        if (Selling)
        {
            KiemTraItemBan();
        }
        else 
        {
            KiemTraItemMua(); 
           
        }
    }
    private void Update()
    {
        
    }
    public void countItemforSHop()
    {
        for (int i = 0; i < type2.Count; i++)
        {
            countItemShop[i].text = player.inventory.GetItem(type2[i]).ToString();
        }
          /*  
           switch (thutu)
            {
                case 0:
                    countItemShop[0].text = player.inventory.GetItem(type2[0]).ToString();
                    Debug.Log(player.inventory.GetItem(type2[0]));
                    Debug.Log(player.inventory.getSlots(type2[0]));
                    thutu = 1;  
                    break;
                case 1:
                    countItemShop[1].text = player.inventory.GetItem(type2[1]).ToString();
                    Debug.Log(player.inventory.GetItem(type2[1]));
                    Debug.Log(player.inventory.getSlots(type2[1]));
                    thutu = 2;
                    break;
                case 2:
                    countItemShop[2].text = player.inventory.GetItem(type2[2]).ToString();
                    Debug.Log(player.inventory.GetItem(type2[2]));
                    thutu = 3;
                    break;
                case 3:
                    Debug.Log(player.inventory.GetItem(type2[3]));
                    countItemShop[3].text = player.inventory.GetItem(type2[3]).ToString();
                    thutu = 4;
                    break;
                case 4:
                    countItemShop[4].text = player.inventory.GetItem(type2[4]).ToString();
                    Debug.Log(player.inventory.GetItem(type2[4]));
                    thutu = 0;
                    break;
            }*/
           
        
    }
    private void KiemTraItemBan()
    {
        switch (id)
        {
            case 1:   //Hat Bi ngo
                int gia = (SoLuongMua * 180);        
                giaText.text = gia.ToString();
                if (oneSell)
                {
                    Sprite hatS = sprites2[0];
                    CollectableType hatT = type2[0];
                    int index = player.inventory.getSlots(hatT);
                    if (player.inventory.GetItem(hatT) >= SoLuongMua)
                    {
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.Remove(index);
                        }
                        player.coins += gia;
                        oneSell = false;
                    }             
                }
                
                
                break;
            case 2:    //Hat Khoai Lan
                gia = (SoLuongMua * 200);
                giaText.text = gia.ToString();
                if (oneSell)
                {
                    Sprite hatS = sprites2[1];
                    CollectableType hatT = type2[1];
                    int index = player.inventory.getSlots(hatT);
                    if (player.inventory.GetItem(hatT) >= SoLuongMua)
                    {
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.Remove(index);
                        }
                        player.coins += gia;
                        oneSell = false;
                    }
                }
                break;
            case 3:   //Hat Cà rốt
                gia = (SoLuongMua * 240);
                giaText.text = gia.ToString();
                if (oneSell)
                {
                    Sprite hatS = sprites2[2];
                    CollectableType hatT = type2[2];
                    int index = player.inventory.getSlots(hatT);
                    if (player.inventory.GetItem(hatT) >= SoLuongMua)
                    {
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.Remove(index);
                        }
                        player.coins += gia;
                        oneSell = false;
                    }
                }
                break;
            case 4:   //Hat Cà Chua
                gia = (SoLuongMua * 140);
                giaText.text = gia.ToString();
                if (oneSell)
                {
                    Sprite hatS = sprites2[3];
                    CollectableType hatT = type2[3];
                    int index = player.inventory.getSlots(hatT);
                    if (player.inventory.GetItem(hatT) >= SoLuongMua)
                    {
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.Remove(index);
                        }
                        player.coins += gia;
                        oneSell = false;
                    }
                }
                break;
            case 5:   //Hat Đậu Hà lan
                gia = (SoLuongMua * 150);
                giaText.text = gia.ToString();
                if (oneSell)
                {
                    Sprite hatS = sprites2[4];
                    CollectableType hatT = type2[4];
                    int index = player.inventory.getSlots(hatT);
                    if (player.inventory.GetItem(hatT) >= SoLuongMua)
                    {
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.Remove(index);
                        }
                        player.coins += gia;
                        oneSell = false;
                    }
                }
                break;
        }
    }

    public void KiemTraItemMua()
    {
        
        switch (id)
        {
            case 1:   //Hat Bi ngo
                int gia = (SoLuongMua * 100);
                giaText.text = gia.ToString();
                if (oneBuy)
                {
                    if (player.coins >= gia)
                    {
                        player.SubtractCoins(gia);
                        Sprite hatS = sprites[0];
                        CollectableType hatT = type[0];
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.AddBuy(hatS, hatT);
                        }
                        oneBuy = false;
                    }
                }
                break;
            case 2:    //Hat Khoai Lan
                gia = (SoLuongMua * 80);
                giaText.text = gia.ToString();
                if (oneBuy)
                {
                    if (player.coins >= gia)
                    {
                        player.SubtractCoins(gia);
                        Sprite hatS = sprites[1];
                        CollectableType hatT = type[1];
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.AddBuy(hatS, hatT);
                        }
                        oneBuy = false;
                    }
                }
                break;
            case 3:   //Hat Cà rốt
                gia = (SoLuongMua * 120);
                giaText.text = gia.ToString();
                if (oneBuy)
                {
                    if (player.coins >= gia)
                    {
                        player.SubtractCoins(gia);
                        Sprite hatS = sprites[2];
                        CollectableType hatT = type[2];
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.AddBuy(hatS, hatT);
                        }
                        oneBuy = false;
                    }
                }
                break;
            case 4:   //Hat Cà Chua
                gia = (SoLuongMua * 70);
                giaText.text = gia.ToString();
                if (oneBuy)
                {
                    if (player.coins >= gia)
                    {
                        player.SubtractCoins(gia);
                        Sprite hatS = sprites[3];
                        CollectableType hatT = type[3];
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.AddBuy(hatS, hatT);
                        }
                        oneBuy = false;
                    }
                }
                break;
            case 5:   //Hat Đậu Hà lan
                gia = (SoLuongMua * 150);
                giaText.text = gia.ToString();
                if (oneBuy)
                {
                    if (player.coins >= gia)
                    {
                        player.SubtractCoins(gia);
                        Sprite hatS = sprites[4];
                        CollectableType hatT = type[4];
                        for (int i = 0; i < SoLuongMua; i++)
                        {
                            player.inventory.AddBuy(hatS, hatT);
                        }
                        oneBuy = false;
                    }
                }
                break;
        }

    }
}
