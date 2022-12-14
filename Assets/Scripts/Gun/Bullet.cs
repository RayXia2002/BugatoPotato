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
    public GameObject bulletSoundMaker;
    void Start()
    {
        bulletSoundMaker = GameObject.Find("BulletSoundMaker");
        speed = GameManager.Instance.bulletSpeed;
        atkDmg = GameManager.Instance.bulletDamage;
        timeStart = Time.time;
        player = GameObject.Find("Dale");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
        PushBack();
        transform.localScale = GameManager.Instance.bulletSize;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
                Debug.Log(atkDmg);
            }
            if (dieEffect != null)
            {
                bulletSoundMaker.GetComponent<AudioSource>().Play();
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
        GameManager.Instance.bulletSpeed += val;
    }
    public void UpgradeBulletDamage(float val) {
        GameManager.Instance.bulletDamage += val;
    }
}
