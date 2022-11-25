using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IDamageable
{
    public float health { get; set; }
    public int maxHearts = 3;
    public bool invincible = false;
    public SpriteRenderer armSpriteRenderer;
    public PlayerHealthManager healthHearts;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        health = GameManager.Instance.playerHealth;
        healthHearts.SetHearts(health, GameManager.Instance.playerMaxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y")) 
        {
            health = 6;
            healthHearts.SetHearts(health, maxHearts);
        }
    }

    public void OnHit(float damage)
    {
        if (!invincible)
        {
            GetComponent<AudioSource>().Play();
            health -= damage;
            healthHearts.SetHearts(health, maxHearts);
            //rb.AddForce(knockback, ForceMode2D.Impulse);

            invincible = true;
            StartCoroutine(InvinciblityTimer());
        }
    }

    private IEnumerator InvinciblityTimer() {
        spriteRenderer.color = Color.red;
        armSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.white;
        armSpriteRenderer.color = Color.white;
        invincible = false;
    }

}
