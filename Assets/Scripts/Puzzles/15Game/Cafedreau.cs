using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cafedreau : Interactable
{
    public Player player;
    public Camera cam1;
    public ActivePuzzle2 puz;
    private bool f;
    private bool completed2 = false;
    private bool isActivated;


    public override void Interact()
    {
        if (completed2 == false)
        {
            puz.SetPuzzle(true);
            FindObjectOfType<Player>().SetUI();
            cam1.enabled = false;
            SceneManager.LoadScene("15Game", LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Puzzle completed");
        }
    }
    public void Awake()
    {
        if (FindObjectOfType<Mobile>() != null)
        {
            f = FindObjectOfType<Mobile>().GetMode();
        }
        else
        {
            f = false;
        }
    }
    public void setComplete()
    {
        completed2 = true;
        cam1.enabled = true;
        FindObjectOfType<PyatnashkiDoor>().OpenDoor();
    }
    public bool isActive()
    {
        return isActivated;
    }
}
