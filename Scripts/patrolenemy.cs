using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolenemy : MonoBehaviour
{
    [SerializeField] private float health;
    public float moveSpeed = 2.0f; 
    public Transform leftPoint;
    public Transform rightPoint; 

    private bool movingRight = true;

    public GameObject bone;

    void Update()
    {
       
        if (transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
            flip();
        }
        else if (transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
            flip();
        }

        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
    private void flip(){
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void TakeDamage(float damage){
        Instantiate(bone, transform.position, Quaternion.identity);
        health -= damage;
        
        if(health <= 0f){
            Destroy(gameObject);
        }
    }
}
