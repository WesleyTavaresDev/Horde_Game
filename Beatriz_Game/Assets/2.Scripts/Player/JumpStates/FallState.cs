using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MonoBehaviour
{
    [SerializeField] private float fallForce;

    private Rigidbody2D rb;
    private PlayerJumpController jumpController;
    private void Start() 
    {
        jumpController = GetComponent<PlayerJumpController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         if(rb.velocity.y < 0f)
            Fall();
    }
    private void Fall()
    {
        rb.velocity += Vector2.down * fallForce * Time.fixedDeltaTime;     
        jumpController.PlayFallAnimation();
    }

}
