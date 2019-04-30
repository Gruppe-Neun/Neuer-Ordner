using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pausePanel;

    public GameObject winPanel;

    public GameObject defeatPanel;

    private void Start() {
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
        if (GameControllerBehavior.won) {
            GameWon();
        }
        if (GameControllerBehavior.lost) {
            GameLost();
        }

    }

    void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gamePaused = false;
    }

    void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gamePaused = true;
    }

    void GameWon() {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gamePaused = true;
    }

    void GameLost() {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gamePaused = true;
    }
}
