using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueBox;
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby)
        {
            Debug.Log("Player is nearby");
            dialogueBox.SetActive(true);
        }

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed near NPC");
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC trigger");
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left NPC trigger");
            isPlayerNearby = false;
            dialogueBox.SetActive(false);
        }
    }
}
