using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameControl.FREEZE();
            playerMovement.enabled = false;
            FindFirstObjectByType<CameraController>().ENCOUNTER_ZOOM();
        }
    }
}
