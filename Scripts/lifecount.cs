using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lifecount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public string levelToLoad;
    public Transform playerTransform;
    public Transform initialCheckpoint;
    private Transform currentCheckpoint;

    void Start(){
        currentCheckpoint = initialCheckpoint;
        playerTransform.position = initialCheckpoint.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = other.transform;
        }
    }
    
   public void loseLife(){
    livesRemaining--;

    if(livesRemaining > 0){
        lives[livesRemaining].enabled = false;
        playerTransform.position = currentCheckpoint.position;
    }
    if(livesRemaining == 0){
        SceneManager.LoadScene(levelToLoad);
    }
   }

   void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("trap")){
        loseLife();
    }
    if (collision.gameObject.CompareTag("FallDetector")){
        loseLife();
    }
   }
   public void Update(){
    if(Input.GetKeyDown(KeyCode.Return)){
        loseLife();
    }
   }
}
