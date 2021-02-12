using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudioScript : MonoBehaviour
{

    
    public static List<int> sequenceClips;
    public float rythm; // DA REGOLARE DOPO CHE SI INSERISCONO LE CLIP
    public static bool isRunning = false;
    public static List<AudioClip> gabbianoSound, umanoSound, animaleASound, capitanoSound, animaleCSound, tartarugaSound;
    public AudioSource audioSource;
    Coroutine voiceCoroutine;

    void Start()
    {
        

        umanoSound = new List<AudioClip>();
        gabbianoSound = new List<AudioClip>();
        tartarugaSound = new List<AudioClip>();
        animaleASound = new List<AudioClip>();
        animaleCSound = new List<AudioClip>();
        capitanoSound = new List<AudioClip>();
        
        // -----------------SET CLIP UMANO-------------------------------------
        for(int index=1; index<14; index++)
        {
            umanoSound.Add(Resources.Load<AudioClip>("Umano/" + index));
        }
        //----------------------SET CLIP CAPITANO ---------------------------
        for (int index = 1; index < 14; index++)
        {
            capitanoSound.Add(Resources.Load<AudioClip>("Capitano/" + index));
        }
        //------------------SET CLIP GABBIANO-------------------------------------
        for (int index = 1; index < 14; index++)
        {
            gabbianoSound.Add(Resources.Load<AudioClip>("Gabbiano/" + index));
        }
        //------------------SET CLIP TARTARUGA-------------------------------------
        for (int index = 1; index < 13; index++)
        {
            tartarugaSound.Add(Resources.Load<AudioClip>("Tartaruga/" + index));
        }
        //------------------SET CLIP ANIMALE CINESE-------------------------------------
        for (int index = 1; index < 14; index++)
        {
            animaleCSound.Add(Resources.Load<AudioClip>("Animale Cinese/" + index));
        }
        //------------------SET CLIP ANIAMLE AFRICANO-------------------------------------
        for (int index = 1; index < 14; index++)
        {
            animaleASound.Add(Resources.Load<AudioClip>("Animale Africano/" + index));
        }
    }


    public void sequenceFromSentece(string sentence)
    {
        sequenceClips = new List<int>();

        for (int index = 0; index < sentence.Length / 3; index++)
        {
            int x = sentence[index * 3] + (sentence[index * 3 + 1]) * (sentence[index * 3 + 2]);
            int y = sentence[index * 3] * (sentence[index * 3 + 1]) + (sentence[index * 3 + 2]);

            sequenceClips.Add((int)(Mathf.PerlinNoise((x * 13.5674721f), (y * 23.8430874f)) * sentence.Length));
        }
    }

    

    public void saySentence(string nameSpeaker,string sentence)
    {    
       sequenceFromSentece(sentence);
        switch (nameSpeaker.Remove(nameSpeaker.Length - 1, 1)) // remove last char control
        {
            case "Umano":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine = StartCoroutine(Voice(sequenceClips, umanoSound));
                break;
            case "Capitano":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine= StartCoroutine(Voice(sequenceClips, capitanoSound));
                break;
            case "Gabbiano":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine =StartCoroutine(Voice(sequenceClips, gabbianoSound));
                break;
            case "Tartaruga":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine=StartCoroutine(Voice(sequenceClips, tartarugaSound));
                break;
            case "AnimaleCinese":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine=StartCoroutine(Voice(sequenceClips, animaleCSound));
                break;
            case "AnimaleAfricano":
                stopThisCorutine(voiceCoroutine);
                voiceCoroutine=StartCoroutine(Voice(sequenceClips, animaleASound));
                break;
            default:
                Debug.Log(nameSpeaker + "" + "isn't in the list");
                break;
        }
        

    }
    private IEnumerator Voice (List<int> sequenceClips, List<AudioClip> clips)
    {
        audioSource.Stop();
        isRunning = true;
        audioSource.PlayOneShot(clips[sequenceClips[0] % clips.Count]);

        for (int index = 1; index < sequenceClips.Count;)
        {
            yield return new WaitForSeconds(rythm);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clips[sequenceClips[index] % clips.Count]);
                index++;
            }

        }
        audioSource.Stop();

        isRunning = false;

    }
    
    public void stopThisCorutine (Coroutine c)
    {
        if (c != null)
        {
            StopCoroutine(c);
        }
    }

}
