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
    public GameObject sound2;

    public float OxygenLevel = 100;
    public float MaxOxygenLevel = 100;
    private bool inTriggerZone = false;
    private bool canRefill = false;
    public float DecreaseLevel;
    public float RefillOxygen;
    public KeyCode transitionKey = KeyCode.E;
    private AudioSource audioSource;
    private AudioSource audioSource2;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Awake()
    {
        inventory = new Inventory(4);
        audioSource2 = sound2.GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.E) || buttonint)
        {
            if (canRefill)
            {
                foreach (Inventory.Slot slot in inventory.slots)
                {
                    if (slot.itemName == "Gas Balon")
                    {
                        FindObjectOfType<Inventory_UI>().Remove(slot);
                        audioSource2.Play();
                        if (OxygenLevel + RefillOxygen >= 100)
                        {
                            OxygenLevel = 100;
                        }
                        else
                        {
                            OxygenLevel += RefillOxygen;
                        }
                        break;
                    }
                    else
                    {
                        Debug.Log("Don't have");
                    }
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
        OxygenLevel -= 0.001f;
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
