using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        if (messages == null || messages.Length == 0)
        {
            Debug.LogError("Messages array is null or empty!");
            return;
        }
        if (actors == null || actors.Length == 0)
        {
            Debug.LogError("Actors array is null or empty!");
            return;
        }

        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length + ", Actors: " + actors.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.4f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        if (activeMessage >= currentMessages.Length)
        {
            Debug.LogError("activeMessage index out of bounds!");
            return;
        }

        Message messageToDisplay = currentMessages[activeMessage];

        if (messageToDisplay.actorId < 0 || messageToDisplay.actorId >= currentActors.Length)
        {
            Debug.LogError("Invalid actorId: " + messageToDisplay.actorId);
            return;
        }

        messageText.text = messageToDisplay.message;
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];

        if (actorToDisplay == null)
        {
            Debug.LogError("Actor is null for ID: " + messageToDisplay.actorId);
            return;
        }

        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
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
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.4f).setEaseInOutExpo();
            isActive = false;
            return;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isActive: " + isActive);

        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}
