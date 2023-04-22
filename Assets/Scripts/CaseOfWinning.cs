using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseOfWinning : Interactable
{
    public Player player;
    private int Windex;
    private int Aindex;
    private int Caindex;
    private int Coindex;
    public Sprite active;
    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    public SpriteRenderer sr3;
    public SpriteRenderer sr4;
    private bool completed = false;
    private bool screw = false;

    public override void Interact()
    {
        if (completed == false)
        {
            if(screw == false)
            {
                foreach (Inventory.Slot slot in player.inventory.slots)
                {
                    if (slot.itemName == "Screwdriver")
                    {
                        screw = true;
                    }
                }
            }
            if (screw == true)
            {
                foreach (Inventory.Slot slot in player.inventory.slots)
                {

                    if (slot.itemName == "Wires")
                    {

                        FindObjectOfType<Inventory_UI>().Remove(slot);
                        sr1.sprite = active;
                    }
                    if (slot.itemName == "Connector")
                    {
                        FindObjectOfType<Inventory_UI>().Remove(slot);
                        sr2.sprite = active;

                    }
                    if (slot.itemName == "Antenna")
                    {
                        FindObjectOfType<Inventory_UI>().Remove(slot);
                        sr3.sprite = active;

                    }
                    if (slot.itemName == "Catcher")
                    {
                        FindObjectOfType<Inventory_UI>().Remove(slot);
                        sr4.sprite = active;
                    }
                    else
                    {
                        Debug.Log("We don't have needed item");
                    }
                }
            }
        }
        else
        {
            Debug.Log("You win");
        }
    }
}
