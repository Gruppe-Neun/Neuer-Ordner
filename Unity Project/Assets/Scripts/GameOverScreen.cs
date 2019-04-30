using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    public Text gameOverMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gamePaused = false;
    }

    public void Pause(bool win) {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gamePaused = true;
        Cursor.visible = true;
        if (win) {
            gameOverMessage.text = "congratulations you won";
        } else {
            gameOverMessage.text = "Game Over";
        }
    }
}
