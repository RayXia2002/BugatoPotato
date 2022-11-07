using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Animator animator; 
    public float characterSpeed = 5f;
    public float characterJumpSpeed = 5f;
    private bool isJumping = false;
    public float horizontalMove = 0f;
    public bool isFacingRight = true;
    private Rigidbody2D rb;
    public GameObject stem, beetle, cater, fly, hitBox;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(stem.GetComponent<Collider2D>(), hitBox.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(beetle.GetComponent<Collider2D>(), hitBox.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(cater.GetComponent<Collider2D>(), hitBox.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(fly.GetComponent<Collider2D>(), hitBox.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(stem.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(beetle.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(cater.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(fly.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    void PlayerControl() {


        horizontalMove = Input.GetAxisRaw("Horizontal") * characterSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown("space") && !isJumping) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, characterJumpSpeed, 0);
            isJumping = true;
        }
        if (Input.GetKey("a")) {
            if (isFacingRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
            Vector3 pos = transform.position;
            pos.x -= characterSpeed * Time.smoothDeltaTime;
            transform.position = pos;
        }
        if (Input.GetKey("d")) {
            if (!isFacingRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
            Vector3 pos = transform.position;
            pos.x += characterSpeed * Time.smoothDeltaTime;
            transform.position = pos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("OneWayPlatform")) {
            isJumping = false;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
