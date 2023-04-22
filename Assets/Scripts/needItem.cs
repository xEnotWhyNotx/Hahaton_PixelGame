using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
public class needItem : Interactable
{
    public Player player;
    public string neededItem;
    public ActivePuzzle puz;
    private bool f;
    private bool completed = false;
    private SpriteRenderer sr;
    private bool isActivated;


    public override void Interact()
    {
        if (completed == false)
        {
            foreach (Inventory.Slot slot in player.inventory.slots)
            {

                if (slot.itemName == neededItem)
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
                isActivated = false;
                puz.SetPuzzle(true);
                FindObjectOfType<Player>().SetUI();
                SceneManager.LoadScene("DragNDropScene", LoadSceneMode.Additive);
            }
        }
        else
        {
            Debug.Log("Puzzle completed");
        }
    }
    public bool isActive()
    {
        return isActivated;
    }

    public void Awake()
    {
        if (FindObjectOfType<Mobile>() != null)
        {
            f = FindObjectOfType<Mobile>().GetMode();
        }
        else
        {
            f = false;
        }
    }
    public void setComplete()
    {
        completed = true;
    }
}
