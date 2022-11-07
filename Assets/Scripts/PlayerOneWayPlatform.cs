using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    
    private GameObject currentOneWayPlatform = null;
    [SerializeField] private BoxCollider2D playerCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s")) {
            if (currentOneWayPlatform != null) {
                StartCoroutine(DisableCollision());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("OneWayPlatform")) {
            currentOneWayPlatform = other.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("OneWayPlatform")) {
            currentOneWayPlatform = null;
        }
    }
    private IEnumerator DisableCollision() {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.75f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
