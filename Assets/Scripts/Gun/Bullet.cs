using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeElasped;
    private float timeStart;

    public GameObject dieEffect;
    private GameObject player;

    public float knockback;

    private Rigidbody2D rb;
    public GameObject branch;

    void Start()
    {
        timeStart = Time.time;
        player = GameObject.Find("Dale");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeStart > timeElasped)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Ground" || tag == "bug")
        {
            PushBack();
            if (dieEffect != null)
            {
                Instantiate(dieEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
    }

    void PushBack()
    {
        Vector3 direction = gameObject.transform.right;
        Vector2 push = new Vector2(Mathf.Abs(direction.x), Mathf.Abs(direction.y));

        float x = Mathf.Cos(push.x);
        float y = Mathf.Sin(push.y);

        if (push.x < .5) x = 0;
        if (push.y < .5) y = 0;

        if(direction.x > 0) x = -x;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(x * knockback, y * knockback), ForceMode2D.Impulse);
        Debug.Log(push);
    }
}
