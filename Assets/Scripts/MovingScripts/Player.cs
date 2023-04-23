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
    private bool inTriggerZone = false;
    private bool canRefill = false;
    public float DecreaseLevel;
    public float RefillOxygen;
    public KeyCode transitionKey = KeyCode.E;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Awake()
    {
        inventory = new Inventory(4);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TriggerZone1"))
        {
            inTriggerZone = true;
            if (inTriggerZone) {
                {
                    OxygenLevel -= DecreaseLevel;
                }
            }
        }
        if (other.CompareTag("RefillStation"))
        {
            Debug.Log("Can refill");
            canRefill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TriggerZone1"))
        {
            inTriggerZone = false;
        }
        if (other.CompareTag("RefillStation"))
        {
            Debug.Log("Can't refill");
            canRefill = false;
        }
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canRefill)
            {
                Debug.Log("Can refill");
                if (OxygenLevel >= 99)
                {
                    OxygenLevel += 100 - OxygenLevel - 1;
                }
                else
                {
                    OxygenLevel += RefillOxygen;
                }
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
