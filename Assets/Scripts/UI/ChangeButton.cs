using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour
{
    public GameObject changeButton;
    public Sprite modeOn;
    public Sprite modeOff;
    private bool en = false;
    public void ChangeSprite()
    {
        if (en == false)
        {
            en = true;
            changeButton.GetComponent<Image>().sprite = modeOn;
        }
        else
        {
            en = false;
            changeButton.GetComponent<Image>().sprite = modeOff;
        }
        
    }
}
