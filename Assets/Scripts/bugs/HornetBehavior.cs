using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetBehavior : MonoBehaviour, IDamageable
{
    public float speed;
    private GameObject dale;
    private bool attk;
    private float lastAtk;
    private float atkSpd = 4f;
    private bool moving = true;
    public float atkDmg = 1f;
    public float playerAtkDmg = 1f;
    public float health { get; set; }
    private SpriteRenderer spriteRenderer;
    public Bullet bullet;
    Collider2D col;
    

    void Start()
    {
        dale = GameObject.Find("Dale");
        health = 20f;
        col = this.gameObject.GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        // move toward Dale
        if (moving) {
            Vector3 direction = (dale.transform.position - this.transform.position).normalized;
            this.transform.position += direction * speed * Time.smoothDeltaTime;
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

        // get distance between dale and hornet
        float dist = Vector3.Distance(dale.transform.position, this.transform.position);

        
        // if close enough, attk is true
        if (dist <= 1) {
            attk = true;
        }

        // if time to attack
        if (attk && (Time.time - lastAtk >= atkSpd)) {
            // update last attack time
            lastAtk = Time.time;

            // flash red before attack, stop moving for this
            moving = false;
            StartCoroutine(Flash());

            moving = true;
            // dash toward dale while attack animation
            StartCoroutine(Dash());

            // end attack
            attk = false;

            // start cooldown
            StartCoroutine(PauseMove());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet" && health <= 0) {
            // change bug mode
            moving = false;

            // update animation
            col.enabled = false;
            gameObject.GetComponent<Animator>().SetBool("isDie", true);
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

    // dash forward
    private IEnumerator Dash() {
        // start animation
        gameObject.GetComponent<Animator>().SetBool("isAttk", true);
        // save current speed
        float spd = speed;
        // increase speed
        speed = 3f;

        yield return new WaitForSeconds(0.4f);
        // return to flying animation
        gameObject.GetComponent<Animator>().SetBool("isAttk", false);
        // restore speed
        speed = spd;
    }

    // pause hornet after attack
    private IEnumerator PauseMove() {
        moving = false;
        yield return new WaitForSeconds(0.5f);
        moving = true;
    }

}
