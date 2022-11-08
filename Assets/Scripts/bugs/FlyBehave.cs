using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehave : MonoBehaviour
{
    public float speed;
    private bool attk;
    private float lastAtk;
    private float atkSpd = 4f;
    private bool moving = true;
    public Bullet bullet;
    Collider2D col;
    // Update is called once per frame
    void Update()
    {
        if (moving) {
            // update position
            transform.position += transform.right * Time.smoothDeltaTime * speed;
        }

        bool shouldAttk = attk && (Time.time - lastAtk >= atkSpd);
        if (shouldAttk) {
            lastAtk = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "stem") {
            attk = true;
            moving = false;
            gameObject.GetComponent<Animator>().SetBool("isAttk", true);
        }

        if (other.gameObject.tag == "bullet") {
            moving = false;
            attk = false;
            col = this.gameObject.GetComponent<Collider2D>();
            col.enabled = false;
            gameObject.GetComponent<Animator>().SetBool("isDie", true);
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
