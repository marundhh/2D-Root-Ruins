using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
    


}

public enum CollectableType
{


    NONE, APPLE_, FISH_, HatBiNgo_, HatCarrot_, HaDauHaLan_,HatCaChua_, HatKhoaiLang_, BiNgo_, KhoaiLang_, Carrot_,CaChua_,DauHaLan_,Fruit_

}
