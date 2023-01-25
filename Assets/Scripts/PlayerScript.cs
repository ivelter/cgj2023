using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Movement variables
    public float moveSpeed;
    public float jumpForce;
    public int jumpForceMultiplier = 1;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform waterCheck;
    
    private bool isJumping;
    private bool auSol;
    private bool onSurfaceWater = false;
    private bool jumpingOutOfWater = false;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    
    private float groundDrag = 12;
    private float iceDrag = 0;
    //public Animator anime;
    private Vector3 velocity = Vector3.zero;

    private LoadScenes scenes;

    private void Start()
    {
        scenes = GetComponent<LoadScenes>();
    }

    private void FixedUpdate()
    {
        if (isOutOfBounds())
        {
            Die();
        }
        float horizontalMovment = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        auSol = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if(Input.GetButton("Jump") && auSol == true) {
            isJumping = true;
        }
        MPlayer(horizontalMovment);
        Flip(rb.velocity.x);
        float absVelocityX = Mathf.Abs(rb.velocity.x);
        
        //anime.SetFloat("speed",absVelocityX);
        //Debug.Log(onSurfaceWater);
    }

    private void MPlayer(float horizontalMovment) {
        Vector3 targetVelocity = new Vector2(horizontalMovment,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        if (jumpingOutOfWater && auSol && !onSurfaceWater)
        {
            jumpingOutOfWater = false;
        }
        
        if (isJumping && !onSurfaceWater && !jumpingOutOfWater)
        {
            rb.AddForce(new Vector2(0f,jumpForce*jumpForceMultiplier));
            isJumping = false;
        }
        else if (isJumping && onSurfaceWater)
        {
            rb.AddForce(new Vector2(0f,jumpForce*jumpForceMultiplier/25));
            jumpingOutOfWater = true;
            isJumping = false;
        }
    }

    private void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 4)
        {
            onSurfaceWater = true;
        }

        if (other.CompareTag("portal"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Placeholder":
                    scenes.loadTitle();
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 4)
        {
            onSurfaceWater = false;
        }

        if (other.gameObject.name == "Fire")
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Ice":
                rb.drag = iceDrag;
                jumpForceMultiplier = 1;
                break;
            case "Terrain":
                rb.drag = groundDrag;
                jumpForceMultiplier = 6;
                break;
        }
        
    }
    
    private bool isOutOfBounds()
    {
        return gameObject.transform.position.y <= -3;
    }

    private void Die()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
