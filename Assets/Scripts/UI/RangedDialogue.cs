using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDialogue : MonoBehaviour
{
    public DialogueTrigger trigger;
    public BoxCollider2D collider1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
            collider1.enabled = !collider1.enabled;
        }
    }
}
