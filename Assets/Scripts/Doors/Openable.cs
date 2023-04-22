using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{
    public Sprite activated;
    public Sprite deactivated;

    private SpriteRenderer sr;
    public bool isActivated;

    private AudioSource audioSource;


    public override void Interact()
    {
        Debug.Log(GetComponent<Collider>());
        if (isActivated)
        {
            sr.sprite = deactivated;
            FindObjectOfType<DoorController>().CloseDoor();
            audioSource.Play();
        }
        else
        {
            sr.sprite = activated;
            FindObjectOfType<DoorController>().OpenDoor();
            audioSource.Play();
        }
        isActivated = !isActivated;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = deactivated;
    }

    public bool isActive()
    {
        return isActivated;
    }
}
