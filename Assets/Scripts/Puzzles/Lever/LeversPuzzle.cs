using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeversPuzzle : MonoBehaviour
{
    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    public SpriteRenderer sr3;
    public SpriteRenderer sr4;
    public Sprite active;
    public Sprite unable;
    private bool r1 = true;
    private bool r2 = true;
    private bool r3 = true;
    private bool r4 = true;
    private AudioSource audioSource;

    public void FirstL()
    {
        
        if (r1 == true)
        {
            r1 = false;
            sr1.sprite = unable;
        }
        else
        {
            r1 = true;
            sr1.sprite = active;
        }
        Debug.Log("First slot = " + r1);
        CheckCorrect();
    }
    public void SecondL()
    {
        
        if (r2 == true)
        {
            r2 = false;
            sr2.sprite = unable;
        }
        else
        {
            r2 = true;
            sr2.sprite = active;
        }
        Debug.Log("Second slot = " + r2);
        CheckCorrect();
    }
    public void ThirdL()
    {
        
        if (r3 == true)
        {
            r3 = false;
            sr3.sprite = unable;
        }
        else
        {
            r3 = true;
            sr3.sprite = active;
        }
        Debug.Log("Third slot = " + r3);
        CheckCorrect();
    }
    public void FourthL()
    {
        if (r4 == true)
        {
            r4 = false;
            sr4.sprite = unable;
        }
        else
        {
            r4 = true;
            sr4.sprite = active;
        }
        Debug.Log("Fourth slot = " + r4);
        CheckCorrect();
    }

    private void CheckCorrect()
    {
        if (r1 == false && r2 == true && r3 == false && r4 == true)
        {
            FindObjectOfType<DoorControllerLevers>().OpenDoor();
            audioSource.Play();
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
