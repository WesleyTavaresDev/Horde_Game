using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    public bool OnGround {get; private set;}
    
    enum ANIMATION_JUMP_STATE{Inactive, Jumping, Falling, Landing};
    [SerializeField] private ANIMATION_JUMP_STATE animationJumpState;

    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private Vector2 checkerSize; 
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

#region playAnimations

    public void PlayJumpAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Jumping; 
    public void PlayFallAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Falling;
    public void PlayLandAnimation() => animationJumpState = ANIMATION_JUMP_STATE.Landing;
    public void PlayInactive() => animationJumpState = ANIMATION_JUMP_STATE.Inactive;
    public bool IsPlayingFallingAnimation() => animationJumpState == ANIMATION_JUMP_STATE.Falling;
    
#endregion

    private void Update()
    {
        OnGround = IsGrounded();

        switch (animationJumpState)
        {
            case ANIMATION_JUMP_STATE.Inactive:
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", false);
                anim.SetBool("Land", false);
            break;

            case ANIMATION_JUMP_STATE.Jumping:
                anim.SetBool("Jump", true);
                anim.SetBool("Idle", false);
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

    private bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerSize, 0, Vector2.zero, 0, 1 << 7);
    private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerSize);
}
