using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : Interactable
{
    public GameObject but;
    public GameObject img;
    public ActivePuzzle puz;

    public override void Interact()
    {

        puz.SetPuzzle(true);
        FindObjectOfType<Player>().SetUI();
        but.SetActive(true);
        img.SetActive(true);
    }
    
}
