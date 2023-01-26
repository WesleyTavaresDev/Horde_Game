using UnityEngine;

namespace Player

{
    public class PlayerJumpController : MonoBehaviour
    {
        public bool OnGround {get; private set;}

        enum ANIMATION_JUMP_STATE{Inactive, Jumping, Falling, Landing};
        [SerializeField] private ANIMATION_JUMP_STATE animationJumpState;

        [SerializeField] private BoxCollider2D coll;
        [SerializeField] private Vector2 checkerSize; 
        

        private readonly int jumpHash = Animator.StringToHash("Jump");
        private readonly int fallHash = Animator.StringToHash("Fall");
        private readonly int landHash = Animator.StringToHash("Land");

        private Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
            coll = GetComponent<BoxCollider2D>();
        }

    #region playAnimations

        public void PlayInactive()
        {
            anim.SetBool(jumpHash, false);
            anim.SetBool(fallHash, false);
            anim.SetBool(landHash, false);
        }
    #endregion

        private void Update()
        {   
            OnGround = IsGrounded();
            Debug.Log(OnGround);
        }

        private bool IsGrounded() => Physics2D.BoxCast(new Vector2(coll.bounds.center.x , transform.position.y), checkerSize, 0, Vector2.zero, 0, 1 << 7);
        private void OnDrawGizmos() => Gizmos.DrawWireCube(new Vector2(coll.bounds.center.x , transform.position.y), checkerSize);
    }
}