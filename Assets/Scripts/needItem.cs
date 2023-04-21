using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class needItem : Interactable
{
    public Player player;
    public string neededItem; 
    public Sprite activated;
    public Sprite deactivated;

    private SpriteRenderer sr;
    public bool isActivated;



    public override void Interact()
    {
        foreach (Inventory.Slot slot in player.inventory.slots)
        {
            if(slot.itemName == neededItem)
            {
                if (isActivated)
                {
                    sr.sprite = deactivated;
                    FindObjectOfType<DoorController>().CloseDoor();
                }
                else
                {
                    sr.sprite = activated;
                    FindObjectOfType<DoorController>().OpenDoor();
                }
                isActivated = !isActivated;

            }
            else
            {
                Debug.Log("We don't have needed item");
            }
            
        }
        
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
