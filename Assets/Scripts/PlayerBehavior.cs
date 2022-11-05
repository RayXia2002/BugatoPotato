using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float characterSpeed = 8.0f;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    void PlayerControl() {
        if (Input.GetKeyDown("space") && !isJumping) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
            isJumping = true;
        }
        if (Input.GetKey("a")) {
            Vector3 pos = transform.position;
            pos.x -= characterSpeed * Time.smoothDeltaTime;
            transform.position = pos;
        }
        if (Input.GetKey("d")) {
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
