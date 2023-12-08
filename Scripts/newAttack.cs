using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;

    float timeUntilMelee;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilMelee = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeUntilMelee <= 0f){
            if (Input.GetMouseButtonDown(0)){
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
            else{
                timeUntilMelee -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            other.GetComponent<patrolenemy>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
    }
    public void ResetMeleeTimer(){
        timeUntilMelee = 0f;
    }
}
