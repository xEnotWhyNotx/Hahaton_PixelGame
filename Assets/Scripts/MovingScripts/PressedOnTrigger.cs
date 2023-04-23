using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedOnTrigger : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite active;
    public Sprite Nonactive;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Korobka"))
        {
            sr.sprite = active;
            Debug.Log("In collider");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Korobka"))
        {
            sr.sprite = Nonactive;
            Debug.Log("Not in collider");
        }
    }
}
