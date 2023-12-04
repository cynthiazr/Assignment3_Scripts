using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 35f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        horizontal = Input.GetAxisRaw("Horizontal");// returns value of -1 0 or 1 depending
                                                    //on the direction we are moving


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManager.PlaySound("PlayerJump");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            SoundManager.PlaySound("PlayerJump");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balls")
        {
            SoundManager.PlaySound("PlayerHit");
            Die();
            
        }

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; // Change to static because we don't want the player to be able to move and continue playing
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the level
    }

}
