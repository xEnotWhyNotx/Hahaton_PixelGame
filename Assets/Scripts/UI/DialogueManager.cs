using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    private Message[] currentMessages;
    private Actor currentActor;
    private int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor actor)
    {
        currentMessages = messages;
        currentActor = actor;
        activeMessage = 0;
        isActive = true;

        Debug.Log(messages.Length);
        DisplayMessage();
    }

    private void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActor;
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
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
            Debug.Log("Conversation ended");
            isActive = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}
