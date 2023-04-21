using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    private bool mobile = false;
    
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetMode()
    {
        mobile = !mobile;
        Debug.Log("Mobile mod is " + mobile);
    }

    public bool GetMode()
    {
        return mobile;
    }
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
