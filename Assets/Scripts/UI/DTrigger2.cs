using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger2 : MonoBehaviour
{
    public Message2[] messages;
    public Actor2[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DManager2>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message2
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor2
{
    public string name;
    public Sprite sprite;
}
