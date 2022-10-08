using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    // Tutorial:  https://www.youtube.com/watch?v=_nRzoTzeyxU&ab_channel=Brackeys 
    public Dialogue dialogue;

    public void triggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
