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

        JumpInput().performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if(jumpController.OnGround) 
            Jump();
    }

    private void Jump()
    {
        jumpController.PlayJumpAnimation();
        rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private InputAction JumpInput() => input.actions["Jump"];

    private void OnDisable() => JumpInput().started -= OnJump;
}
