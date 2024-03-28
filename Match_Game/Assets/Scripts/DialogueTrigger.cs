using UnityEngine;
using UnityEngine.Events; // Import UnityEvents namespace

[RequireComponent(typeof(SpriteRenderer))]
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public UnityEvent onDialogueEndAction; // UnityEvent to specify action on dialogue end
    public UnityEvent onDialogueStartAction; // UnityEvent to specify action on dialogue start

    private SpriteBehaviour spriteBehaviour;

    private void Start()
    {
        spriteBehaviour = GetComponent<SpriteBehaviour>();
        onDialogueStartAction.Invoke(); // Invoke action on dialogue start
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().onDialogueEnd.AddListener(OnDialogueEndHandler);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnDialogueEndHandler()
    {
        onDialogueEndAction.Invoke(); // Invoke action on dialogue end
        FindObjectOfType<DialogueManager>().onDialogueEnd.RemoveListener(OnDialogueEndHandler);
    }
}
