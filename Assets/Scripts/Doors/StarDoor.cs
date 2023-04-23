using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDoor : MonoBehaviour
{
    public Sprite open;
    public Sprite closed;

    public BoxCollider2D collider1;

    private SpriteRenderer sr;

    public bool isOpen;

    public void OpenDoor()
    {
        isOpen = true;
        collider1.enabled = !collider1.enabled;
        sr.sprite = open;
    }

    public void CloseDoor()
    {
        isOpen = false;
        collider1.enabled = !collider1.enabled;
        sr.sprite = closed;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        collider1 = GetComponent<BoxCollider2D>();
    }
}
