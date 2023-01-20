using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : MonoBehaviour
{
    [SerializeField] private AnimationClip landAnimation;
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerJumpController jumpController;
    void Start()
    {
        jumpController = GetComponent<PlayerJumpController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(rb.velocity.y >= -2f && jumpController.IsPlayingFallingAnimation()) 
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
