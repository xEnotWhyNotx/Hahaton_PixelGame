using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject buttonint;
    public GameObject Oxbar;

    private bool f;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    private Slot_UI selectedSlot;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDescription;
    public static bool isActive = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && FindObjectOfType<ActivePuzzle>().GetPuzzle() != true)
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            if (f == true)
            {
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                buttonint.SetActive(false);
            }
            Oxbar.SetActive(false);
            isActive = true;
            Refresh();
        }
        else
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }
            textName.text = "";
            textDescription.text = "";
            inventoryPanel.SetActive(false);
            isActive = false;
            if (f == true)
            {
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                button4.SetActive(true);
                buttonint.SetActive(true);
            }
            
            Oxbar.SetActive(true);
        }
    }

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void SelectSlot(int index)
    {
        if (slots.Count == 4)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }
            selectedSlot = slots[index];
            //Debug.Log(player.inventory.slots[index].itemName);
            selectedSlot.SetHighlight(true);
            textName.text = player.inventory.slots[index].itemName;
            textDescription.text = player.inventory.slots[index].itemDesc;
        }
    }

    public void ShowOnClick()
    {
        ToggleInventory();
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
}
