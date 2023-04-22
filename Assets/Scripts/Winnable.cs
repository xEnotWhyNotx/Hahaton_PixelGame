using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnable : MonoBehaviour
{
    private bool win = false;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetMode()
    {
        win = !win;
        Debug.Log("Win mode is " + win);
    }

    public bool GetMode()
    {
        return win;
    }
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
