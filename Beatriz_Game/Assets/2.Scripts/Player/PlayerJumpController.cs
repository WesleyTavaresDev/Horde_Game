using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpController : MonoBehaviour
{
    enum ANIMATION_JUMP_STATE{Inactive, Jumping, Falling, Landing};
    [SerializeField] private ANIMATION_JUMP_STATE animationJumpState;

    [SerializeField] private AnimationClip landAnimation;

    private const float LAND_CHECKER_DISTANCE = -2f;
    private Rigidbody2D rb;
    private Animator anim;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void PlayJumpAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Jumping; 
    public void PlayFallAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Falling;
    public void PlayLandAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Landing;
    public void PlayInactive() => animationJumpState = ANIMATION_JUMP_STATE.Inactive;
    public bool IsPlayingFallingAnimation() => animationJumpState == ANIMATION_JUMP_STATE.Falling;

    private void Update()
    {
        if(rb.velocity.y >= -2f && animationJumpState == ANIMATION_JUMP_STATE.Falling)
            animationJumpState = ANIMATION_JUMP_STATE.Landing;

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
            break;
        }
    }

 
}
