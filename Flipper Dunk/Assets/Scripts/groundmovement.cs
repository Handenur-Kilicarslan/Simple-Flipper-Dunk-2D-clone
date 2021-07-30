using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundmovement : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //fare veya space
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
