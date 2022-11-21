using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 250.0f;
    public float timeElasped;
    private float timeStart;
    public float atkDmg;
    public GameObject dieEffect;
    private GameObject player;
    public float knockback = 2.0f;
    private Rigidbody2D rb;
    public GameObject branch;
    public float percentX;

    void Start()
    {
        timeStart = Time.time;
        player = GameObject.Find("Dale");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
        PushBack();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Ground" || tag == "bug")
        {
            if (tag == "bug")
            {
                IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
                damageable.OnHit(atkDmg);
            }
            if (dieEffect != null)
            {
                Instantiate(dieEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }


    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    void PushBack()
    {
        Vector3 direction = gameObject.transform.right;
        Vector2 push = new Vector2(direction.x, direction.y);

        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-push.x * knockback * percentX, -push.y * knockback), ForceMode2D.Impulse);
    }

    public void UpgradeBulletSpeed(float val) {
        speed += val;
    }
}
