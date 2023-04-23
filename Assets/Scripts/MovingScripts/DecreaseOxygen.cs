using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class DecreaseOxygen : MonoBehaviour
// {
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             OxygenController oxygenController = other.CompareTag("Player");
//             Debug.Log("-In trigger");
//             if (oxygenController != 0)
//             {
//                 InvokeRepeating("DecreaseOxygenLevel", 1f, 1f);
//             }
//             // other.GetComponent<OxygenController>().OxygenLevel -= 20f;
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             CancelInvoke("DecreaseOxygenLevel");
//             Debug.Log("Not in trigger");
//         }
//     }

//     void DecreaseOxygenLevel()
//     {
//         OxygenController oxygenController = other.CompareTag("Player");
//         oxygenController.OxygenLevel -= 20f;
//         Debug.Log("-20!!!");
//     }
// }

