using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchScript : MonoBehaviour
{
    //defines the virtual cameras
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera npcCamera;
    public CinemachineVirtualCamera gameCamera;


    // Start is called before the first frame update

    public void switchToDialoguePlayer() // passo variabile canvas -> schermata
    {

    }

    public void switchToPerson(string nameSpeaker){
        Debug.Log("SONO DENTRO FIRST");
        Debug.Log("Diagolo attivo_Fuori" + DialogueSystemScript.dialogueActive);
        if (DialogueSystemScript.dialogueActive) 
        {
            Debug.Log("Diagolo attivo" +  DialogueSystemScript.dialogueActive);
            switch (nameSpeaker.Remove(nameSpeaker.Length - 1, 1))
            { 
                case "Gabbiano":
                    Debug.Log("SONO DENTRO_Gabbiano");
                    playerCamera.m_Priority = 1;
                    npcCamera.m_Priority = 0;
                    gameCamera.m_Priority = 0;
                break;
                default:
                    Debug.Log("SONO DENTRO_Others");
                    playerCamera.m_Priority = 0;
                    npcCamera.m_Priority = 1;
                    gameCamera.m_Priority = 0;
                    break;

            }

        }else if(DialogueSystemScript.outOfRange == true || DialogueSystemScript.dialogueActive == false)
        {
            Debug.Log("Furi dal tunnel");
            playerCamera.m_Priority =0 ;
            npcCamera.m_Priority = 0;
            gameCamera.m_Priority = 1;
        }


    }

}
