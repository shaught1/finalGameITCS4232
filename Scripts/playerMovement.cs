using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{   private GameObject shooting;
    private GameObject bullet;
    public Rigidbody2D rigidBody;
    public Camera cam;

    public float moveSpeed = 5f;
    public float hp = 100;

    Vector2 mousePos;
    Vector2 movement;

    void Update()
    {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rigidBody.position;
        transform.up = GetComponent<Rigidbody2D>().velocity.normalized;
    }
}

