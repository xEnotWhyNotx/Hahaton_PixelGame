using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite open;
    public Sprite closed;

    public BoxCollider2D collider;

    private SpriteRenderer sr;

    public bool isOpen;

    public void OpenDoor()
    {
        isOpen = true;
        collider.enabled = !collider.enabled;
        sr.sprite = open;
    }

    public void CloseDoor()
    {
        isOpen = false;
        collider.enabled = !collider.enabled;
        sr.sprite = closed;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        collider = GetComponent<BoxCollider2D>();
    }


}
