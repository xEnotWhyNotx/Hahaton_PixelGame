using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
public class needItem : Interactable
{
    public Player player;
    public string neededItem; 

    private SpriteRenderer sr;
    private bool isActivated;


    public override void Interact()
    {
        foreach (Inventory.Slot slot in player.inventory.slots)
        {
            if(slot.itemName == neededItem)
            {
                isActivated = true;
                break;
            }
            else
            {
                Debug.Log("We don't have needed item");
                isActivated = false;
            }
        }
        if (isActivated == true)
        {
            SceneManager.LoadScene("DragNDropScene",LoadSceneMode.Additive);
        }
    }
    public bool isActive()
    {
        return isActivated;
    }
}
