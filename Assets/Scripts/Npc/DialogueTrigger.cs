using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool nearNPC;
public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<NpcAI>().canMove = false;
            nearNPC = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            GetComponent<NpcAI>().canMove = true;
            nearNPC = false;
        }
    }
    private void Update()
    {
        if (nearNPC)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                   
                    TriggerDialogue();
                }
            }
        }
       
    }

}
