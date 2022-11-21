using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetBehavior : MonoBehaviour
{
    public float speed;
    public GameObject dale;
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
        if (moving) {
            Vector3 direction = (dale.transform.position - this.transform.position);
            this.transform.position += direction * speed * Time.smoothDeltaTime;
        }
        // // should attack if in attack mode, touching the plant, and it is time for attack. 
        // bool shouldAttk = attk && (Time.time - lastAtk >= atkSpd);
        // if (shouldAttk && col.IsTouching(plant)) {
        //     // update last attack time
        //     lastAtk = Time.time;

        //     // update plant health
        //     IDamageable damageable = plant.GetComponent<IDamageable>();
        //     damageable.OnHit(atkDmg);
        // }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "bullet" && health == 0) {
            // change bug mode
            moving = false;
            attk = false;

            // update animation
            col.enabled = false;
            gameObject.GetComponent<Animator>().SetBool("isDie", true);
            StartCoroutine(Die());
        }
    }

    //when hit with bullet
    public void OnHit(float damage)
    {
        // update health
        health -= damage;
        StartCoroutine(RedTimer());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       // if trigger is dale
       if (other.gameObject.tag == "Player")
       {
            // cause damage to dale
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable.OnHit(playerAtkDmg);
       }
    }
    // death coroutine to delay destroy until animation is dead
    private IEnumerator Die() {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    // turn bug red for time after hit
    private IEnumerator RedTimer() {
        Color newColor = new Color(0.65f, 0.41f, 0.68f, 1f);
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
