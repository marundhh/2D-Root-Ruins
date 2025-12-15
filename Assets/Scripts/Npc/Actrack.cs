using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actrack : MonoBehaviour
{
    Animator animator;
    public bool hasNPC;
    public bool hasPlayer;
    public GameObject shop;
    public GameObject shop2;
    public GameObject ShopchuTo;
    bool show = true;
    bool swapIn = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.tag == "NPC")
        {

            hasNPC = true;

        }
        if ( collision.tag == "Player")
        {
            hasPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.tag == "NPC")
        {
            hasNPC = false;
           
        }
        if (collision.tag == "Player")
        {
            hasPlayer = false;
        }
    }

    private void Update()
    {
        if (hasNPC && hasPlayer)
        {
            
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (show)
                    {
                        Show();
                    } else
                    {
                        Hide();
                    }    
                }          
            
        }



    }

    public void Show()
    {
       
        animator.Play("Show");
        show = false;
        ShopchuTo.GetComponent<ShopChuTo>().countItemforSHop();
    }
    public void Hide()
    {
        SwapOut();
        animator.Play("Hide");
        show = true;
        ShopchuTo.GetComponent<ShopChuTo>().Selling = false;
    }

    public void SwapShop()
    {
        if (swapIn)
        {
            SwapIn();
            ShopchuTo.GetComponent<ShopChuTo>().Selling = true;
        }
        else
        {
            SwapOut();
            ShopchuTo.GetComponent<ShopChuTo>().Selling = false;
        }

    }
    public void SwapIn()
    {
            animator.Play("SwapIn");
          
           swapIn = false;
    }
    public void SwapOut()
    {
            animator.Play("SwapOut");
            swapIn = true;
            
    }
}
