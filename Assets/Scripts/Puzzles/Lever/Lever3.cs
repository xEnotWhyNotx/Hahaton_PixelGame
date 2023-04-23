using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : Interactable
{
    public LeversPuzzle levpuz;


    public override void Interact()
    {
        levpuz.ThirdL();
    }
}
