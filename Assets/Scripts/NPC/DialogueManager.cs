using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour
{
    #region Dialogue Variables
    private const float V = 0f;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backroundBox;
    public Rigidbody2D rb;
    #endregion

    #region Current Messages
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    #endregion

    public PlayerMovement playerScript;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started Conversation! Loaded Messages: " + messages.Length);
        DispayMessage();
        backroundBox.LeanScale(Vector3.one, 0.5f);
        //startar konverastionen
    }


    void DispayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        //Ser till att få upp den på skärmen så man kan se det.
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DispayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            backroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
        //Går vidare i konverastionen. 
    }

    public void ExitDialogueIfToFarAway()
    {
        backroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        isActive = false;
    }


    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        backroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            NextMessage();
        }

        if (isActive)
        {
            playerScript.xInput = 0;
        }
    }


}
