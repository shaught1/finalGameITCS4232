using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    private void OnTriggerExit(Collider col){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}