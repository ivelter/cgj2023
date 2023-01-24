using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    
    private bool isJumping;
    private bool auSol;
    
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    //public Animator anime;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        float horizontalMovment = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        auSol = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if(Input.GetButton("Jump") && auSol == true) {
            isJumping = true;
        }
        Debug.Log(isJumping);

        MPlayer(horizontalMovment);
        Flip(rb.velocity.x);
        float absVelocityX = Mathf.Abs(rb.velocity.x);
        //anime.SetFloat("speed",absVelocityX);
    }

    void MPlayer(float horizontalMovment) {
        Vector3 targetVelocity = new Vector2(horizontalMovment,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
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
}
