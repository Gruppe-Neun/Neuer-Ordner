using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour {

    public LevelBehavior startLevel;

    public LevelBehavior endLevel;

    public Sprite winScreen;

    public Sprite defeatScreen;

    public SpriteRenderer levelBackground;

    public Text scoreText;

    private int score = 0;

    private PlayerBehavior player;

    private LevelBehavior activeLevel;

    private FolderBehaviour folderTopLeft;
    private FolderBehaviour folderTopRight;
    private FolderBehaviour folderBottomLeft;
    private FolderBehaviour folderBottomRight;

    private Text path;

    private ProgressBarBehavior progressBar;

    public static bool won;

    public static bool lost;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        lost = false;
        
        path = GetComponentInChildren<Text>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarBehavior>();
        folderTopLeft = GameObject.FindGameObjectWithTag("FolderTopLeft").GetComponent<FolderBehaviour>();
        folderTopRight = GameObject.FindGameObjectWithTag("FolderTopRight").GetComponent<FolderBehaviour>();
        folderBottomLeft = GameObject.FindGameObjectWithTag("FolderBottomLeft").GetComponent<FolderBehaviour>();
        folderBottomRight = GameObject.FindGameObjectWithTag("FolderBottomRight").GetComponent<FolderBehaviour>();

        activeLevel = startLevel;
        GameObject.FindGameObjectWithTag("LevelBackground").SetActive(false) ;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();



        folderTopLeft.setName(null,0);
        folderTopRight.setName(null,0);
        folderBottomLeft.setName(null,0);
        folderBottomRight.setName("Start Game",0);

        activeLevel.startLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeLevel.getStatus() == 1) {
            levelSelectScreen();
        }
        progressBar.setProgress(activeLevel.progress());

    }

    public void levelSelectScreen() {
        string[] names = new string[] { null, null, null, null };
        int[] locks = new int[4] { 0, 0, 0, 0 }; 
        
        if (activeLevel.predecessor != null) {
            names[0] = "zurück";
            locks[0] = activeLevel.predecessor.locked - player.keyAmount;
        }
        if (activeLevel.successor_1 != null) {
            names[1] = activeLevel.successor_1.levelName;
            locks[1] = activeLevel.successor_1.locked - player.keyAmount;
        }
        if (activeLevel.successor_2 != null) {
            names[2] = activeLevel.successor_2.levelName;
            locks[2] = activeLevel.successor_2.locked - player.keyAmount;
        }
        if (activeLevel.successor_3 != null) {
            names[3] = activeLevel.successor_3.levelName;
            locks[3] = activeLevel.successor_3.locked - player.keyAmount;
        }
        folderTopLeft.setName(names[0], locks[0]);
        folderTopRight.setName(names[1], locks[1]);
        folderBottomLeft.setName(names[2], locks[2]);
        folderBottomRight.setName(names[3], locks[3]);
    }

    public void selectLevel(string folder) {

        activeLevel.endLevel();

        switch (folder){
            case "FolderTopLeft":
                activeLevel = activeLevel.predecessor;
                break;
            case "FolderTopRight":
                activeLevel = activeLevel.successor_1;
                break;
            case "FolderBottomLeft":
                activeLevel = activeLevel.successor_2;
                break;
            case "FolderBottomRight":
                activeLevel = activeLevel.successor_3;
                break;
        }

        activeLevel.startLevel();
        folderTopLeft.setName(null,0);
        folderTopRight.setName(null,0);
        folderBottomLeft.setName(null,0);
        folderBottomRight.setName(null,0);

        string newPath = activeLevel.levelName+"/";
        LevelBehavior tempLevel = activeLevel;
        while (true) {
            if (tempLevel.predecessor != null) {
                tempLevel = tempLevel.predecessor;
                newPath = tempLevel.levelName + "/"+newPath;
            } else {
                break;
            }
        }
        path.text = newPath;
    }

    public void addScore(int add) {
        score += add;
        scoreText.text = "" + score;
    }

    //gameOverScreen
    public void gameOver(bool win) {
        if (win) {
            won = true;
            levelBackground.gameObject.SetActive(true);
            levelBackground.sprite = winScreen;
        } else {
            lost = true;
            levelBackground.sprite = defeatScreen;
            levelBackground.gameObject.SetActive(true);
        }
    }
}
