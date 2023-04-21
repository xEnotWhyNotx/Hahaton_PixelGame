using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OpenableLeft : Interactable
{
    public Sprite activated;
    public Sprite deactivated;

    private SpriteRenderer sr;
    public bool isActivated;



    public override void Interact()
    {
        Debug.Log(GetComponent<Collider>());
        if (isActivated)
        {
            sr.sprite = deactivated;
            FindObjectOfType<DoorControllerLeft>().CloseDoor();
        }
        else
        {
            sr.sprite = activated;
            FindObjectOfType<DoorControllerLeft>().OpenDoor();
        }
        isActivated = !isActivated;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = deactivated;
    }

    public bool isActive()
    {
        return isActivated;
    }
}
