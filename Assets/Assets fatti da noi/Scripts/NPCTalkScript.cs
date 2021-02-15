using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkScript : MonoBehaviour
{
    //import fileTXT -----------//string path = "Assets/Resources/"name".txt"; in caso volessimo imporate i testi a mano [it doesn't sense]
    public TextAsset dialogueFile;

    //Struct Dialogue 
    List<string> dialogLines;
    List<string> names;
    List<string> sentences;

    // interface
    DialogueSystemScript dialogueSystem;
	
    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
        sentences = new List<string>();
        if (dialogueFile)
        {
            dialogLines = new List<string>(dialogueFile.text.Split("\n"[0]));
        }

        foreach (string str in dialogLines)
        {
            string[] vectorTemp = str.Split('#');
            names.Add(vectorTemp[0]);
            sentences.Add(vectorTemp[1]);
        }

        dialogueSystem = FindObjectOfType<DialogueSystemScript>();
        
    }//[m] end Start()

    void setUpDialogueText()
    {

        dialogueSystem.names = names;
        dialogueSystem.senteces = sentences;
    }//[m] end setUpDialogueText()


    public void OnTriggerStay(Collider other)
    {
        //active script 
        this.gameObject.GetComponent<NPCTalkScript>().enabled = true;
        //enable All dialogue and other GUIs
        FindObjectOfType<DialogueSystemScript>().enterOfRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(dialogueSystem.dialogueInput))
        {
            this.gameObject.GetComponent<NPCTalkScript>().enabled = true;
            setUpDialogueText();
            FindObjectOfType<DialogueSystemScript>().startTexting();
        }

    }//[m] end OnTriggerStay (Collider other)
    public void OnTriggerExit()
    {
        //Disable script
        this.gameObject.GetComponent<NPCTalkScript>().enabled = false;
        //disable All dialogue and other GUIs
        FindObjectOfType<DialogueSystemScript>().outOfRangeOfNPC();
    }//[m] end OnTriggerExit();

}
