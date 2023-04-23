using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SpriteRenderer))]
public class To15 : Interactable
{
    public Player player;
    public string neededItem;
    public ActivePuzzle puz;
    private bool f;
    private bool completed = false;
    private SpriteRenderer sr;
    private bool isActivated;


    public override void Interact()
    {
        if (completed == false)
        {
            puz.SetPuzzle(true);
            FindObjectOfType<Player>().SetUI();
            SceneManager.LoadScene("15Game", LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Puzzle completed");
        }
    }
    public bool isActive()
    {
        return isActivated;
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
        completed = true;
    }
}
