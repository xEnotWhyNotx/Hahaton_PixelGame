using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : Interactable
{
    public LeversPuzzle levpuz;


    public override void Interact()
    {
        levpuz.SecondL();
    }
}
