using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float characterSpeed = 1f;
    public float characterJumpSpeed = 5f;
    private int jumps = 0;
    private Rigidbody2D rb;
    public Animator animator;

    private float moveStart = 0;
    private float moveEnd = 0;
    private bool isMoving;
    public float rampUpTime;
    public float rampDownTime;
    private bool direction;
    private bool upgradedDoubleJump = false;
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
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * characterSpeed));
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && CanJump()) {
            rb.velocity = new Vector3(rb.velocity.x, characterJumpSpeed, 0);
            Debug.Log("jump");
            jumps++;
        }
        if (Input.GetKey("a")) {
            direction = true;
            StartCoroutine(RampUp(direction));
        }
        if (Input.GetKey("d")) {
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

    // checks all conditions if dale can jump
    private bool CanJump() {
        // return true if double jump is enabled and dale has jumped less than 2 times
        if (upgradedDoubleJump && jumps < 2) {
            return true;
        }
        else if (jumps == 0 && rb.velocity.y <= 0.1f) {
            return true;
        }
        else {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if ((other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("OneWayPlatform")) && rb.velocity.y <= 0.1f) {
            jumps = 0;
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

    #region Player Upgrades
    public void UpgradePlayerSpeed(float val) {
        characterSpeed += val;
    }
    public void UpgradeDoubleJump() {
        upgradedDoubleJump = true;
    }
    #endregion Player Upgrades
}
