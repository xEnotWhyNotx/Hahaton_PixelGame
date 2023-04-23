using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Inventory inventory;
    public ActivePuzzle puz;
    public DialogueManager dial;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject buttonint;
    public GameObject buttoninv;
    public GameObject Oxbar;

    public float OxygenLevel = 100;
    public float MaxOxygenLevel = 100;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Awake()
    {
        inventory = new Inventory(4);
    }

    void Update()
    {
        LoverOxygenLevel();
        if (OxygenLevel == 0)
        {
            SceneManager.LoadScene("Defeat");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            foreach (Inventory.Slot slot in inventory.slots)
            {
                Debug.Log(slot.itemName);
            }
            
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (puz.GetPuzzle() == false)
            {
                CheckInteraction();
            }
        }
    }

    private void CheckInteraction()
    {

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }

    public void LoverOxygenLevel()
    {  
        OxygenLevel -= 0.0005f;
        if (OxygenLevel < 0)
            OxygenLevel = 0;
        
    }

    public void CheckOnButton()
    {
        if (puz.GetPuzzle() != true)
        {
            CheckInteraction();
        }
        
    }

    public void SetUI()
    {
        if (puz.GetPuzzle() == true || dial.GetDialogue() == true)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            buttonint.SetActive(false);
            buttoninv.SetActive(false);
            Oxbar.SetActive(false);
        }
        else
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(true);
            buttonint.SetActive(true);
            buttoninv.SetActive(true);
            Oxbar.SetActive(true);
        }
    }
}
