using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedOnTrigger : Interactable
{
    public SpriteRenderer sr1;
    public Sprite active;
    public Sprite Nonactive;
    private AudioSource audioSource;

    public override void Interact()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Korobka"))
        {
            audioSource.Play();
            sr1.sprite = active;
            FindObjectOfType<DoorInLevers>().OpenDoor();
            // Debug.Log("In collider");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Korobka"))
        {
            sr1.sprite = Nonactive;
            FindObjectOfType<DoorInLevers>().CloseDoor();
            // Debug.Log("Not in collider");
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr1 = GetComponent<SpriteRenderer>();
        sr1.sprite = Nonactive;
    }
}
