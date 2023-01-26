using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class LandState : MonoBehaviour
    {
        public delegate void OnLand();
        public static event OnLand onLand;
        [SerializeField] private AnimationClip landAnimation;
        private readonly int landHash = Animator.StringToHash("Land");
        private Animator anim;
        private PlayerJumpController jumpController;
        public float checkerMagnitude;

        void Start()
        {
            jumpController = GetComponent<PlayerJumpController>();
            anim = GetComponent<Animator>();
        }

        void OnEnable() => onLand += Land;
        void OnDisable() => onLand -= Land;

        void Update()
        {
            if(IsGroundClose() && anim.GetBool("Fall")) 
            {
                onLand?.Invoke();
            }
        }

        private void Land() => StartCoroutine(Landing()) ;
        private IEnumerator Landing()
        {
            anim.SetBool(landHash, true);
            yield return new WaitForSeconds(landAnimation.length);
            jumpController.PlayInactive();
        }   

        
        //create a checker to swap to land animation

        private bool IsGroundClose()
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, checkerMagnitude, 1 << 7);
            return ray.collider != null;
        }

        private void OnDrawGizmos() 
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + checkerMagnitude * -1));   
        }
    }
}
