using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystemScript : MonoBehaviour
{
    public Text uiText;
    public Text uiName;
    public GameObject dialogueGUI;
    public Transform dialogueBoxGUI;
    //Velocità scrittura
    public float letterDelay = 0.1f;
    public float letterMultiplier = 0.5f;

    public KeyCode dialogueInput = KeyCode.F;

    //Text Lines 

    public List<string> senteces;
    public List<string> names;

    public bool letterIsMultiplied = false;
    public static bool dialogueActive = false;
    public bool dialogueEnded = false;
    public static bool outOfRange = true;


    DialogueAudioScript dialogueAudio;
    CameraSwitchScript cameraSwitch;

    void Start()
    {
        dialogueAudio = FindObjectOfType<DialogueAudioScript>();
        cameraSwitch = FindObjectOfType<CameraSwitchScript>();
        
        uiText.text = "";
    }//[m] Start()

    public void startTexting()
    {
        outOfRange = false;
        dialogueBoxGUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(dialogueInput))
        {
            if (!dialogueActive)
            {   dialogueActive = true;
                StartCoroutine(startDialogue());
               
                    
            }
        }
        startDialogue();
    }//[m] end startTexting()

    private IEnumerator displayToString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int lengtStringLine = stringToDisplay.Length;
            int currentCharacterIndex = 0;
            uiText.text = "";
           
            while (currentCharacterIndex < lengtStringLine)
            {
                uiText.text += stringToDisplay[currentCharacterIndex];

                currentCharacterIndex++; // carattere per carattere
                if (currentCharacterIndex < lengtStringLine)
                {
                    if (Input.GetKeyDown(dialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);
                    }
                }
                else
                {
                    dialogueEnded = false;
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(dialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            uiText.text = "";
        }

    }// [m] end displayToString(string stringToDisplay)
    private IEnumerator startDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLenght = senteces.Count;
            int currentDialogueIndex = 0;
            while (currentDialogueIndex < dialogueLenght || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    //----------------------------------------------------------------------------------------------------
                    uiName.text = names[currentDialogueIndex];
                    dialogueAudio.saySentence(uiName.text, senteces[currentDialogueIndex]);
                    cameraSwitch.switchToPerson(uiName.text);
                    StartCoroutine(displayToString(senteces[currentDialogueIndex++]));

                    if (currentDialogueIndex >= dialogueLenght)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }
            while (true)
            {
                if (Input.GetKeyDown(dialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            closeDialogue();
            cameraSwitch.switchToPerson(uiName.text);
        }
    }// [m] startDialogue()

    public void outOfRangeOfNPC()
    {
        outOfRange = true;
        if (outOfRange == true)
        {
            letterIsMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines(); //ma se dovessimo usare altre coroutine questo ci uccide anche quelle?
            closeDialogue();
            cameraSwitch.switchToPerson(uiName.text);
        }
    }// [m] end outOfRangeOfNPC
    public void enterOfRangeOfNPC()
    {
        outOfRange = false;
        dialogueGUI.SetActive(true);
        if (dialogueActive == true)
        {
            dialogueGUI.SetActive(false);
        }
    }// [m] end enterRangeOfNPC()
    public void closeDialogue()
    {
        dialogueBoxGUI.gameObject.SetActive(false);
        dialogueGUI.SetActive(false);

		//AGGIUNGERE METODO CHE SEGNALA LA FINE DEL DIALOGO E FA AVANZALO LO STATO
		if (!NPCTalkScript.isDialogueDone())
		{
			GameState.AdvanceState();
			NPCTalkScript.dialogueIsDone();
		}

    }//[m] end closeDialogue()
}
