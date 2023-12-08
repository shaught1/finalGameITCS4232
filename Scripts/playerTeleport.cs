using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Teleporter")){
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Teleporter")){
            if (collision.gameObject == currentTeleporter){
                currentTeleporter = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if(currentTeleporter != null){
                transform.position = currentTeleporter.GetComponent<teleporter>().GetDestination().position;
            }
        }
    }
}
