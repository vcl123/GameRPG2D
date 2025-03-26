using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour 
{ 
    public Message[] messages; 
    public Actor[] actors;

    public void StartDialogue()
    {
        DialogueManager dialogueManager = FindFirstObjectByType<DialogueManager>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager not found in the scene!");
            return;
        }

        dialogueManager.OpenDialogue(messages, actors);
    }
}
[System.Serializable] 
public class Message 
{ 
    public int actorId;
    public string message; 
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}

