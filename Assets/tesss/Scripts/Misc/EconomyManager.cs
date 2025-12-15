using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    PlayerController player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }
    public void UpdateCurrentGold() {


        player.AddCoins(1);
        

    }
}
