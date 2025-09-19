using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;

    public void ShowDialogue()
    {
        dialogueBox.SetActive(true);
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
