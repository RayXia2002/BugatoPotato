using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Dale");
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (mousePosition-(Vector2)transform.position).normalized;
        
        float rotZ = transform.rotation.eulerAngles.z;

        Vector3 change = Vector3.one;
        Vector3 playerChange = Vector3.one;
        if (rotZ > 90 && rotZ < 270)
        {
            change.x = -1f;
            change.y = -1f;
            playerChange.x = -1f;
        }
        else
        {
            change.x = 1f;
            change.y = 1f;
            playerChange.x = 1f;
        }
        transform.localScale = change;
        player.transform.localScale = playerChange;
    }
        
}
