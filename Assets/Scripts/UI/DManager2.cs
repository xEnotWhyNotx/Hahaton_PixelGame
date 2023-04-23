using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DManager2 : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    private Message2[] currentMessages;
    private Actor2[] currentActors;
    private int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message2[] messages, Actor2[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        FindObjectOfType<Player>().SetUI();
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    public bool GetDialogue()
    {
        return isActive;
    }

    private void DisplayMessage()
    {
        Message2 messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor2 actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            FindObjectOfType<Player>().SetUI();
            SceneManager.LoadScene("Win");
        }
    }

    private void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }
    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    public bool GetState()
    {
        return isActive;
    }
}
