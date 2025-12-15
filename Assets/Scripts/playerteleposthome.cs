using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerteleposthome : MonoBehaviour
{
    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<teleposthome>().GetDestination().position;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Telepost"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Telepost"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
