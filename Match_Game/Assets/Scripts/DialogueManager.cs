using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    
    public UnityEvent onDialogueEnd; 

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("DialogueIsOpen", true);
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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        float typingSpeed = 0.005f; // Adjust this value to control the speed (Higher is slower)

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Add a delay between characters
        }
    }


    void EndDialogue()
    {
        animator.SetBool("DialogueIsOpen", false);
        onDialogueEnd?.Invoke();
        // Invoke the UnityEvent when the dialogue ends
    }
    
    
}