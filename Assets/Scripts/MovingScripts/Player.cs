using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    public float OxygenLevel = 100;

    public float MaxOxygenLevel = 100;

    private void Awake()
    {
        inventory = new Inventory(4);
    }

    void Update()
    {
        Task.Run(() => LoverOxygenLevel());

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
            //Debug.Log("We r in");
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
}
