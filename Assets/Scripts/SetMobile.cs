using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMobile : MonoBehaviour
{
    private bool f;
    private void Awake()
    {
        if (FindObjectOfType<Mobile>() != null)
        {
            f = FindObjectOfType<Mobile>().GetMode();
        }
        else
        {
            f = false;
        }
        if (f == false)
        {
            this.gameObject.SetActive(false);
        }
    }
}
