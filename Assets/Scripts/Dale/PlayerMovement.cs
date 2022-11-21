using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float characterSpeed = 1f;
    public float characterJumpSpeed = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    public Animator animator;

    private float moveStart = 0;
    private float moveEnd = 0;
    private bool isMoving;
    public float rampUpTime;
    public float rampDownTime;
    private bool direction;

    private float percentLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    void PlayerControl() {        
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && !isJumping) {
            rb.velocity = new Vector3(rb.velocity.x, characterJumpSpeed, 0);
            isJumping = true;
        }
        if (Input.GetKey("a")) {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * characterSpeed));
            direction = true;
            StartCoroutine(RampUp(direction));
        }
        if (Input.GetKey("d")) {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * characterSpeed));
            direction = false;
            StartCoroutine(RampUp(direction));
        }
        
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            if(isMoving || moveEnd > 0)
            {
                StartCoroutine(RampDown(direction));
            }
        }    
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("OneWayPlatform")) {
            isJumping = false;
        }
    }

    IEnumerator RampUp(bool left)
    {
        if(!isMoving)
        {
            isMoving = true;
            moveStart = Time.time;
        }
        float percentage;
        
        if(Time.time - moveStart < rampUpTime) percentage = (Time.time - moveStart) / rampUpTime;
        else percentage = 1;

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        Vector3 pos = transform.position;

        if (left) pos.x -= characterSpeed * Time.smoothDeltaTime * percentage;
        else pos.x += characterSpeed * Time.smoothDeltaTime * percentage;
        
        transform.position = pos;
        percentLeft = percentage;
        yield return null;
    }

    IEnumerator RampDown(bool direction)
    {
        if(isMoving)
        {
            isMoving = false;
            moveEnd = Time.time;
        }
        float percentage;

        if (percentLeft > 0)
        {
            percentage = percentLeft;
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if(Time.time - moveEnd < rampDownTime) percentage = 1 - (Time.time - moveEnd) / rampDownTime;
        else percentage = 0;
        
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        Vector3 pos = transform.position;

        if (direction) pos.x -= characterSpeed * Time.smoothDeltaTime * percentage;
        else pos.x += characterSpeed * Time.smoothDeltaTime * percentage;

        transform.position = pos;
        percentLeft = percentage;
        yield return null;
    }

    public void UpgradePlayerSpeed(float val) {
        characterSpeed += val;
    }

}
