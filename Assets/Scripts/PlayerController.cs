using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public Vector2 speed = new Vector2(7, 7);
    public Vector2 jumpHeight = new Vector2(0, 7);
    public Rigidbody2D rigidBody;
    public Boolean isJumping = false;
    public Boolean canRest = false;
    public Boolean isResting = false;
    public Animator animator;
    public Light2D light2d;
    bool m_FacingRight = true;
    public int health = 3;
    public SpriteRenderer heart1;
    public SpriteRenderer heart2;
    public SpriteRenderer heart3;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        UpdateHealth();
        if (!isResting)
        {
            float inputX = Input.GetAxis("Horizontal");
            
            Vector3 movement = new Vector3(speed.x * inputX, 0, 0);

            movement *= Time.deltaTime;
            transform.Translate(movement);
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) && !isJumping)
            {
                rigidBody.AddForce(jumpHeight, ForceMode2D.Impulse);
                isJumping = true;
            }


            
            if ((movement.x > 0 && !m_FacingRight) || (movement.x < 0 && m_FacingRight))
                Flip();

            animator.SetBool("isJumping", isJumping);
            
            animator.SetFloat("speed", Mathf.Abs(movement.x));
            
        }
        
        if (canRest && Input.GetKeyDown(KeyCode.E))
        {
            health = 3;            
            light2d.enabled = false;
            isResting = true;

        }

        if (isResting && Input.GetKeyDown(KeyCode.Escape))
        {
            light2d.enabled = true;
            isResting = false;
        }
        
        animator.SetBool("isResting", isResting);

    }

    void UpdateHealth()
    {
        heart1.enabled = health > 0;
        heart2.enabled = health > 1;
        heart3.enabled = health > 2;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground")
        {
            isJumping = false;
        }
        
        if (col.gameObject.tag == "bonfire")
        {
            canRest = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "bonfire")
        {
            canRest = false;
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    
}
