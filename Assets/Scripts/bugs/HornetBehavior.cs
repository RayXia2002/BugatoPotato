using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetBehavior : MonoBehaviour, IDamageable
{
    public float speed = 0.6f;
    public float dashSpeed = 0.75f;
    public float dashingTime = 0.75f;
    public float dashingCooldown = 4.0f;
    private GameObject dale;
    private bool isDash = false, canDash = true;
    private float lastAtk;
    private float atkSpd = 4f;
    private bool moving = true;
    public float atkDmg = 1f;
    public float playerAtkDmg = 1f;
    public float health { get; set; }
    private SpriteRenderer spriteRenderer;
    public Bullet bullet;
    Collider2D col;
    Rigidbody2D rb;
    Vector3 direction;
    

    void Start()
    {
        dale = GameObject.Find("Dale");
        health = 20f;
        col = this.gameObject.GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // update targetting direction to dale
        direction = (dale.transform.position - this.transform.position).normalized;

        // get distance between dale and hornet
        float dist = Vector3.Distance(dale.transform.position, this.transform.position);
        if (dist <= 1.0f && canDash) {
            StartCoroutine(Dash());
        }
        else if (moving) {
            this.transform.position += direction * speed * Time.smoothDeltaTime;
            Flip();
        }
        
        // flips direction of hornet to face player
        void Flip() {
            if (direction.x < 0) {
                // face the correct direction
                Vector3 origScale = transform.localScale;
                origScale.x = -0.03f;
                transform.localScale = origScale;
            } else {
                // face the correct direction
                Vector3 origScale = transform.localScale;
                origScale.x = 0.03f;
                transform.localScale = origScale;
            }
        }
    }

    // function that makes the hornet dash depending on dashingTime
    private IEnumerator Dash() {
        
        float timePassed= 0;
        canDash = false;
        while (timePassed < dashingTime)
        {
            spriteRenderer.color = Color.red;
            transform.position += dashSpeed * direction * Time.smoothDeltaTime;
            timePassed += Time.smoothDeltaTime;
            Debug.Log(timePassed);
            yield return null;
        }
        spriteRenderer.color = Color.white;
        StartCoroutine(DashingCooldown());
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet" && health <= 0) {
            // change bug mode
            moving = false;

            // update animation
            col.enabled = false;
            gameObject.GetComponent<Animator>().SetBool("isDie", true);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Die());
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        // if trigger is dale
       if (other.gameObject.tag == "Player")
       {
            // cause damage to dale
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.OnHit(playerAtkDmg);
            StartCoroutine(PauseMove());
       }

    }

    //when hit with bullet
    public void OnHit(float damage)
    {
        // update health
        health -= damage;
        StartCoroutine(HitTimer());
    }

    // death coroutine to delay destroy until animation is dead
    private IEnumerator Die() {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    // turn bug purple for time after hit
    private IEnumerator HitTimer() {
        Color newColor = new Color(0.65f, 0.41f, 0.68f, 1f);
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    // turn hornet red before attack
    private IEnumerator Flash() {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }

    // pause hornet after attack
    private IEnumerator PauseMove() {
        moving = false;
        yield return new WaitForSeconds(1.0f);
        moving = true;
    }

    // dashing cooldown 
    private IEnumerator DashingCooldown() {
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
