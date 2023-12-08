using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float health;
   public float moveSpeed;
   private Transform currentPoint;
   private Rigidbody2D rb;
   public Transform PointA;
   public Transform PointB;

   public GameObject bone;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
    }
    void Update(){

        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform){
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else{
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform){
            flip();
            currentPoint = PointB.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform){
            flip();
            currentPoint = PointA.transform;
        }
    }
    private void flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void TakeDamage(float damage){
        Instantiate(bone, transform.position, Quaternion.identity);
        health -= damage;
        
        if(health <= 0f){
            Destroy(gameObject);
        }
    }
}
