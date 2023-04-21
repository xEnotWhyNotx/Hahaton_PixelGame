using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// public class ToMiniGame : MonoBehaviour
// {
//     public GameObject activeFrame;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             activeFrame.SetActive(true);
            
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other) 
//     {
//         if (other.CompareTag("Player"))
//         {
//             activeFrame.SetActive(false);
//         }
//     }
// }

public class ToMiniGame : MonoBehaviour
{
    public KeyCode transitionKey = KeyCode.E;

    private bool canTransition = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTransition = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTransition = false;
        }
    }

    private void Update()
    {
        if (canTransition && Input.GetKeyDown(transitionKey))
        {
            SceneManager.LoadScene("DragNDropScene",LoadSceneMode.Additive);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}