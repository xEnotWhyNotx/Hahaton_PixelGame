using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Awake()
    {
        inventory = new Inventory(4);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            Debug.Log("We r in");
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
}
