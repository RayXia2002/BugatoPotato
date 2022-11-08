using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    
    //private GameObject currentOneWayPlatform = null;
    //[SerializeField] public BoxCollider2D feetCollider;
    public bool coll;
    public PlatformEffector2D platform;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("s")) {
            platform.surfaceArc = 0f;
            StartCoroutine(DisableCollision());
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
            coll = true;
    }
    private void OnCollisionExit2D(Collision2D other) {
            coll = false;
    }
    private IEnumerator DisableCollision() {
        yield return new WaitForSeconds(0.3f);
        platform.surfaceArc = 90f;

    }
}
