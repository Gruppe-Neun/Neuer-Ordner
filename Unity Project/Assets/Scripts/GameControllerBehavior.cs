using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour {

    public LevelBehavior startLevel;




    private LevelBehavior activeLevel;

    private FolderBehaviour folderTopLeft;
    private FolderBehaviour folderTopRight;
    private FolderBehaviour folderBottomLeft;
    private FolderBehaviour folderBottomRight;

    private Text path;

    private ProgressBarBehavior progressBar;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponentInChildren<Text>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBarBehavior>();
        folderTopLeft = GameObject.FindGameObjectWithTag("FolderTopLeft").GetComponent<FolderBehaviour>();
        folderTopRight = GameObject.FindGameObjectWithTag("FolderTopRight").GetComponent<FolderBehaviour>();
        folderBottomLeft = GameObject.FindGameObjectWithTag("FolderBottomLeft").GetComponent<FolderBehaviour>();
        folderBottomRight = GameObject.FindGameObjectWithTag("FolderBottomRight").GetComponent<FolderBehaviour>();
        
        GameObject.FindGameObjectWithTag("LevelBackground").SetActive(false) ;
        activeLevel = startLevel;
        activeLevel.startLevel();
       



        folderTopLeft.setName(null);
        folderTopRight.setName(null);
        folderBottomLeft.setName(null);
        folderBottomRight.setName("Start Game");
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

        if(activeLevel.predecessor !=null) {
            names[0] = "zurück";
        }
        if (activeLevel.successor_1 != null) {
            names[1] = activeLevel.successor_1.levelName;
        }
        if (activeLevel.successor_2 != null) {
            names[2] = activeLevel.successor_2.levelName;
        }
        if (activeLevel.successor_3 != null) {
            names[3] = activeLevel.successor_3.levelName;
        }
        setFolder(names[0],names[1],names[2],names[3]);
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
        folderTopLeft.setName(null);
        folderTopRight.setName(null);
        folderBottomLeft.setName(null);
        folderBottomRight.setName(null);

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
    

    private void setFolder(string topLeft, string topRight, string bottomLeft, string bottomRight) {
        folderTopLeft.setName(topLeft);
        folderTopRight.setName(topRight);
        folderBottomLeft.setName(bottomLeft);
        folderBottomRight.setName(bottomRight);
    }
}
