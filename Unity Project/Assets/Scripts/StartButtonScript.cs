using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void StartGame() {
        Debug.Log("RELOAD GAME");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load current scene
    }
}
