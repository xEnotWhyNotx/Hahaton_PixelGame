using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePuzzle : MonoBehaviour
{
    private bool Active = false;

    public void SetPuzzle(bool y)
    {
        Active = y;
    }

    public bool GetPuzzle()
    {
        return Active;
    }
}
