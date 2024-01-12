using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float JumpSpeed;
   private Rigidbody2D rb ;

   public Transform GroundCheck;
   public float CheckRadius;
   public LayerMask whatIsGround;
   public bool isGrounded;

   public int maxJumpValue;
   int maxjump;


   private void Start()
   {
     maxjump = maxJumpValue;
     rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position ,CheckRadius , whatIsGround);

        if(Input.GetMouseButtonDown(0) && maxjump > 0 ) 
        {
          maxjump--; 
          Jump();
        }

        else if(Input.GetMouseButtonDown(0) && maxjump == 0 && isGrounded ) 
        {
            Jump();
        }

        if(isGrounded)
        {
            maxjump = maxJumpValue;
        }

        if(isGrounded == false)
        {
           FindObjectOfType<AudioManager>().Play("Land");
        }

   }

   void Jump()
   {
    FindObjectOfType<AudioManager>().Play("Jump");
    rb.velocity = Vector2.zero;
    rb.AddForce(new Vector2(0, JumpSpeed));
   }
}
