using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float characterSpeed = 5f;
    public float characterJumpSpeed = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    public GameObject stem, beetle, cater, fly, hitBox;
    public Animator animator;
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
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * characterSpeed));
        if (Input.GetKeyDown("space") && !isJumping) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, characterJumpSpeed, 0);
            isJumping = true;
        }
        if (Input.GetKey("a")) {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Vector3 pos = transform.position;
            pos.x -= characterSpeed * Time.smoothDeltaTime;
            transform.position = pos;
            
        }
        if (Input.GetKey("d")) {
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
}
