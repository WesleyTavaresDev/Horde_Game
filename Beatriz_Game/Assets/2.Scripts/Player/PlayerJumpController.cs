using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] private Vector2 checkerRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    private PlayerInput input;
    
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => JumpInput().started += OnJump;
   
    private void OnJump(InputAction.CallbackContext context)
    {
        if(IsGrounded())
            Jump();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.y < 0f)
            Fall();
    }


    private void Fall()
    {
        rb.velocity += Vector2.down * fallForce * Time.deltaTime;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius, 0, Vector2.zero, 0, 1 << 7);
    
    private InputAction JumpInput() => input.actions["Jump"];        
    
    private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius);
}
