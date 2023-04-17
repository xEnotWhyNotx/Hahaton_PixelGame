using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool isActivated;
    public Animator animator;

    public void PressLever()
    {
        if (!isActivated)
        {
            isActivated = true;
            animator.SetBool("IsActivated", isActivated);
        }
    }
}
