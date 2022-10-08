using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Primera Forma: 
    // Tutorial:  https://www.youtube.com/watch?v=_nRzoTzeyxU&ab_channel=Brackeys 

    //Queue es una lista mas restringida respectiva de strings


    // Start is called before the first frame update
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return 5;
        }
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false);
    }
}
