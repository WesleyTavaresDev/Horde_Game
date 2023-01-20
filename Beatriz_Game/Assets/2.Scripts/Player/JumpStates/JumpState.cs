using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 checkerRadius;
    [SerializeField] private BoxCollider2D coll;

    private PlayerInput input;
    private Rigidbody2D rb;
    private PlayerJumpController jumpController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        coll = GetComponent<BoxCollider2D>();
        jumpController = GetComponent<PlayerJumpController>();

        JumpInput().started += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if(IsGrounded()) 
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        jumpController.PlayJumpAnimation();
    }

    private InputAction JumpInput() => input.actions["Jump"];

    public bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius, 0, Vector2.zero, 0, 1 << 7);

    private void OnDisable() => JumpInput().started -= OnJump;
    private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius);
}
