using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public UnityEvent onDialogueEndAction; 
    public UnityEvent onDialogueStartAction; 

    private SpriteBehaviour spriteBehaviour;

    private void Start()
    {
        spriteBehaviour = GetComponent<SpriteBehaviour>();
        onDialogueStartAction.Invoke(); 
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().onDialogueEnd.AddListener(OnDialogueEndHandler);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnDialogueEndHandler()
    {
        onDialogueEndAction.Invoke(); 
        FindObjectOfType<DialogueManager>().onDialogueEnd.RemoveListener(OnDialogueEndHandler);
    }
}
