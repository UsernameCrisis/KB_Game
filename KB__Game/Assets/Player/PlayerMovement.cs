using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 moveValue;

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
    }
}