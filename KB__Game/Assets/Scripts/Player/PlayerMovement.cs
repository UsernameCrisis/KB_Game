using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 moveValue;
    [SerializeField] private Camera cam;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 100;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveValue.x * moveSpeed, moveValue.y * moveSpeed), ForceMode2D.Force);
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cam.transform.position.z);
    }
}