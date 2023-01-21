using System.Collections;
using UnityEngine;

namespace Player
{
    public class LandState : MonoBehaviour
    {
        [SerializeField] private AnimationClip landAnimation;

        private Animator anim;
        private PlayerJumpController jumpController;
        void Start()
        {
            jumpController = GetComponent<PlayerJumpController>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if(jumpController.OnGround && jumpController.IsPlayingFallingAnimation()) 
            {
                jumpController.PlayLandAnimation();
                StartCoroutine(Land());
            }
        }

        private IEnumerator Land()
        {
            anim.SetBool("Land", true);
            yield return new WaitForSeconds(landAnimation.length);
            jumpController.PlayInactive();
        }       
    }
}
