using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (mousePosition-(Vector2)transform.position).normalized;
        
        float rotZ = transform.rotation.eulerAngles.z;
        Vector3 change = Vector3.one;
        if (rotZ > 90 && rotZ < 270)
        {
            change.y = -1f;
        }
        else
        {
            change.y = 1f;
        }
        transform.localScale = change;
    }
}
