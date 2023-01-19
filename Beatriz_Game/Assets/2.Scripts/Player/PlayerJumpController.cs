using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] private Vector2 checkerRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;
    [SerializeField] private AnimationClip landAnimation;

    [SerializeField] private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerInput input;
    
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    private void LateUpdate()
    {
        if(IsGrounded())
            anim.SetBool("Fall", false);
    }



    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
    }

    private void Fall()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Fall", true);
        rb.velocity += Vector2.down * fallForce * Time.deltaTime;     
    }

    private IEnumerator Land()
    {
        anim.SetBool("Land", true);
        yield return new WaitForSeconds(landAnimation.length);
        anim.SetBool("Land", false);
    }

    public bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius, 0, Vector2.zero, 0, 1 << 7);
    
    private InputAction JumpInput() => input.actions["Jump"];        
    
    private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius);
}
