using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpController : MonoBehaviour
{
    enum ANIMATION_JUMP_STATE{Inactive, Jumping, Falling, Landing};
    [SerializeField] private ANIMATION_JUMP_STATE animationJumpState;

    [SerializeField] private Vector2 checkerRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;
    [SerializeField] private AnimationClip landAnimation;
    [SerializeField] private BoxCollider2D coll;

    private const float LAND_CHECKER_DISTANCE = -2f;
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

    private void Update()
    {
        if(rb.velocity.y >= -2f && animationJumpState == ANIMATION_JUMP_STATE.Falling)
            animationJumpState = ANIMATION_JUMP_STATE.Landing;

    }


    private void FixedUpdate()
    {
        if(rb.velocity.y < 0f)
            Fall();
    }

    private void LateUpdate()
    {
        switch (animationJumpState)
        {
            case ANIMATION_JUMP_STATE.Inactive:
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", false);
                anim.SetBool("Land", false);
            break;

            case ANIMATION_JUMP_STATE.Jumping:
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false);
            break;

            case ANIMATION_JUMP_STATE.Falling:
            anim.SetBool("Idle", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            break;

            case ANIMATION_JUMP_STATE.Landing:
            anim.SetBool("Idle", false);
                anim.SetBool("Fall", false);
                StartCoroutine(Land());
            break;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        animationJumpState = ANIMATION_JUMP_STATE.Jumping;
    }

    private void Fall()
    {
        rb.velocity += Vector2.down * fallForce * Time.fixedDeltaTime;     
        animationJumpState = ANIMATION_JUMP_STATE.Falling;
    }

    private IEnumerator Land()
    {
        anim.SetBool("Land", true);
        yield return new WaitForSeconds(landAnimation.length);
        anim.SetBool("Land", false);
        animationJumpState = ANIMATION_JUMP_STATE.Inactive;
    }

    public bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius, 0, Vector2.zero, 0, 1 << 7);
    
    private InputAction JumpInput() => input.actions["Jump"];        
    
    private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerRadius);
}
