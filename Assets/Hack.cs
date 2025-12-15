using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    PlayerController controller;
    public List<FarmTile> farm = new List<FarmTile>();
    PlayerHealth  PlayerHealth; 
    Timecaculator Timecaculator;
    void Start()
    {
        controller  = FindAnyObjectByType<PlayerController>();
        PlayerHealth = FindAnyObjectByType<PlayerHealth>(); 
        Timecaculator = FindAnyObjectByType<Timecaculator>();
    }

    public void Addcoin()
    {
        controller.AddCoins(1000);
    }
    public void Tocdo()
    {
        controller.moveSpeed += 5;
    }
    public void toDotru()
    {
        controller.moveSpeed -= 5;
    }

    public void Caytronng()
    {
       foreach (FarmTile tile in farm)
        {
            tile.growthTime = 3f;
            tile.harvestTime = 3f;
        }
    }

    public void Heal()
    {
        PlayerHealth.HealPlayer();
    }
    public void time()
    {
        Timecaculator.timecount += 60;
    }
    void Update()
    {
        
    }
}
